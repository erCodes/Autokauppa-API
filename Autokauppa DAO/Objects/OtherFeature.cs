﻿using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.Objects
{
    public class OtherFeature
    {
        public OtherFeature(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
