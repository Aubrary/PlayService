using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {
    
    public class Song : EntityBase {
        public Guid AlbumId { get; set; }
        public Album Album {get; set;}

        public string Title {get; set;}

        public List<Genre> Genre {get; set;}

        public int Minutes {get; set;}

        public int Seconds {get; set;}

        public int StreamCount {get; set;}

    }
}