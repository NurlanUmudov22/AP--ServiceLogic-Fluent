using System.ComponentModel.DataAnnotations;

namespace API_Intro.Models
{
    public class Category :BaseEntity
    {
        [StringLength(10)]
        public string Name { get; set; }
    }
}
