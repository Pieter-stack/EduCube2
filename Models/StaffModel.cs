using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{
    //initialize table
    [Table("staff")]
    public class StaffModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int StaffID { get; set; }

        [MaxLength(100)]
        public int StaffPersonalID { get; set; }

        [MaxLength(100)]
        public string StaffEmail { get; set; }

        [MaxLength(100)]
        public string StaffFirstName { get; set; }

        [MaxLength(100)]
        public string StaffLastName { get; set; }

        [MaxLength(100)]
        public string StaffRole { get; set; }

        [MaxLength(255)]
        public string StaffImage { get; set; }

        [MaxLength(100)]
        public int StaffHours { get; set; }

        [MaxLength(10)]
        public int StaffSalary { get; set; }

        [MaxLength(100)]
        public string StaffPassword { get; set; }
    }
}
