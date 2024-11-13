using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APIAngularReact.Models
{
    public class Taske
    {
        [Key]
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime createdAt { get; set; }

        public string statut { get; set; }

    }
}
