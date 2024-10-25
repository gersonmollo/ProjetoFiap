using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Text;
using System;
using System.Text.RegularExpressions;
using ProjetoFiap.Interfaces;

namespace ProjetoFiap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;
        public AlunoController()
        {
            _alunoService = new AlunoService();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Aluno aluno)
        {
            string mensagem = this._alunoService.Cadastrar(aluno);

            if (mensagem == "")
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, new { msg = mensagem });
            }
        }

        [HttpDelete("Inativar")]
        public IActionResult Desativar(int id)
        {
            this._alunoService.Inativar(id);

            return Ok();
        }

        [HttpPut("editar")]
        public IActionResult Editar(Aluno aluno)
        {
            string mensagem = this._alunoService.Editar(aluno);

            if (mensagem == "")
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, new { msg = mensagem });
            }
        }

        [HttpGet("aluno")]
        public IActionResult PegarPorId(int id)
        {
            IEnumerable<Aluno> data = this._alunoService.PegarPorId(id);

            return Ok(data);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            IEnumerable<Aluno> data = this._alunoService.Listar();

            return Ok(data);
        }
    }
}
