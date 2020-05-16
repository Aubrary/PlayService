using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;

namespace PlayService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase {

        private readonly PlayServiceContext _context;

        // Dependecy injection of PlayServiceContext
        public PlaylistsController(PlayServiceContext context) => _context =context;

        //Use API to get all playlists currently in the database.
        //GET: api/playlists
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> GetAllPlaylists() {
            return _context.Playlists;
        }

        //Use API to get a specific playlist by its id.
        //GET: api/playlists/n - where n is id
        [HttpGet("{id}")]
        public ActionResult<Playlist> GetPlaylistItem(Guid? id) {

            var playlistItem = _context.Playlists.Find(id);

            if (playlistItem == null) {
                return NotFound();
            }

            return playlistItem;
        }

        //Use API to add playlist to the database.
        //POST: api/playlists
        [HttpPost]
        public ActionResult<Playlist> PostSongsItem(Playlist playlist) {

            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return CreatedAtAction("GetPlaylistItem", new Playlist{id = playlist.id}, playlist);

        }

        //Use API to edit/replace existing playlist with id
        //PUT: api/playlists/n - where n is id
        [HttpPut]
        public ActionResult<Playlist> PutSongsItem(Guid? id, Playlist playlist) {

            if (id != playlist.id) {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }

        //Use API to delete a playlist from the database
        //DELETE: api/playlists/n - where n is song id
        [HttpDelete("{id}")]
        public ActionResult<Playlist> DeletePlaylistItem(Guid? id) {
            var playlistItem = _context.Playlists.Find(id);

            if(playlistItem == null) {
                return NotFound();
            }

            _context.Playlists.Remove(playlistItem);
            _context.SaveChanges();

            return playlistItem;
        }

    }

}