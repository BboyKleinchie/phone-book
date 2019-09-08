using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace phone_book_api.Controllers
{
    [Route("api/phonebook")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public PhoneBookController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllPhoneBooks()
        {
            try
            {
                var phoneBooks = _repository.PhoneBook.GetAllPhoneBooks();
                return Ok(phoneBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

        [HttpGet("{id}", Name = "PhoneBookById")]
        public IActionResult GetPhoneBookById(Guid id)
        {
            try
            {
                var phoneBook = _repository.PhoneBook.GetPhoneBookById(id);
                if (phoneBook.PhoneBookId.Equals(Guid.Empty))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(phoneBook);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

        [HttpGet("{id}/entries")]
        public IActionResult GetPhoneBookWithEntries(Guid id)
        {
            try
            {
                var phoneBook = _repository.PhoneBook.GetPhoneBookWithEntries(id);

                if (phoneBook.Id.Equals(Guid.Empty))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(phoneBook);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

        [HttpPost]
        public IActionResult CreatePhoneBook([FromBody]PhoneBook phoneBook)
        {
            try
            {
                if(phoneBook == null)
                {
                    return BadRequest("Phone Book object is null");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                _repository.PhoneBook.CreatePhoneBook(phoneBook);
                _repository.Save();

                return CreatedAtRoute("PhoneBookById", new { id = phoneBook.PhoneBookId }, phoneBook);

            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }
        
    }
}
