using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{

    [Table("admin")]
    public class AdminModel
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int AdminID { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string AdminLogImage { get; set; } 


    }
}
