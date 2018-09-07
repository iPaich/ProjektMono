using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.Servis.Models;

namespace Project.Servis.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}

	public class VehicleMakeContext : IdentityDbContext<ApplicationUser>
	{
		public VehicleMakeContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static VehicleMakeContext Create()
		{
			return new VehicleMakeContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehicleMake>()
				.ToTable("VehicleMake");
			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<VehicleMake> VehicleMake { get; set; }
		public virtual DbSet<VehicleModel> VehicleModels { get; set; }
	}
}