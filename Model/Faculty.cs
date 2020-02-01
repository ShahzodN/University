using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityT
{
    class Faculty
    {
        public Faculty()
        {
            Kafedras = new List<Kafedra>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncryptedName { get; set; }
        public Institute Institute { get; set; }
        public int InstituteId { get; set; }
        public List<Kafedra> Kafedras { get; set; }
    }
}
