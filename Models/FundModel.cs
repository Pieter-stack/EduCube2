using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Models
{
    [Table("funds")]
    public class FundModel
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int FundsID { get; set; }

        [MaxLength(255)]
        public int TotalFunds { get; set; }

        [MaxLength(255)]
        public int TotalTuition { get; set; }

        [MaxLength(255)]
        public int TotalSalary { get; set; }

    }
}
