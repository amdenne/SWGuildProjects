using BaseballLeague.BLL;
using BaseballLeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballLeague.Controllers
{
    public class HomeController : Controller
    {
        IBaseballLeagueManager _manager;
        public HomeController(IBaseballLeagueManager manager)
        {
            _manager = manager;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult NewTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TeamConfrim(Team team)
        {
            if (ModelState.IsValid)
            {
                var response = _manager.CreateTeam(team);

                return View();
            }
            return View("NewTeam");
        }
        
        public ActionResult NewPlayer()
        {

            return View();
        }
        public ActionResult ViewTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TeamDropdown()
        {
            var response = _manager.GetAllTeams();

            return Json(response.Data);
        }
        [HttpPost]
        public ActionResult PlayerConfirm(Player player)
        {
            if (ModelState.IsValid)
            {
                var response = _manager.CreatePlayer(player);

                return View();
            }
            return View("NewPlayer");
        }
        [HttpPost]
        public ActionResult ViewPlayers(int Teamid)
        {
            var response = _manager.GetAllPlayersInTeam(Teamid);

            return PartialView("ViewRoster", response.Data);

        }
    }
}