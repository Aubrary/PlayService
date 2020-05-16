using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Playlist {

        [Key]
        public Guid id {get; set;}
        
        public string Name {get; set;}
        
        public List<Song> Songs {get; set;}
        
    }
}