using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using selebre.Concerns.Models;
using selebre.Concerns.Models.ViewModels;

namespace Selebre.Concerns.Models.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminView, Employee>().ReverseMap();
        }
    }
}
