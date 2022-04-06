using System.ComponentModel.DataAnnotations;

namespace APIRestfulEntity.Data
{
    public class Brugeres
    {
        [Key]
        public int BrugerId { get; set; }
        public string? Name { get; set;}

    }
}
