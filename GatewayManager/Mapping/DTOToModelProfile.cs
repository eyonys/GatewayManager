using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GatewayManager.DTO;
using GatewayManager.Domain.Models;

namespace GatewayManager.Mapping
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<SaveGatewayDTO, Gateway>();
            CreateMap<GatewayDTO, Gateway>();
            CreateMap<SavePeripheralDTO, PeripheralDevice>();

            CreateMap<string, EDeviceStatus>().ConvertUsing(new PeripheralStatusFromStringConverter());
            CreateMap<string, DateTime>().ConvertUsing(new DateFromStringConverter());
        }

        class PeripheralStatusFromStringConverter : ITypeConverter<string, EDeviceStatus>
        {
            public EDeviceStatus Convert(string value, EDeviceStatus status, ResolutionContext context)
            {
                switch (value)
                {
                    case "Online":
                        return EDeviceStatus.Online;
                    default:
                        return EDeviceStatus.Offline;
                }
            }
        }
        class DateFromStringConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return DateTime.Parse(source);
            }
        }
    }
}

