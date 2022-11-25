using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdWeekHomework.Business.Interfaces;
using ThirdWeekHomework.Data.DTOs;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService libraryService, IMapper mapper)
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }
        [Route("InsertBook")]
        [HttpPost]
        public IActionResult AddBook(BookDTO bookDTO)
        {

            var mappedModel = _mapper.Map<Book>(bookDTO);
            mappedModel.CreatedBy = Guid.NewGuid();
            mappedModel.CreatedDate = System.DateTime.Now;            

            _libraryService.Add(mappedModel);
            return Ok("Success");
        }
        [Route("GetBookById")]
        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _libraryService.GetBookById(id);
            return Ok(result);
        }
        
        [Route("GetAllBooks")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _libraryService.GetAll();
            return Ok(result);
        }

        [Route("UpdateBook")]
        [HttpPut]
        public IActionResult UpdateBook(BookDTO book)
        {

            var mappedModel = _mapper.Map<Book>(book);
            mappedModel.ModifiedDate = System.DateTime.Now;
            _libraryService.UpdateBook(mappedModel);
            return Ok("Success");
        }

        [Route("DeleteBook")]
        [HttpDelete]
        public IActionResult DeleteBook(Book book)
        {
            _libraryService.DeleteBook(book);
            return Ok("Succes");
        }
    }
}
