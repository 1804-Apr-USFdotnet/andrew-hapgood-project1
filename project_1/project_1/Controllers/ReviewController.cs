using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using project_1.Models;

namespace project_1.Controllers
{
	public class ReviewController : Controller
	{
		// GET: Review
		public ActionResult Index()
		{
			ViewBag.message = "Review Page";
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(review rev)
		{
			var crud = new DataAccess();
			crud.AddReview(rev.name, rev.score, rev.message, rev.rest_id);
			// do this see if it crashes
			//var temp = crud.GetReviews(3);
			return RedirectToAction("Index", "Review");
		}

		public ActionResult Delete()
		{
			return View();
		}

		public ActionResult Delete(int id)
		{
			var crud = new DataAccess();
			return View();

		}

		public ActionResult Edit()
		{
			return View();
		}

		public ActionResult Read()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Read(int id)
		{
			var crud = new DataAccess();
			var temp = crud.GetReviews(id);
			return View(temp);
		}
	}
}