using AutoMapper;
using Project.Servis.Models;

public static class AutoMapperConfig
{
	public static void RegisterMappings()
	{
		Mapper.Initialize(cfg => cfg.CreateMap<VehicleMake, VehicleModel>());
	}
}