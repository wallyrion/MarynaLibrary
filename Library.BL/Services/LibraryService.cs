using System.Collections.Generic;
using AutoMapper;
using Library.BL.Interfaces;
using Library.BL.Models;
using Library.DAL.Interfaces;

namespace Library.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly IMapper _mapper;

        public LibraryService(ILibraryCardRepository libraryCardRepository, IMapper mapper)
        {
            _libraryCardRepository = libraryCardRepository;
            _mapper = mapper;
        }

        public int Create(LibraryCard cardModel)
        {
            var card = _mapper.Map<DAL.Models.LibraryCard>(cardModel);
            var id = _libraryCardRepository.Create(card);

            return id;
        }

        public List<LibraryCard> GetAll()
        {
            var cards = _libraryCardRepository.GetAll();
            var cardsModels = _mapper.Map<List<LibraryCard>>(cards);

            return cardsModels;
        }

        public void ReturnBook(int id)
        {
            _libraryCardRepository.Update(id);
        }
    }
}