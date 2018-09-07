using System;
using System.Collections.Generic;
using Project.Servis.Models;

namespace Project.Servis.Repositories
{
	public interface IVehicleMakeRepository : IDisposable
	{
		IEnumerable<VehicleMake> GetVehicles();
		VehicleMake GetVehicleByID(int vehicleId);
		void InsertVehicle(VehicleMake vehicle);
		void DeleteVehicle(int vehicleId);
		void UpdateVehicle(VehicleMake vehicle);
		void Save();
	}
}