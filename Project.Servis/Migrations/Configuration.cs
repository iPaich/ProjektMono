namespace Project.Servis.Migrations
{
	using Project.Servis.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Project.Servis.Models.VehicleMakeContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(VehicleMakeContext context)
		{
			var vehicles = new List<VehicleMake>
			{
				new VehicleMake {
					Name = "Bavarian Motor Works",
					Abrv = "BMW"
				},
				new VehicleMake {
					Name = "Anonima Lombarda Fabbrica Automobili",
					Abrv = "Alfa Romeo"
				},
				new VehicleMake {
					Name = "Fabbrica Italiana Automobili Torino ",
					Abrv = "Fiat"
				},
				new VehicleMake {
					Name = "Volkswagen",
					Abrv = "VW"
				},
				new VehicleMake {
					Name = "Ferrari",
					Abrv = "Ferrari"
				}
			};
			vehicles.ForEach(s => context.VehicleMake.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var vehicleModels = new List<VehicleModel>
			{
				new VehicleModel {
					Name = "BMW",
					Abrv = "X5"
				},
				new VehicleModel {
					Name = "Alfa Romeo",
					Abrv = "Crveni"
				},
				new VehicleModel {
					Name = "Fiat ",
					Abrv = "Uno"
				},
				new VehicleModel {
					Name = "Volkswagen",
					Abrv = "Polo"
				},
				new VehicleModel {
					Name = "Ferrari",
					Abrv = "Spider"
				}
			};
			vehicleModels.ForEach(s => context.VehicleModels.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();
		}

	}
}
