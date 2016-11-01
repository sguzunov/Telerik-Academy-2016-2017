using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class StudentInfo
    {
        [Column("Birthday")]
        public DateTime Birthday { get; set; }
    }
}
