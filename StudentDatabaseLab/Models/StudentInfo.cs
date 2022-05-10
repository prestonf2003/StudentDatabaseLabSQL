using System;
using System.Collections.Generic;

namespace StudentDatabaseLab.Models
{
    public partial class StudentInfo
    {
        public int Id { get; set; }
        public string? Studentname { get; set; }
        public string? Hometown { get; set; }
        public string? Favfood { get; set; }
        public string? Favcolor { get; set; }
    }
}
