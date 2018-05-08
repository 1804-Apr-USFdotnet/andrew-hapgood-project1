using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using project_1.Models;

namespace project_1.Controllers
{
	public class RestuarantController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.message = "Restuarant Page";

			var crud = new DataAccess();
			var temp = crud.GetRestuarants();

			return View(temp);
		}

		[HttpGet]
		public ActionResult Index(string sort)
		{
			//var new_crud = new DataAccess();
			//new_crud.UpdateDB();

			var crud = new DataAccess();
			ViewBag.message = "sorting";
			var temp = crud.GetRestuarants();

			switch (sort)
			{
				case "a":
					temp = temp.OrderBy(x => x.name);
					break;
				case "z":
					temp = temp.OrderByDescending(x => x.name);
					break;
				case "n":
					temp = temp.OrderBy(x => x.rating);
					break;
				default:
					// something bad happened
					break;
			}

			return View(temp);
		}

		public ActionResult Create()
		{
			return View();
		}

		public ActionResult Edit(int id)
		{
			var crud = new DataAccess();
			var temp = crud.GetRestuarants().Where(x => x.id == id).First();
			ViewBag.message = "Edit Page";
			return View(temp);
		}


		[HttpPost]
		public ActionResult Create(restuarant rest)
		{
			try
			{
				var crud = new DataAccess();
				crud.AddRestuarant(rest.name, rest.address);
				return RedirectToAction("Index", "Restuarant");
			}
			catch
			{
				return RedirectToAction("Index", "Restuarant");
			}
		}

		[HttpPost]
		public ActionResult Update(restuarant rest)
		{
			// update database and return to index
			var crud = new DataAccess();
			crud.UpdateRest(rest);
			return RedirectToAction("Index", "Restuarant");
			//return Content(rest.id.ToString() + " " + rest.name + rest.address);
		}

		public ActionResult Delete(int id)
		{
			var crud = new DataAccess();
			crud.DeleteRestuarant(id);
			return RedirectToAction("Index", "Restuarant");
		}


	}
}