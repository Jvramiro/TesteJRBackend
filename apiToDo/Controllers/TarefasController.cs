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

        [HttpGet("tarefas")]
        public ActionResult GetAllTarefas()
        {
            try
            {
                var listaTarefas = tarefas.GetAllTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao retornar os dados: {ex.Message}"});
            }
        }

        [HttpGet("tarefas/{id}")]
        public ActionResult GetTarefa(int id) {
            try {
                var tarefa = tarefas.GetById(id);
                return StatusCode(200, tarefa);
            }

            catch (Exception ex) {
                return StatusCode(404, new { msg = $"Ocorreu um erro ao retornar os dados: {ex.Message}" });
            }
        }

        [HttpPut("tarefas")]
        public ActionResult UpdateTarefa([FromBody] TarefaDTO Request) {
            try {
                tarefas.Update(Request);
                var listaTarefas = tarefas.GetAllTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex) {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao retornar os dados: {ex.Message}" });
            }
        }

        [HttpPost("tarefas")]
        public ActionResult InsertTarefa([FromBody] TarefaDTO Request)
        {
            try
            {
                tarefas.Add(Request);
                var listaTarefas = tarefas.GetAllTarefas();
                return StatusCode(201, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao adicionar os dados: {ex.Message}" });
            }
        }

        [HttpDelete("tarefas")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                tarefas.Delete(ID_TAREFA);
                var listaTarefas = tarefas.GetAllTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro ao deletar os dados: {ex.Message}" });
            }
        }
    }
}
