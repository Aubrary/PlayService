using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Artist : EntityBase {

        public string Name {get; set;}

        public List<Album> Albums {get; set;}

        public int Rating {get; set;}
    }
}