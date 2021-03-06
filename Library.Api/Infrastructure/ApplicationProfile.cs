﻿using AutoMapper;
using Library.DAL.Models;

namespace Library.Api.Infrastructure
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Book, BL.Models.Book>().ReverseMap();
            CreateMap<Reader, BL.Models.Reader>().ReverseMap();
            CreateMap<LibraryCard, BL.Models.LibraryCard>().ReverseMap();
        }
    }
}