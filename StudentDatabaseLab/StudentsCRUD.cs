using System;
using StudentDatabaseLab.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabaseLab
{
     class StudentsCRUD
    {
    StudentsContext db = new StudentsContext();
        public List<StudentInfo> GetStudents()
        {
            return db.StudentInfos.ToList();
        }
        public StudentInfo GetStudent(int id)
        {
            StudentInfo output = db.StudentInfos.Find(id);
            if (output != null)
            {
                return output;
            }
            else
            {
                StudentInfo errorStudent = new StudentInfo();
                errorStudent.Studentname = $"No car was found in the database at id {id}";
                return errorStudent;
            }
        }
        public void CreateStudent(StudentInfo s)
        {
            db.StudentInfos.Add(s);
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            StudentInfo StudentToRemove = GetStudent(id);
            if (db.StudentInfos.Contains(StudentToRemove))
            {
                db.StudentInfos.Remove(StudentToRemove);
                db.SaveChanges();
            }



        }
    }
}
