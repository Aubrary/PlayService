using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;

namespace PlayService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase {

        private readonly PlayServiceContext _context;

        // Dependecy injection of PlayServiceContext
        public GenresController(PlayServiceContext context) => _context =context;

        //Use API to get all genres from the database
        //GET: api/genres
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetAllGenres() {
            return _context.Genres;
        }

        //Use API to get specific genre by id
        //GET: api/genres
        public ActionResult<Genre> GetGenreItem(Guid? id) {
            var genreItem = _context.Genres.Find(id);

            if (genreItem == null) {
                return NotFound();
            }

            return genreItem;
        }

        /*
        //Use API to get specific genre by name
        //GET: api/genres
        public ActionResult<Genre> GetGenreName(string name) {
            var genreName = _context.GenresItem.Find(name);

            if (genreName == null) {
                return NotFound();
            }

            return genreName;
        }
        */

        //Use API to add a genre to the database
        //POST: api/genres
        [HttpPost]
        public ActionResult<Genre> PostGenresItem(Genre genre) {

            _context.Genres.Add(genre);
            _context.SaveChanges();
            return CreatedAtAction("GetGenreItem", new Genre{id = genre.id}, genre);
        }

        //Use API to edit/replace existing genre with id
        //PUT: api/genres/n - where n is id
        [HttpPut]
        public ActionResult<Genre> PutGenresItem(Guid? id, Genre genre) {

            if (id != genre.id) {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }

        //Use API to delete a genre from the database
        //DELETE: api/genres/n - where n is genre id
        [HttpDelete("{id}")]
        public ActionResult<Genre> DeleteGenresItem(Guid? id) {
            var genreItem = _context.Genres.Find(id);

            if(genreItem == null) {
                return NotFound();
            }

            _context.Genres.Remove(genreItem);
            _context.SaveChanges();

            return genreItem;
        }
    }
    
}