using Project.Servis.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Servis.Repositories
{
	public class VehicleMakeContext : DbContext
	{
		public DbSet<VehicleMake> Vehicles { get; set; }
		public DbSet<VehicleModel> VehicleModels { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}