using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{

    [Table("Clients")]
    public class Client : BaseModel
    {
        public int ClientId { get; set; }

        [Required]
        [MaxLength(13)]
        public string Dni { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(12)]        
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sex { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public IEnumerable<Sale> Sales { get; set; }

    }
}
