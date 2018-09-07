using System;
using System.Collections.Generic;
using Project.Servis.Models;

namespace Project.Servis.Repositories
{
	public interface IVehicleModelRepository : IDisposable
	{
		IEnumerable<VehicleModel> GetVehicles();
		VehicleModel GetVehicleByID(int vehicleId);
		void InsertVehicle(VehicleModel vehicle);
		void DeleteVehicle(int vehicleId);
		void UpdateVehicle(VehicleModel vehicle);
		void Save();
	}
}