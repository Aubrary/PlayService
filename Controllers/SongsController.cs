using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;
using System.Linq;

namespace PlayService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase {

        private readonly PlayServiceContext _context;

        // Dependecy injection of PlayServiceContext
        public SongsController(PlayServiceContext context) => _context =context;

        //Use API to get all songs currently in the database.
        //GET: api/songs
        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetAllSongs() {
            return _context.Songs;
        }

        //Use API to get a specific song by its id.
        //GET: api/songs/n - where n is id
        [HttpGet("{id}")]
        public ActionResult<Song> GetSongItem(Guid? id) {

            var SongsItem = _context.Songs.Find(id);

            if (SongsItem == null) {
                return NotFound();
            }

            return SongsItem;
        }

        //Use API to add song to the database.
        //POST: api/songs
        [HttpPost]
        public ActionResult<Song> PostSongsItem(Song song) {

            var entity = MapToEntity(song);

            _context.Songs.Add(entity);
            _context.SaveChanges();
            return CreatedAtAction("GetSongItem", new Song{Id = entity.Id}, entity);

        }

        //Use API to edit/replace existing song with id
        //PUT: api/songs/n - where n is id
        [HttpPut]
        public ActionResult<Song> PutSongsItem(Guid id, Song song) {

            if (id != song.Id) {
                return BadRequest();
            }

            var entity = _context.Songs.First(e => e.Id == id);
            MapToEntity(song, entity);

            _context.SaveChanges();

            return NoContent();

        }

        //Use API to delete song from the database
        //DELETE: api/songs/n - where n is song id
        [HttpDelete("{id}")]
        public ActionResult<Song> DeleteSongsItem(Guid? id) {
            var songItem = _context.Songs.Find(id);

            if(songItem == null) {
                return NotFound();
            }

            _context.Songs.Remove(songItem);
            _context.SaveChanges();

            return songItem;
        }

        public Song MapToEntity(Song song, Song entity = null){
            if(entity == null){
                entity = new Song();
            }

            var artistExists = _context.Artists.Any(e => e.Id == song.ArtistId);
            if(!artistExists){
                throw new Exception($"Artist does not exist with ID = {song.ArtistId}");
            }

            var albumExists = _context.Albums.Any(e => e.Id == song.AlbumId);
            if(!albumExists){
                throw new Exception($"Album does not exist with ID = {song.AlbumId}");
            }

            entity.Title = song.Title;
            entity.Minutes = song.Minutes;
            entity.Seconds = song.Seconds;

            return entity;
        }
    }
}