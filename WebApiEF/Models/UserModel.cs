using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEF.Models
{
    [Table("person")]
    public class UserModel
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Required]
        [Column("lastname")]
        public string LastName { get; set; }

        [Column("email")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Column("phonenumber")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

    }
}
