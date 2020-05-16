using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;

namespace PlayService.Controllers {
    [Route("api/controller")]
    [ApiController]
    public class ArtistsController : ControllerBase {

        private readonly PlayServiceContext _context;

        //Dependecy injection of PlayServiceContext
        public ArtistsController(PlayServiceContext context) => _context =context;

        //Use API to get all artists currently in the database
        //GET: api/artists
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetAllArtists() {
            return _context.Artists;
        }

        //Use API to get a specific artist by its id.
        //GET: api/artists/n - where n is id
        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtistItem(Guid? id) {

            var artistItem = _context.Artists.Find(id);

            if (artistItem == null) {
                return NotFound();
            }

            return artistItem;
        }

        //Use API to add an artist to the database.
        //POST: api/artists
        [HttpPost]
        public ActionResult<Artist> PostArtistItem(Artist artist) {

            _context.Artists.Add(artist);
            _context.SaveChanges();
            return CreatedAtAction("GetArtistsItem", new Artist{id = artist.id}, artist);

        }

        //Use API to edit/replace artist using id
        //PUT: api/artists/n - where n is id
        [HttpPut]
        public ActionResult<Artist> PutArtistItem(Guid? id, Artist artist) {

            if (id != artist.id) {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }

        //Use API to delete an artist from the database.
        //DELETE: api/songs/n - where n is song id
        [HttpDelete("{id}")]
        public ActionResult<Artist> DeleteArtistItem(Guid? id) {

            var artistItem = _context.Artists.Find(id);

            if(artistItem == null) {
                return NotFound();
            }

            _context.Artists.Remove(artistItem);
            _context.SaveChanges();

            return artistItem;

        }


    }

}