using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Album {

        [Key]
        public Guid Id {get; set;}

        public Artist Artist {get; set;}

        public List<Song> Songs {get; set;}

        public List<Genre> Genre {get; set;}

        public int Rating {get; set;}

    }
}