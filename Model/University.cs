using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityT.Model
{
    class University
    {
        public University()
        {
            Institutes = new List<Institute>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncryptedName { get; set; }
        public List<Institute> Institutes { get; set; }
    }
}
