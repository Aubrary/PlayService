using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Genre {
        
        [Key]
        public Guid id {get; set;}

        public string Name {get; set;}

    }
}