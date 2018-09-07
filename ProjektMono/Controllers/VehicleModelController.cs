using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Project.Servis.Models;
using Project.Servis.Repositories;
using PagedList;

namespace ProjektMono.Controllers
{
	[Authorize]
	public class VehicleModelController : Controller
	{

		private IVehicleModelRepository VehicleModelRepository;

		public VehicleModelController()
		{
			this.VehicleModelRepository = new VehicleModelRepository(new Project.Servis.Repositories.VehicleMakeContext());
		}

		public VehicleModelController(IVehicleModelRepository VehicleModelRepository)
		{
			this.VehicleModelRepository = VehicleModelRepository;
		}



		// GET: VehicleModel 
		[AllowAnonymous]
		public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
		{
			ViewBag.CurrentSort = sortOrder;
			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var vehicles = from s in VehicleModelRepository.GetVehicles()
						   select s;

			if (!String.IsNullOrEmpty(searchString))
			{
				vehicles = vehicles.Where(s => s.Name.Contains(searchString)
									   || s.Abrv.Contains(searchString));
			}


			switch (sortOrder)
			{
				case "name_desc":
					vehicles = vehicles.OrderByDescending(s => s.Name);
					break;
				case "Abrv":
					vehicles = vehicles.OrderBy(s => s.Abrv);
					break;
				case "abrv_desc":
					vehicles = vehicles.OrderByDescending(s => s.Abrv);
					break;
				default:
					vehicles = vehicles.OrderBy(s => s.Name);
					break;
			}

			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return View(vehicles.ToPagedList(pageNumber, pageSize));


		}

		// GET: VehicleModel/Details/4
		[AllowAnonymous]
		public ActionResult Details(int id)
		{
			
			VehicleModel VehicleModel = VehicleModelRepository.GetVehicleByID(id);
			if (VehicleModel == null)
			{
				return HttpNotFound();
			}
			return View(VehicleModel);
		}

		//GET: VehicleModel/create
		public ActionResult Create()
		{
			return View();
		}

		// POST: VehicleModel/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(VehicleModel VehicleModel)
		{
			if (ModelState.IsValid)
			{
				VehicleModelRepository.InsertVehicle(VehicleModel);
				VehicleModelRepository.Save();
				return RedirectToAction("Index");
			}
			return View(VehicleModel);
		}

		// GET: VehicleModel/Edit/5
		public ActionResult Edit(int id)
		{
			
			VehicleModel VehicleModel = VehicleModelRepository.GetVehicleByID(id);
			if (VehicleModel == null)
			{
				return HttpNotFound();
			}
			return View(VehicleModel);

		}

		// POST: VehicleModel/Edit/2
		[HttpPost]
		public ActionResult Edit(VehicleModel VehicleModel)
		{
			if (ModelState.IsValid)
			{
				VehicleModelRepository.UpdateVehicle(VehicleModel);
				VehicleModelRepository.Save();
				return RedirectToAction("Index");
			}
			return View(VehicleModel);
		}

		// GET: VehicleModel/Delete/2
		public ActionResult Delete(int id)
		{
			
			VehicleModel VehicleModel = VehicleModelRepository.GetVehicleByID(id);

			if (VehicleModel == null)
			{
				return HttpNotFound();
			}
			return View(VehicleModel);
		}

		//POST: VehicleModel/Delete/2
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				VehicleModel VehicleModel = VehicleModelRepository.GetVehicleByID(id);
				VehicleModelRepository.DeleteVehicle(id);
				VehicleModelRepository.Save();
			}
			catch (DataException /* dex */)
			{
				//Log the error (uncomment dex variable name after DataException and add a line here to write a log.
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
			}
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			VehicleModelRepository.Dispose();
			base.Dispose(disposing);
		}
	}



}
