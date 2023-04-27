using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {

        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                var tarefas = new Tarefas();
                List<TarefaDTO> lstTarefas = tarefas.lstTarefas();
                return StatusCode(200, lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao retornar os dados {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                var tarefas = new Tarefas();
                List<TarefaDTO> lstTarefas = tarefas.InserirTarefa(Request);
                return StatusCode(200, lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao adicionar os dados {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                var tarefas = new Tarefas();
                List<TarefaDTO> lstTarefas = tarefas.DeletarTarefa(ID_TAREFA);
                return StatusCode(200, lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao deleter os dados {ex.Message}" });
            }
        }
    }
}
