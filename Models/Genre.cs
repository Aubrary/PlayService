using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {

    public class Genre : EntityBase {
        public string Name {get; set;}
    }
}