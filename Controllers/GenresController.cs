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
    public class GenresController : CrudControllerBase<Genre> {
        // Dependecy injection of PlayServiceContext
        public GenresController(PlayServiceContext context)
        : base(context, context.Genres){} 

        protected override Genre MapToEntity(Genre genre, Genre entity = null){
            if(entity == null){
                entity = new Genre();
            }

            entity.Name = genre.Name;

            return entity;
        }

        protected override IQueryable<Genre> GetQueryableContext(){
            return _context.Genres;
        }
    }
    
}