using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Artist {

        [Key]
        public Guid Id {get; set;}

        public string Name {get; set;}

        public List<Album> Albums {get; set;}

        public List<Song> Songs {get; set;}

        public int Rating {get; set;}
        
    }
}