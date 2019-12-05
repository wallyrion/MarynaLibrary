using System.Collections.Generic;
using AutoMapper;
using Library.BL.Interfaces;
using Library.BL.Models;
using Library.DAL.Interfaces;

namespace Library.BL.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IRepository<DAL.Models.Reader> _readerRepository;
        private readonly IMapper _mapper;

        public ReaderService(IRepository<DAL.Models.Reader> readerRepository, IMapper mapper)
        {
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public List<Reader> GetAll()
        {
            var readers = _readerRepository.GetAll();
            var models = _mapper.Map<List<Reader>>(readers);

            return models;
        }

        public void Remove(int id)
        {
            _readerRepository.Remove(id);
        }

        public int Create(Reader reader)
        {
            var entity = _mapper.Map<DAL.Models.Reader>(reader);

            return _readerRepository.Create(entity);
        }

        public void Edit(Reader reader)
        {
            var entity = _mapper.Map<DAL.Models.Reader>(reader);

            _readerRepository.Update(entity);
        }
    }
}