using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GatewayManager.Domain.Models;
using GatewayManager.DTO;

namespace GatewayManager.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Gateway, GatewayDTO>();
            CreateMap<PeripheralDevice, PeripheralInGatewayDTO>();
            CreateMap<PeripheralDevice, PeripheralDeviceDTO>();

            CreateMap<EDeviceStatus, string>().ConvertUsing(new PeripheralStatusToStringConverter());
            CreateMap<DateTime, string>().ConvertUsing(new DateToStringConverter());
        }

        class PeripheralStatusToStringConverter : ITypeConverter<EDeviceStatus, string>
        {
            public string Convert(EDeviceStatus source, string destination, ResolutionContext context)
            {
                return source.ToString();
            }
        }

        class DateToStringConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToShortDateString();
            }
        }
    }
}