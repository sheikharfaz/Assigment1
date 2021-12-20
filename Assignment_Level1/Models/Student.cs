using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Level1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [Column("name", TypeName = "varchar(16)")]
        public string? Name { get; set; }

        [Column("date_of_birth", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

    }
}
