using System;
using System.Collections.Generic;
using System.Text;
using UniversityT.Model;

namespace UniversityT
{
    class Institute
    {
        public Institute()
        {
            Faculties = new List<Faculty>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncryptedName { get; set; }
        public University University { get; set; }
        public int UniversityId { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
