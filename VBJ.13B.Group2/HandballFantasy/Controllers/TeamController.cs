﻿using HandballFantasy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandballFantasy.Controllers
{
    public class TeamController : Controller
    {
        private static Team team;

        private static string[] firstNames =
        {
            "Mikkel",
            "Nikola",
            "Sander",
            "Arpad",
            "Kiril",
            "Anita",
            "Domagoj",
            "Nora",
            "Thierry",
        };

        private static string[] lastNames =
{
            "Hansen",
            "Karabatic",
            "Sagosen",
            "Sterbik",
            "Lazarov",
            "Görbicz",
            "Duvnjak",
            "Mork",
            "Omeyer",
        };

        private static Random rnd = new Random();

        public IActionResult Index(int id)
        {
            team = HomeController.teams.FirstOrDefault(x => x.ID == id);
            return View(team);
        }

        public IActionResult Create()
        {
            int id = team.Players.Any() ? team.Players.Last().ID + 1 : 1;
            int jerseyNumber = rnd.Next(1, 100);

            // Addig generálunk random számot amíg senkinek sincs ilyen mezszáma a csapatban
            while (team.Players.Any(x => x.JerseyNumber == jerseyNumber))
            {
                jerseyNumber = rnd.Next(1, 100);
            }
            team.Players.Add(new Player()
            {
                ID = id,
                FirstName = firstNames[rnd.Next(0, firstNames.Length)],
                LastName = lastNames[rnd.Next(0, lastNames.Length)],
                Age = rnd.Next(18, 36),
                JerseyNumber = jerseyNumber,
            });

            return View("Index", team);
        }
    }
}
