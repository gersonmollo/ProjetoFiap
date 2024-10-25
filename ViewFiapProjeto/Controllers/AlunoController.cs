using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Collections.Generic;

namespace ProjetoView.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AlunoService _alunoService;
        private readonly AlunoTurmaService _alunoTurmaService;
        public AlunoController()
        {
            _alunoService = new AlunoService();
            _alunoTurmaService = new AlunoTurmaService();
        }

        public IActionResult Index()
        {
            return View(_alunoService.Listar());
        }

        public IActionResult Dados(Aluno aluno)
        {
            if (aluno.id == 0)
            {
                return View();
            }
            else
            {
                IEnumerable<Aluno> retorno = this._alunoService.PegarPorId(aluno.id);

                Aluno dados = retorno.FirstOrDefault();

                return View(dados);
            }
            
        }

        [HttpPost]
        public IActionResult Salvar(int id, string nome, string usuario, string senha)
        {
            Aluno data = new Aluno()
            {
                id = id,
                nome = nome,
                usuario = usuario,
                senha = senha
            };

            string mensagem = "";

            if (data.id == 0)
            {
                mensagem = this._alunoService.Cadastrar(data);
                
            }
            else
            {
                mensagem = this._alunoService.Editar(data);
            }

            if (mensagem != "")
            {
                TempData["Erro"] = mensagem;
                return View("Dados");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Inativar(int id)
        {
            this._alunoService.Inativar(id);
            this._alunoTurmaService.InativarPorAluno(id);

            return RedirectToAction("Index");
        }

    }
}
