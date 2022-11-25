using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Business.Interfaces;
using ThirdWeekHomework.Data.DTOs;
using ThirdWeekHomework.Data.Interfaces;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Business.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IDapperRepository<Book> _dapperrepository;

        public LibraryService(IDapperRepository<Book> dapperrepository)
        {
            _dapperrepository = dapperrepository;
        }

        public async Task<IReadOnlyList<Book>> GetAll()
        {
           return await _dapperrepository.GetAll();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _dapperrepository.GetById(id);
        }

        public void Add(Book book)
        {           
            _dapperrepository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _dapperrepository.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _dapperrepository.Delete(book.Id);
        }
    }
}
