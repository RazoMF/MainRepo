using GameStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGameRepository repository;

        public NavController(IGameRepository repo) //добавление конструктора, 
                                                   //который принимает в качестве своего аргумента реализацию IGameRepository. 
                                                   //Результатом является объявление зависимости, которую Ninject 
                                                   //будет распознавать при создании экземпляров класса NavController
        {
            repository = repo;
        }

        public /*ActionResult*/string Menu2()
        {
            //var model = "Тестируем контроллер Nav";
            return "Тестируем контроллер Nav";//View("Menu", model);
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Games
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
            //var model = "Тестируем контроллер Nav";            
        }
    }
}   