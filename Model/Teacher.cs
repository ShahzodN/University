using System;
using System.Collections.Generic;
using System.Text;
using UniversityT.Model;

namespace UniversityT
{
    class Teacher
    {
        public Teacher()
        {
            TeacherSubjects = new List<TeacherSubject>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }
        public int KafedraId { get; set; }
        public Kafedra Kafedra { get; set; }
    }
}
