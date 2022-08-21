using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{

    [Table("student")]
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }

        [MaxLength(100)]
        public int StudentPersonalID { get; set; }

        [MaxLength(100)]
        public string StudentEmail { get; set; }

        [MaxLength(100)]
        public string StudentFirstName { get; set; }

        [MaxLength(100)]
        public string StudentLastName { get; set; }

        [MaxLength(100)]
        public string StudentRole { get; set; }

        [MaxLength(255)]
        public string StudentImage { get; set; }

        [MaxLength(100)]
        public int StudentCredits { get; set; }

        [MaxLength(10)]
        public int StudentTuition { get; set; }

        [MaxLength(100)]
        public string StudentType { get; set; }
    }
}
