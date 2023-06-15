using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Domain.Entity
{
    public class Filter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
