using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Domain;
using BaseballLeague.BLL;

namespace BaseballLeague.Controllers
{
    public class TradeController : Controller
    {
        IBaseballLeagueManager _manager;
        public TradeController(IBaseballLeagueManager manager)
        {
            _manager = manager;
        }
        // GET: Trade
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeamDropdown()
        {
            var response = _manager.GetAllTeams();

            return Json(response.Data);
        }
        [HttpPost]
        public ActionResult CreatePlayerDropdown(int TeamID)
        {
            var response = _manager.GetAllPlayersInTeam(TeamID);

            return Json(response.Data);
        }
        [HttpPost]
        public ActionResult ProcessTrade(TradePlayer player)
        {
            if (ModelState.IsValid)
            {
                var response = _manager.TradePlayer(player);
                return View("TradeConfirm");
            }
            return View("Index");
        }
    }
}