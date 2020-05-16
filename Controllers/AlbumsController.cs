using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;

namespace PlayService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase {

        private readonly PlayServiceContext _context;

        //Dependecy injection of PlayserviceContext
        public AlbumsController(PlayServiceContext context) => _context =context;

        //Use API to get all albums currently in the database
        //GET: api/albums
        public ActionResult<IEnumerable<Album>> GetAllAlbums() {
            return _context.Albums;
        }

        //Use API to get a specific album by its id.
        //GET: api/albums/n - where n is id
        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbumItem(Guid? id) {

            var albumItem = _context.Albums.Find(id);

            if (albumItem == null) {
                return NotFound();
            }

            return albumItem;
        }

        //Use API to add an album to the database
        //POST: api/albums
        [HttpPost]
        public ActionResult<Album> PostAlbumItem (Album album) {

            _context.Albums.Add(album);
            _context.SaveChanges();
            return CreatedAtAction("GetAlbumItem", new Album{Id = album.Id}, album);

        }

        //Use API to edit/replace an existing album with id
        //PUT: api/albums/n - where n is id
        public ActionResult<Album> PutAlbumItem(Guid? id, Album album) {

            if (id != album.Id) {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //USE API to delete an album from the database using id
        //DELETE: api/albums/n - where n is album id
        [HttpDelete("{id}")]
        public ActionResult<Album> DeleteAlbumItem(Guid? id) {

            var albumItem = _context.Albums.Find(id);

            if (albumItem == null) {
                return NotFound();
            }

            _context.Albums.Remove(albumItem);
            _context.SaveChanges();

            return albumItem;
        }

    }
}