using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Models;
using ProjetoFiap.Services;

namespace ProjetoFiap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaService _turmaService;
        public TurmaController()
        {
            _turmaService = new TurmaService();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Turma turma)
        {
            bool mensagem = this._turmaService.Cadastrar(turma);

            if (mensagem)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, new { msg = mensagem });
            }
        }

        [HttpDelete("desativar")]
        public IActionResult Desativar(int id)
        {
            this._turmaService.Inativar(id);

            return Ok();
        }

        [HttpPut("editar")]
        public IActionResult Editar(Turma turma)
        {
            bool mensagem = this._turmaService.Editar(turma);

            if (mensagem)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400, new { msg = mensagem });
            }
        }

        [HttpGet("turma")]
        public IActionResult PegarPorId(int id)
        {
            IEnumerable<Turma> data = this._turmaService.PegarPorId(id);

            return Ok(data);
        }

        [HttpGet("lista")]
        public IActionResult Listar()
        {
            IEnumerable<Turma> data = this._turmaService.Listar();

            return Ok(data);
        }
    }
}
