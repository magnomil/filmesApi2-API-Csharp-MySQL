using AutoMapper;
using filmesApi2.Controllers.Models;
using filmesApi2.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmesApi2.Profiles
{
    public class FilmesProfiles : Profile
    {
        public FilmesProfiles()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto,Filme>();
        }
        
    }
}
