using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiData.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyLogiscool.Data.Owners, LogiData.Web.Models.Owner>().
                ForMember(dest => dest.ID, map => map.MapFrom(src => src.Owner_Id)).
                ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name)).
                ForMember(dest => dest.City, map => map.MapFrom(src => src.City)).
                ForMember(dest => dest.StartYear, map => map.MapFrom(src => src.StartYear)).
                ForMember(dest => dest.HasPaidThisYear, map => map.MapFrom(src => src.HasPaidThisYear)).
                ForMember(dest => dest.IsReplaceable, map => map.MapFrom(src => src.IsReplaceable));

                cfg.CreateMap<LogiData.Web.Models.Owner, MyLogiscool.Data.Owners>().
                ForMember(dest => dest.Owner_Id, map => map.MapFrom(src => src.ID)).
                ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name)).
                ForMember(dest => dest.City, map => map.MapFrom(src => src.City)).
                ForMember(dest => dest.StartYear, map => map.MapFrom(src => src.StartYear)).
                ForMember(dest => dest.HasPaidThisYear, map => map.MapFrom(src => src.HasPaidThisYear)).
                ForMember(dest => dest.IsReplaceable, map => map.MapFrom(src => src.IsReplaceable));
            });
            return config.CreateMapper();
        }
    }
}