using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityT.Model
{
    class Group
    {
        public Group()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Student> Students { get; set; }
        public int KafedraId { get; set; }
        public Kafedra Kafedra { get; set; }
    }
}
