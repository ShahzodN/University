using System;
using System.Collections.Generic;
using System.Text;
using UniversityT.Model;

namespace UniversityT
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
