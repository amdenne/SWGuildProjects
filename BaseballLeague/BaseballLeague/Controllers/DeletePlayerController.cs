using BaseballLeague.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballLeague.Controllers
{
    public class DeletePlayerController : Controller
    {
        IBaseballLeagueManager _manager;

        public DeletePlayerController(IBaseballLeagueManager manager)
        {
            _manager = manager;
        }
        // GET: DeletePlayer
        public ActionResult Index()
        {
            var response = _manager.GetALLPlayers().Data;

            return View(response);
        }

        [HttpPost]
        public ActionResult Delete(int PlayerID)
        {
            var response = _manager.DeletePlayer(PlayerID);

            return Json(new { route = "/DeletePlayer/Index" });
        }
          
    }
}