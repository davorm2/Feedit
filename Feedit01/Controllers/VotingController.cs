using Feedit01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedit01.Controllers
{
    public class VotingController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Voting
        public ActionResult Index()
        {



            return RedirectToAction("Index", "Home");
        }
    }
}