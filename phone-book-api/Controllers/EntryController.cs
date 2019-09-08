using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace phone_book_api.Controllers
{
    [Route("api/entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public EntryController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllEntries()
        {
            try
            {
                var entries = _repository.Entry.GetAllEntries();
                return Ok(entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

        [HttpGet("{id}", Name = "EntryById")]
        public IActionResult GetEntryById(Guid id)
        {
            try
            {
                var entry = _repository.Entry.GetEntryById(id);
                if (entry.EntryId.Equals(Guid.Empty))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(entry);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

        [HttpPost]
        public IActionResult CreateEntry([FromBody]Entry entry)
        {
            try
            {
                if (entry == null)
                {
                    return BadRequest("Entry object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                _repository.Entry.CreateEntry(entry);
                _repository.Save();

                return CreatedAtRoute("EntryById", new { id = entry.EntryId }, entry);

            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Internal server error: {0}", ex.Message));
            }
        }

    }
}
