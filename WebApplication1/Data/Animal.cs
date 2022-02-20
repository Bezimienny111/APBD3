using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Animal
    {
        [Required(ErrorMessage = "Wymagane ID")]
        public int IdAnimal { get; set; }
        [Required(ErrorMessage = "Wymagane Imie")]
        [MaxLength(100,ErrorMessage = "Długość max 200 znaków")]
        public string Name { get; set; }
       
        [MaxLength(200, ErrorMessage = "Długość max 200 znaków")]
        public string Desctiption { get; set; }
        [Required(ErrorMessage = "Wymagana Kategoria")]
        [MaxLength(100, ErrorMessage = "Długość max 200 znaków")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Wymagany Obszar")]
        [MaxLength(500, ErrorMessage = "Długość max 200 znaków")]
        public string Area { get; set; }

        public Animal(int idAnimal, string name, string desctiption, string category, string area)
        {
            IdAnimal = idAnimal;
            Name = name;
            Desctiption = desctiption;
            Category = category;
            Area = area;
        }
        public Animal() { }

        public Animal(string name, string desctiption, string category, string area)
        {
            IdAnimal = 999;
            Name = name;
            Desctiption = desctiption;
            Category = category;
            Area = area;
        }
    }
}
