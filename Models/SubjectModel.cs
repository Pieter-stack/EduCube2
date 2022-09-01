using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{
    //initialize table
    [Table("subject")]
    public class SubjectModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement]
        public int SubjectID { get; set; }

        [MaxLength(100)]
        public string SubjectTitle { get; set; }

        [MaxLength(100)]
        public string SubjectCode { get; set; }

        [MaxLength(100)]
        public string SubjectLecturer { get; set; }

        [MaxLength(255)]
        public string SubjectDescription { get; set; }

        [MaxLength(100)]
        public int SubjectCredits { get; set; }

        [MaxLength(100)]
        public int SubjectPrice { get; set; }

        [MaxLength(100)]
        public string SubjectDate { get; set; }

        [MaxLength(100)]
        public string SubjectTime { get; set; }

        [MaxLength(255)]
        public string SubjectImage { get; set; }

        [MaxLength(100)]
        public int SubjectHours { get; set; }

        [MaxLength(100)]
        public string SubjectVenue { get; set; }

        [MaxLength(100)]
        public string SubjectCategory { get; set; }

        [MaxLength(100)]
        public string SubjectStudentCount { get; set; }


    }
}
