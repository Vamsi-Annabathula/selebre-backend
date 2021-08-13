using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using selebre.Concerns.Models;
using selebre.Concerns.Models.ViewModels;

namespace Selebre.Concerns.Models.Profiles
{
    public class AdminSettingsProfile : Profile
    {
        public AdminSettingsProfile()
        {
            CreateMap<AdminSettingsView, AdminSettings>().ReverseMap();
        }
    }
}
