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
	public class VehicleMakeController : Controller
	{

		private IVehicleMakeRepository VehicleMakeRepository;

		public VehicleMakeController()
		{
			this.VehicleMakeRepository = new VehicleMakeRepository(new Project.Servis.Repositories.VehicleMakeContext());
		}

		public VehicleMakeController(IVehicleMakeRepository VehicleMakeRepository)
		{
			this.VehicleMakeRepository = VehicleMakeRepository;
		}


		// GET: VehicleMake
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

			var vehicles = from s in VehicleMakeRepository.GetVehicles()
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

			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(vehicles.ToPagedList(pageNumber, pageSize));


		}

		// GET: VehicleMake/Details/4
		[AllowAnonymous]
		public ActionResult Details(int id)
		{

			VehicleMake vehicleMake = VehicleMakeRepository.GetVehicleByID(id);
			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);
		}

		//GET: VehicleMake/create
		public ActionResult Create()
		{
			return View();
		}

		// POST: VehicleMake/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(VehicleMake vehicleMake)
		{
			if (ModelState.IsValid)
			{
				VehicleMakeRepository.InsertVehicle(vehicleMake);
				VehicleMakeRepository.Save();
				return RedirectToAction("Index");
			}
			return View(vehicleMake);
		}

		// GET: VehicleMake/Edit/5
		public ActionResult Edit(int id)
		{

			VehicleMake vehicleMake = VehicleMakeRepository.GetVehicleByID(id);
			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);

		}

		// POST: VehicleMake/Edit/2
		[HttpPost]
		public ActionResult Edit(VehicleMake vehicleMake)
		{
			if (ModelState.IsValid)
			{
				VehicleMakeRepository.UpdateVehicle(vehicleMake);
				VehicleMakeRepository.Save();
				return RedirectToAction("Index");
			}
			return View(vehicleMake);
		}

		// GET: VehicleMake/Delete/2
		public ActionResult Delete(int id)
		{

			VehicleMake vehicleMake = VehicleMakeRepository.GetVehicleByID(id);

			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);
		}

		//POST: VehicleMake/Delete/2
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				VehicleMake vehicleMake = VehicleMakeRepository.GetVehicleByID(id);
				VehicleMakeRepository.DeleteVehicle(id);
				VehicleMakeRepository.Save();
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
			VehicleMakeRepository.Dispose();
			base.Dispose(disposing);
		}
	}



}
