using Microsoft.AspNetCore.Mvc;
using StatusTarefas.Models;

namespace StatusTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> _tarefas = new List<Tarefa>()
        {
            new Tarefa { TarefaId = 1, TarefaTitulo ="Análise de Requisitos", Descricao = "Realizar reuniões com os stakeholders para entender seus requisitos. ",Status = "Concluída"},
            new Tarefa { TarefaId = 2, TarefaTitulo ="Planejamento", Descricao = "Criar um plano de projeto, incluindo cronogramas e marcos.", Status = "Pendente"},
            new Tarefa { TarefaId = 3, TarefaTitulo ="Implementação", Descricao = "Escrever código limpo de acordo com as melhores práticas de programação.", Status = "Pendente"}
        };

        public IActionResult Index()
        {
            return View(_tarefas);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefas.Count > 0 ? _tarefas.Max(c => c.TarefaId) + 1 : 1;
                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingtarefa = _tarefas.FirstOrDefault(c => c.TarefaId == tarefa.TarefaId);
                if (existingtarefa != null)
                {
                    existingtarefa.TarefaTitulo = tarefa.TarefaTitulo;
                    existingtarefa.Descricao = tarefa.Descricao;
                    existingtarefa.DataInicio = tarefa.DataInicio;
                    existingtarefa.DataFim = tarefa.DataFim;
                    existingtarefa.DataPrevistaFim = tarefa.DataPrevistaFim;
                    existingtarefa.Status = tarefa.Status;
                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Details(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult TarefasPendentes(List<Tarefa> tarefas)
        {
            return View(_tarefas);
        }

        public IActionResult TarefasConcluidas(List<Tarefa> tarefas)
        {
            return View(_tarefas);
        }
    }

}
