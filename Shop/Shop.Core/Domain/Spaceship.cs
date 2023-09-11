﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Core.Domain
{
    public class Spaceship //andmed mis lahevad andmebaasi
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Passengers { get; set; }
        public int EnginePower { get; set; }
        public int Crew { get; set; }
        public string Company { get; set; }
        public int CargoWeight { get; set; }

        //only in database
        public DateTime CreatedAt { get; set; }
        public DateTime Modified { get; set; }



    }
}
