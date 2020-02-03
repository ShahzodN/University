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
        int inputNumber;
        string splitter = "* * * * * * * * * * * * * * * * * * * * * * * * * * *";
        List<string> firstInfos;
        public Manager()
        {
            firstInfos = new List<string>()
            {
                "Университеты","Институты",
                "Факультеты","Кафедры",
                "Группы", "Специальности"
            };
        }
        public void StartUp()
        {
            var counter = 1;
            foreach (var item in firstInfos)
                Console.WriteLine($"{counter++} {item}");
            SwitchCaseCheck();
            void SwitchCaseCheck()
            {
                switch (inputNumber = CheckInputNumber())
                {
                    case 1:
                        ShowUniversities();
                        break;
                    case 2:
                        ShowInstitutes();
                        break;
                    case 3:
                        ShowFaculties();
                        break;
                    case 4:
                        ShowKafedras();
                        break;
                    case 5:
                        ShowGroups();
                        break;
                    case 6:
                        ShowSpecialties();
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка!");
                            Console.ResetColor();
                            SwitchCaseCheck();
                        }
                        break;
                }
            }
        }

        private void ShowUniversities()
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                foreach (var uni in db.Universities.ToList())
                {
                    Console.WriteLine($"{counter++}. {uni.EncryptedName}");
                }
            }
        }

        private void ShowInstitutes()
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                var institutes = db.Institutes.ToList();
                foreach (var ins in institutes)
                    Console.WriteLine($"{counter++}. {ins.EncryptedName}");
                inputNumber = CheckInputNumber();
                var instituteId = institutes[inputNumber - 1].Id;
                ShowFaculties(instituteId);
            }
        }

        private void ShowFaculties(int instituteId)
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                var institute = db.Institutes.Include(i => i.Faculties).FirstOrDefault(i => i.Id == instituteId);
                Console.WriteLine(splitter);
                foreach (var faculty in institute.Faculties)
                    Console.WriteLine($"{counter++}. {faculty.EncryptedName}");
                inputNumber = CheckInputNumber();
                var selectedFacultyId = institute.Faculties[inputNumber - 1].Id;
                ShowKafedras(selectedFacultyId);
            }
        }

        private void ShowFaculties()
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                var faculties = db.Faculties.ToList();
                Console.WriteLine(splitter);
                foreach (var faculty in faculties)
                    Console.WriteLine($"{counter++}. {faculty.EncryptedName}");
                inputNumber = CheckInputNumber();
                var facultyId = faculties[inputNumber - 1].Id;
                ShowKafedras(facultyId);
            }
        }

        private void ShowKafedras(int facultyId)
        {
            using (var db = new UniversityContext())
            {
                var counter = 1;
                var faculty = db.Faculties.Include(f => f.Kafedras).FirstOrDefault(f => f.Id == facultyId);
                Console.WriteLine(splitter);
                foreach (var kafedra in faculty.Kafedras)
                    Console.WriteLine($"{counter++}. {kafedra.EncryptedName}");
                inputNumber = CheckInputNumber();
                var kafedraId = faculty.Kafedras[inputNumber - 1].Id;
                ShowKafedraElements(kafedraId);
            }
        }

        private void ShowKafedras()
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                var kafedras = db.Kafedras.ToList();
                Console.WriteLine(splitter);
                foreach (var kafedra in kafedras)
                    Console.WriteLine($"{counter++}. {kafedra.EncryptedName}");
                inputNumber = CheckInputNumber();
                var kafedraId = kafedras[inputNumber - 1].Id;
                ShowKafedraElements(kafedraId);
            }
        }

        private void ShowGroups(int kafedraId)
        {
            using (var db = new UniversityContext())
            {
                var kafedra = db.Kafedras.Include(k => k.Groups).FirstOrDefault(k => k.Id == kafedraId);
                var counter = 1;
                Console.WriteLine(splitter);
                foreach (var group in kafedra.Groups)
                    Console.WriteLine($"{counter++}. {group.Number}");
                inputNumber = CheckInputNumber();
                var groupId = kafedra.Groups[inputNumber - 1].Id;
                ShowStudents(groupId);
            }
        }

        private void ShowGroups()
        {
            var counter = 1;
            using (var db = new UniversityContext())
            {
                var groups = db.Groups.ToList();
                Console.WriteLine(splitter);
                foreach (var group in groups)
                    Console.WriteLine($"{counter++}. {group.Number}");
                inputNumber = CheckInputNumber();
                var groupId = groups[inputNumber - 1].Id;
                ShowStudents(groupId);
            }
        }

        private void ShowStudents(int groupId)
        {
            using (var db = new UniversityContext())
            {
                var counter = 1;
                var students = db.Students.Where(s => s.GroupId == groupId).OrderBy(s => s.LastName);
                Console.WriteLine(splitter);
                foreach (var student in students)
                    Console.WriteLine($"{counter++}. {student.LastName} {student.FirstName} {student.MiddleName}");
            }
        }

        private void ShowKafedraElements(int kafedraId)
        {
            var counter = 1;
            Console.WriteLine(splitter);
            Console.WriteLine($"{counter++}. Группы");
            Console.WriteLine($"{counter++}. Учители");
            SwitchCheck();
            void SwitchCheck()
            {
                switch (inputNumber = CheckInputNumber())
                {
                    case 1:
                        ShowGroups(kafedraId);
                        break;
                    case 2:
                        ShowTeachers(kafedraId);
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка!");
                            Console.ResetColor();
                            SwitchCheck();
                        }
                        break;
                }
            }
        }

        private void ShowTeachers(int kafedraId)
        {
            using (var db = new UniversityContext())
            {
                var counter = 1;
                var kafedra = db.Kafedras.Include(k => k.Teachers).FirstOrDefault(k => k.Id == kafedraId);
                Console.WriteLine(splitter);
                foreach (var teacher in kafedra.Teachers)
                    Console.WriteLine($"{counter++} {teacher.LastName} {teacher.FirstName} {teacher.MiddleName}");
                inputNumber = CheckInputNumber();
                var teacherId = kafedra.Teachers[inputNumber - 1].Id;
                ShowSubjects(teacherId);
            }
        }

        private void ShowSubjects(int teacherId)
        {
            using (var db = new UniversityContext())
            {
                var counter = 1;
                var teacher = db.Teachers.Include(t => t.TeacherSubjects).ThenInclude(ts => ts.Subject).FirstOrDefault(t => t.Id == teacherId);
                var subjects = teacher.TeacherSubjects.Select(ts => ts.Subject).ToList();
                Console.WriteLine(splitter);
                foreach (var subject in subjects)
                    Console.WriteLine($"{counter++} {subject.Name}");
            }
        }

        private void ShowSpecialties()
        {
            using (var db = new UniversityContext())
            {
                var counter = 1;
                foreach (var spec in db.Specialties.ToList())
                    Console.WriteLine($"{counter++}. {spec.Number} {spec.Name}");
            }
        }

        private int CheckInputNumber()
        {
            int inputInfo;
            while (!int.TryParse(Console.ReadLine(), out inputInfo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка");
                Console.ResetColor();
            }
            return inputInfo;
        }
    }
}
