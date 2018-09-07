namespace Project.Service1.Migrations
{
	using Project.Service.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Project.Service.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(Project.Service.Models.ApplicationDbContext context)
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
		}

	}
}
