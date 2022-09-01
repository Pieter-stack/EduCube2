using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{
    //initialize table
    [Table("student")]
    public class StudentModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
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
        public string StudentSubjects { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsMajor { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsTheory { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsModule1 { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsModule2 { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsModule3 { get; set; }

        [MaxLength(100)]
        public string StudentSubjectsModule4 { get; set; }


        [MaxLength(100)]
        public string StudentSubjectsModule5 { get; set; }


        [MaxLength(100)]
        public string StudentSubjectsModule6 { get; set; }


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
