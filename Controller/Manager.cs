using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityT.Model;

namespace UniversityT.Controller
{
    class Manager
    {
        int counter = 1;
        int inputNumber = 0;
        public void StartUp()
        {
            using(var db = new UniversityContext())
            {
                var unis = db.Universities.Include(u => u.Institutes).ToList();
                ShowUni(unis);
            }
        }
        private void ShowUni(List<University> list)
        {
            foreach (var uni in list)
            {
                Console.WriteLine($"{counter++} {uni.Name}");
            }
        }

        private int CheckInputNumber()
        {
            int inputInfo;
            int.TryParse(Console.ReadLine(), out inputInfo);
            return inputInfo;
        }
    }
}
