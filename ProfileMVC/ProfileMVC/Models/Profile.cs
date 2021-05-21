﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVC.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]

        public int Age { get; set; }

        public string Qualification { get; set; }

        public bool IsEmployed { get; set; }

        public string NoticePeriod { get; set; }

        public float CurrentCTC { get; set; }

    }
}
