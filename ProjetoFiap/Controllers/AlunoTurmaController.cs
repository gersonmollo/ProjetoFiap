using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Collections.Generic;

namespace ProjetoFiap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly AlunoTurmaService _alunoTurmaService;
        public AlunoTurmaController()
        {
            _alunoTurmaService = new AlunoTurmaService();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(AlunoTurma alunoTurma)
        {
            string mensagem = this._alunoTurmaService.Cadastrar(alunoTurma);

            if (mensagem != "")
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, mensagem);
            }
        }

        [HttpDelete("desativar")]
        public IActionResult Desativar(int id)
        {
            this._alunoTurmaService.Inativar(id);

            return Ok();
        }

        [HttpPut("editar")]
        public IActionResult Editar(AlunoTurma alunoTurma)
        {
            string mensagem = this._alunoTurmaService.Editar(alunoTurma);

            if (mensagem != "")
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, mensagem);
            }
        }

        [HttpGet("alunoTurma")]
        public IActionResult PegarPorId(int id)
        {
            AlunoTurma data = this._alunoTurmaService.PegarPorId(id);

            return Ok(data);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            List<AlunoTurma> data = this._alunoTurmaService.Listar();

            return Ok(data);
        }
    }
}
