using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Collections.Generic;

namespace ProjetoView.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private readonly AlunoTurmaService _alunoTurmaService;
        private readonly AlunoService _alunoService;
        private readonly TurmaService _turmaService;
        public AlunoTurmaController()
        {
            _alunoTurmaService = new AlunoTurmaService();
            _alunoService = new AlunoService();
            _turmaService = new TurmaService();
        }

        public IActionResult Index()
        {
            return View(_alunoTurmaService.Listar());
        }

        public IActionResult Dados(AlunoTurma alunoTurma)
        {
            AlunoTurma dados = new AlunoTurma();

            if (alunoTurma.id != 0)
            {
                dados = this._alunoTurmaService.PegarPorId(alunoTurma.id);
            }

            dados.listaAlunosAtivos = this._alunoService.ListarAtivos();
            dados.listaTurmasAtivas = this._turmaService.ListarAtivos();

            return View(dados);
        }

        [HttpPost]
        public IActionResult Salvar(int id, int aluno_id, int turma_id)
        {
            AlunoTurma data = new AlunoTurma()
            {
                id = id,
                aluno_id = aluno_id,
                turma_id = turma_id
            };

            string mensagem = "";

            if (data.id == 0)
            {
                mensagem = this._alunoTurmaService.Cadastrar(data);
                
            }
            else
            {
                mensagem = this._alunoTurmaService.Editar(data);
            }

            if (mensagem != "")
            {
                AlunoTurma dados = new AlunoTurma();

                dados.listaAlunosAtivos = this._alunoService.ListarAtivos();
                dados.listaTurmasAtivas = this._turmaService.ListarAtivos();

                TempData["Erro"] = mensagem;
                return View("Dados", dados);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Inativar(int id)
        {
            this._alunoTurmaService.Inativar(id);
            return RedirectToAction("Index");
        }

    }
}
