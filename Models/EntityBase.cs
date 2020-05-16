using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PlayService.Models {
    
    public abstract class EntityBase {

        [Key]
        public Guid Id {get; set;}
    }
}