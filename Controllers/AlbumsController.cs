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
    public class AlbumsController : CrudControllerBase<Album> {
        // Dependecy injection of PlayServiceContext
        public AlbumsController(PlayServiceContext context)
        : base(context, context.Albums){} 

        protected override Album MapToEntity(Album album, Album entity = null){
            if(entity == null){
                entity = new Album();
            }

            var artistExists = _context.Artists.Any(e => e.Id == album.ArtistId);
            if(!artistExists){
                throw new Exception($"Artist does not exist with ID = {album.ArtistId}");
            }

            entity.ArtistId = album.ArtistId;
            entity.Rating = album.Rating;

            return entity;
        }

        protected override IQueryable<Album> GetQueryableContext(){
            return _context.Albums.Include(e => e.Artist).Include(e => e.Songs);
        }
    }

}