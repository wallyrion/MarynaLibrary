using AutoMapper;
using Library.DAL.Dapper.Models;

namespace Library.WebApi.Infrastructure
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