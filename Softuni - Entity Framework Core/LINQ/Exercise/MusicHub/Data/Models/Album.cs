using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {
        private decimal price;
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price {
            get => this.Songs.Sum(x => x.Price);
            set => price = value;
        }

        public int? ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]    
        public virtual Producer? Producer { get; set; }

        public ICollection<Song> Songs { get; set; } 
    }
}
