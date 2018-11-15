using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.UnitTests
{
    [TestClass]
    public class NavTests
    {
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Организация - создание имитированного хранилища
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game> {
        new Game { GameId = 1, Name = "Игра1", Category="Симулятор"},
        new Game { GameId = 2, Name = "Игра2", Category="Симулятор"},
        new Game { GameId = 3, Name = "Игра3", Category="Шутер"},
        new Game { GameId = 4, Name = "Игра4", Category="RPG"},
    });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Действие - получение набора категорий
            List<string> results = ((IEnumerable<string>)target.Menu().Model).ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 3);
            Assert.AreEqual(results[0], "RPG");
            Assert.AreEqual(results[1], "Симулятор");
            Assert.AreEqual(results[2], "Шутер");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Организация - создание имитированного хранилища
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new Game[] {
        new Game { GameId = 1, Name = "Игра1", Category="Симулятор"},
        new Game { GameId = 2, Name = "Игра2", Category="Шутер"}
    });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Организация - определение выбранной категории
            string categoryToSelect = "Шутер";

            // Действие
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Утверждение
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
