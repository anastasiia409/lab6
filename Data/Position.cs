using System.ComponentModel.DataAnnotations;

namespace lab6.Data
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
    }
}
