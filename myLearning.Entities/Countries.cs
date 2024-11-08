﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace myLearning.Entities
{
    [Table("Countries")]
    [Index(nameof(Name))]
    [Index(nameof(ISO2))]
    [Index(nameof(ISO3))]
    public class Countries
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonPropertyName("iso2")]
        public string ISO2 { get; set; } = null!;

        [JsonPropertyName("iso3")]
        public string ISO3 { get; set; } = null!;

        public ICollection<Cities>? Cities { get; set; } = null!;
    }
}
