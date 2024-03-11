using System.ComponentModel.DataAnnotations;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}