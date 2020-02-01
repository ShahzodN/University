using System;
using System.Collections.Generic;
using System.Text;
using UniversityT.Model;

namespace UniversityT
{
    class Kafedra
    {
        public Kafedra()
        {
            Teachers = new List<Teacher>();
            Groups = new List<Group>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncryptedName { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
    }
}
