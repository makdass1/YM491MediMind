
using App.Repository.Entities;
using App.Service.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReminderCreateInputModel, Reminder>();
            CreateMap<Reminder, ReminderCreateOutputModel>();
            CreateMap<Reminder, ReminderListOutputModel>().ReverseMap();
          

        }
    }
}