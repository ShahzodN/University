using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityT
{
    class Specialty
    {
        public Specialty()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public List<Student> Students { get; set; }
    }
}
