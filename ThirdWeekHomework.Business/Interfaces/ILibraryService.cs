using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Data.DTOs;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Business.Interfaces
{
    public interface ILibraryService
    {
        Task<IReadOnlyList<Book>> GetAll();
        Task<Book> GetBookById(int id); 
        void Add(Book bookDTO);
        void UpdateBook(Book bookDTO);
        void DeleteBook(Book book);        
    }
}
