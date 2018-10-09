using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{

    public enum Roles
    {
        Administrator = 1,
        Moderator = 2,
        Employee = 3
    }

    [Table("Users")]
    public class User: BaseModel
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public Roles Role { get; set; }

        public IEnumerable<Sale> Sales { get; set; }

    }

}
