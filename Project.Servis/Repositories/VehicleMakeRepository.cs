using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Project.Servis.Models;

namespace Project.Servis.Repositories
{
	public class VehicleMakeRepository : IVehicleMakeRepository, IDisposable
	{
		private VehicleMakeContext context;

		public VehicleMakeRepository(VehicleMakeContext context)
		{
			this.context = context;
		}

		public IEnumerable<VehicleMake> GetVehicles()
		{
			return context.Vehicles.ToList();
		}

		public VehicleMake GetVehicleByID(int id)
		{
			return context.Vehicles.Find(id);
		}

		public void InsertVehicle(VehicleMake vehicle)
		{
			context.Vehicles.Add(vehicle);
		}

		public void DeleteVehicle(int vehicleID)
		{
			VehicleMake vehicle = context.Vehicles.Find(vehicleID);
			context.Vehicles.Remove(vehicle);
		}

		public void UpdateVehicle(VehicleMake vehicle)
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