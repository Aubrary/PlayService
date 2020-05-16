using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;
using System.Linq;

namespace PlayService.Controllers {
    [Route("api/controller")]
    [ApiController]
    public class ArtistsController : CrudControllerBase<Artist> {
        // Dependecy injection of PlayServiceContext
        public ArtistsController(PlayServiceContext context)
        : base(context, context.Artists){} 

        protected override Artist MapToEntity(Artist artist, Artist entity = null){
            if(entity == null){
                entity = new Artist();
            }

            entity.Name = artist.Name;
            entity.Rating = artist.Rating;

            return entity;
        }
    }
}