using Microsoft.AspNetCore.Mvc;
using BlogTemporario.Models;

namespace BlogTemporario.Controllers
{
    public class BlogController : Controller
    {
        // Lista de mensagens armazenada em memória
        private static List<Message> messages = new List<Message>();
        private static int nextId = 1;

        // Exibe a lista de mensagens
        public IActionResult Index()
        {
            return View(messages);
        }

        // Adiciona uma nova mensagem
        [HttpPost]
        public IActionResult Add(string content)
        {
            messages.Add(new Message { Id = nextId++, Content = content });
            return RedirectToAction("Index");
        }

        // Remove uma mensagem
        public IActionResult Delete(int id)
        {
            messages.RemoveAll(m => m.Id == id);
            return RedirectToAction("Index");
        }

        // Carrega o formulário de edição
        public IActionResult Edit(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message == null) return NotFound();
            return View(message);
        }

        // Atualiza a mensagem
        [HttpPost]
        public IActionResult Update(int id, string content)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                message.Content = content;
            }
            return RedirectToAction("Index");
        }
    }
}
