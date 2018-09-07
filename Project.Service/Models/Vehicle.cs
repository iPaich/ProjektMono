using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
	public class VehicleMake
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "Your name must contain less than 50 characters")]
		public string Name { get; set; }
		[Required]
		[StringLength(25)]
		public string Abrv { get; set; }

	}

	public class VehicleModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int MakeId { get; set; }
		[ForeignKey("MakeId")]
		public VehicleMake VehicleMake { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "Your name must contain less than 50 characters")]
		public string Name { get; set; }
		[Required]
		[StringLength(25)]
		public string Abrv { get; set; }

	}
}