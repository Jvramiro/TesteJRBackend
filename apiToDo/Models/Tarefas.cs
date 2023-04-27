using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private List<TarefaDTO> tarefas = new List<TarefaDTO>();

        public Tarefas() {

            tarefas.Add(new TarefaDTO {
                ID_TAREFA = 1,
                DS_TAREFA = "Fazer Compras"
            });

            tarefas.Add(new TarefaDTO {
                ID_TAREFA = 2,
                DS_TAREFA = "Fazer Atividad Faculdade"
            });

            tarefas.Add(new TarefaDTO {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            });
        }

        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return tarefas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                tarefas.Add(Request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                var Tarefa = tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if(Tarefa == null) {
                    throw new ArgumentException("Id não encontrado");
                }

                TarefaDTO Tarefa2 = tarefas.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                tarefas.Remove(Tarefa2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
