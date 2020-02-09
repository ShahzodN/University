using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UniversityT.Model;

namespace UniversityT.Controller
{
    class EntityAdd
    {
        public EntityAdd()
        {
            SelectCategory();
        }

        private void SelectCategory()
        {
            var counter = 1;
            string[] categories = CategoryInitializer();
            foreach (var item in categories)
                Console.WriteLine($"{counter++}. {item}");
            int input = Manager.CheckInputNumber();
            CategoriesSwitch();
            void CategoriesSwitch()
            {
                switch (input)
                {
                    case 1:
                        NewInstitute();
                        break;
                    case 2:
                        NewFaculty();
                        break;
                    case 3:
                        NewKafedra();
                        break;
                    case 4:
                        NewGroup();
                        break;
                    case 5:
                        NewStudent();
                        break;
                    case 6:
                        NewTeacher();
                        break;
                    case 7:
                        NewSubject();
                        break;
                    case 8:
                        NewSpecialty();
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка!");
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }

        private string[] CategoryInitializer()
        {
            return new string[] { "Институт", "Факультет", "Кафедра", "Группа", "Студент", "Учитель", "Предмет", "Специальность" };
        }

        private void NewInstitute()
        {
            Console.Write("Полное название института:\n\t");
            string name = Console.ReadLine();
            var letters = name.ToUpper().Trim().Split(' ',',','-').Where(s => s.Length !=1).Select(s => s[0]);
            string encryptedName = "";
            foreach (var item in letters)
            {
                encryptedName += item;
            }

            using (var db = new UniversityContext())
            {
                var ins = new Institute()
                {
                    EncryptedName = encryptedName,
                    Name = name,
                    University = db.Universities.Single()
                };
                db.Institutes.Add(ins);
                db.SaveChanges();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Операция успешна выполнена");
            Console.ResetColor();
        }

        private void NewFaculty()
        {

        }

        private void NewKafedra()
        {

        }
        private void NewSubject()
        {

        }

        private void NewTeacher()
        {

        }

        private void NewGroup()
        {

        }

        private void NewSpecialty()
        {

        }

        private void NewStudent()
        {

        }
    }
}
