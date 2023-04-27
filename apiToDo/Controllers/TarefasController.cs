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
        private static Tarefas tarefas = new Tarefas();

        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                var listaTarefas = tarefas.lstTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao retornar os dados: {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                tarefas.InserirTarefa(Request);
                var listaTarefas = tarefas.lstTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao adicionar os dados: {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                tarefas.DeletarTarefa(ID_TAREFA);
                var listaTarefas = tarefas.lstTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao deletar os dados: {ex.Message}" });
            }
        }
    }
}
