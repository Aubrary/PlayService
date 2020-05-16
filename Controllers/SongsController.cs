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
    public class SongsController : CrudControllerBase<Song> {
        // Dependecy injection of PlayServiceContext
        public SongsController(PlayServiceContext context)
        : base(context, context.Songs){} 

        protected override Song MapToEntity(Song song, Song entity = null){
            if(entity == null){
                entity = new Song();
            }

            var test = _context.Songs.Include(e => e.Album).Include(e => e.Genre);

            var albumExists = _context.Albums.Any(e => e.Id == song.AlbumId);
            if(!albumExists){
                throw new Exception($"Album does not exist with ID = {song.AlbumId}");
            }

            entity.Title = song.Title;
            entity.Minutes = song.Minutes;
            entity.Seconds = song.Seconds;
            entity.AlbumId = song.AlbumId;

            return entity;
        }

        protected override IQueryable<Song> GetQueryableContext(){
            return _context.Songs.Include(e => e.Album);
        }
    }
}