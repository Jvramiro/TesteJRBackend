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
                DS_TAREFA = "Fazer Atividade Faculdade"
            });

            tarefas.Add(new TarefaDTO {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            });
        }

        public List<TarefaDTO> GetAllTarefas()
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

        public TarefaDTO GetById(int ID_TAREFA) {
            try {
                var tarefa = tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if (tarefa == null) {
                    throw new ArgumentException($"Id {ID_TAREFA} não encontrado na lista");
                }

                return tarefa;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void Update(TarefaDTO updatedTarefa) {
            try {
                int ID_TAREFA = updatedTarefa.ID_TAREFA;

                var tarefa = tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                if (tarefa == null) {
                    throw new ArgumentException($"Id {ID_TAREFA} não encontrado na lista");
                }

                tarefa.ID_TAREFA = updatedTarefa.ID_TAREFA;
                tarefa.DS_TAREFA = updatedTarefa.DS_TAREFA;

            }
            catch (Exception ex) {
                throw ex;
            }
        }


        public void Add(TarefaDTO Request)
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
        public void Delete(int ID_TAREFA)
        {
            //Tratativa de erro para não parar a operação por falhas no códigos seguintes
            try
            {
                //Declaração de variavel tarefa utilizando em sua declaração uma expressão Lambda
                //Utilizando FirstOrDefault para verificar se existe na lista um objeto com a propriedade
                //ID_TAREFA igual para retornar
                //Caso contrario retornar nulo
                var tarefa = tarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                //Caso for nulo retorna o erro especificando que foi por nao existir este ID na lista
                if(tarefa == null) {
                    throw new ArgumentException($"Id {ID_TAREFA} não encontrado na lista");
                }

                //Caso a tarefa existir remove diretamente da lista
                tarefas.Remove(tarefa);
            }
            //Caso ocorra uma falha no Try é retornado o parametro ex que contem o motivo da falha
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
