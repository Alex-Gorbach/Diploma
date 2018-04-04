﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationContext")]

        public string Id { get; set; }

        public string Name { get; set; }
        

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
