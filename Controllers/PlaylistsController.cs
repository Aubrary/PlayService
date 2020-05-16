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
    public class PlaylistsController : CrudControllerBase<Playlist> {
        // Dependecy injection of PlayServiceContext
        public PlaylistsController(PlayServiceContext context)
        : base(context, context.Playlists){} 

        protected override Playlist MapToEntity(Playlist playlist, Playlist entity = null){
            if(entity == null){
                entity = new Playlist();
            }

            entity.Name = playlist.Name;

            return entity;
        }
        
        protected override IQueryable<Playlist> GetQueryableContext(){
            return _context.Playlists;
        }
    }
}