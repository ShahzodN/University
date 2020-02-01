using System;
using System.Collections.Generic;
using System.Text;
using UniversityT.Model;

namespace UniversityT
{
    class Subject
    {
        public Subject()
        {
            TeacherSubject = new List<TeacherSubject>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncryptedName { get; set; }
        public List<TeacherSubject> TeacherSubject { get; set; }
    }
}
