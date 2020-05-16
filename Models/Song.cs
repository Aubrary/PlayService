using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {
    
    public class Song {

        [Key]
        public Guid Id {get; set;}

        public Guid ArtistId { get; set; }
        public Artist Artist {get; set;}

        public Guid AlbumId { get; set; }
        public Album Album {get; set;}

        public string Title {get; set;}

        public List<Genre> Genre {get; set;}

        public int Minutes {get; set;}

        public int Seconds {get; set;}

        public double Streams {get; set;}

    }
}