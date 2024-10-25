using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Collections.Generic;

namespace ProjetoView.Controllers
{
    public class TurmaController : Controller
    {
        private readonly TurmaService _turmaService;
        private readonly AlunoTurmaService _alunoTurmaService;
        public TurmaController()
        {
            _turmaService = new TurmaService();
            _alunoTurmaService = new AlunoTurmaService();
        }

        public IActionResult Index()
        {
            return View(_turmaService.Listar());
        }

        public IActionResult Dados(Turma turma)
        {
            if (turma.id == 0)
            {
                return View();
            }
            else
            {
                IEnumerable<Turma> retorno = this._turmaService.PegarPorId(turma.id);

                Turma dados = retorno.FirstOrDefault();

                return View(dados);
            }
            
        }

        [HttpPost]
        public IActionResult Salvar(int id, string turma, int curso_id, int ano)
        {
            Turma data = new Turma()
            {
                id = id,
                turma = turma,
                curso_id = curso_id,
                ano = ano
            };

            bool salvou = true;

            if (data.id == 0)
            {
                salvou = this._turmaService.Cadastrar(data);
                
            }
            else
            {
                salvou = this._turmaService.Editar(data);
            }

            if (!salvou)
            {
                TempData["Erro"] = "Nome de turma já cadastrado!";
                return View("Dados");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Inativar(int id)
        {
            this._turmaService.Inativar(id);
            this._alunoTurmaService.InativarPorTurma(id);

            return RedirectToAction("Index");
        }

    }
}
