using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Project.Servis.Models;

namespace Project.Servis.Repositories
{
	public class VehicleModelRepository : IVehicleModelRepository, IDisposable
	{
		private VehicleMakeContext context;

		public VehicleModelRepository(VehicleMakeContext context)
		{
			this.context = context;
		}

		public IEnumerable<VehicleModel> GetVehicles()
		{
			return context.VehicleModels.ToList();
		}

		public VehicleModel GetVehicleByID(int id)
		{
			return context.VehicleModels.Find(id);
		}

		public void InsertVehicle(VehicleModel vehicle)
		{
			context.VehicleModels.Add(vehicle);
		}

		public void DeleteVehicle(int vehicleID)
		{
			VehicleModel vehicle = context.VehicleModels.Find(vehicleID);
			context.VehicleModels.Remove(vehicle);
		}

		public void UpdateVehicle(VehicleModel vehicle)
		{
			context.Entry(vehicle).State = EntityState.Modified;
		}

		public void Save()
		{
			context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

	}
}