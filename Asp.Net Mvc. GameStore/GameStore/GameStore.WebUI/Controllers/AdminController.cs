using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IGameRepository repository;
        
        public AdminController(IGameRepository repo)
        {            
            repository = repo;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Games);
        }


        public ViewResult Edit(int gameId)
        {
            Game model = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);
            return View(model);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(game);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", game.Name); // Объект TempData - его отличие основное от данных сеанса в том, что в конце HTTP-запроса объект TempData удаляется.
                return RedirectToAction("Index"); // Если все в порядке, мы сохраняем изменения в хранилище и вызываем метод действия Index() для возвращения пользователю списка товаров
                //Объект ViewBag передает данные между контроллером и представлением, и он не может удерживать данные дольше, чем длится HTTP-запрос
                //Ми могли бы воспользоваться средством данных сеанса, но тогда сообщение хранилось бы вплоть до его явного удаления, что мы предпочитаем не делать.
            }
            else
            {
                // Что-то не так со значениями данных
                return View(game);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Game());
        }

        [HttpPost]
        public ActionResult Delete(int gameId)
        {
            Game deletedGame = repository.DeleteGame(gameId);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}