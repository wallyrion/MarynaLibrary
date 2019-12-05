﻿using System.Collections.Generic;
using AutoMapper;
using Library.BL.Interfaces;
using Library.BL.Models;
using Library.DAL.Interfaces;

namespace Library.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<DAL.Models.Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<DAL.Models.Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<Book> GetAll()
        {
            var books = _bookRepository.GetAll();
            var bookModels = _mapper.Map<List<Book>>(books);

            return bookModels;
        }

        public void Remove(int id)
        {
            _bookRepository.Remove(id);
        }

        public int Create(Book bookModel)
        {
            var book = _mapper.Map<DAL.Models.Book>(bookModel);
            var id = _bookRepository.Create(book);

            return id;
        }

        public void Edit(Book bookModel)
        {
            var book = _mapper.Map<DAL.Models.Book>(bookModel);
            _bookRepository.Update(book);
        }
    }
}