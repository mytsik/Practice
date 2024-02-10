using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace _1301
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("password")]
        public string Password { get; set; }

    }
}
