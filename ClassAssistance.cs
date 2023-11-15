using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
namespace GradeSheet
{
    class Student
    {
        public string name;
        public string lastName;
        Dictionary<string, int> studentCourses = new() {
            { "advancedProgramming1", 0 },
            { "advancedProgramming2", 0 },
            { "OOP", 0 },
            { "oses", 0 },
            { "alg", 0 },
            { "interpretation", 0 },
            { "math", 0 },
            { "workshop", 0 },
            { "English", 0 },
            { "Sport", 0  },
        };
        char grade;

        public float getAvarage(List<Tuple<string, int>> toAvarage)
        {
            int sum = 0;
            foreach(var course in toAvarage)
            {
                sum += this.studentCourses[course.Item1]*course.Item2;
            }
            return sum/toAvarage.Count;
        }

        public char calcGrade(List<Tuple<string, int>> toAvarage) 
        {
            float avarage = getAvarage(toAvarage);

            if (avarage <= 20&& 17 <= avarage)
            {
                this.grade = 'A';
                return this.grade;
            }

            else if (avarage <= 17 && 15 <= avarage)
            {
                this.grade = 'B';
                return this.grade;
            }

            else if (avarage <= 15 && 13 <= avarage)
            {
                this.grade = 'C';
                return this.grade;
            }

            else if (avarage <= 10 && 13 <= avarage)
            {
                this.grade = 'D';
                return this.grade;
            }

            else if (avarage <= 7 && 10 <= avarage)
            {
                this.grade = 'E';
                return this.grade;
            }

            else if (avarage <= 3 && 7 <= avarage)
            {
                this.grade = 'F';
                return this.grade;
            }

            else if (avarage <= 0 && 3 <= avarage)
            {
                this.grade = 'G';
                return this.grade;
            }
            else { return 'N'; }
        }

        public Student(string name, string lastName, string[] scors)
        {
            int i = 0;
            foreach (var key in studentCourses.Keys)
            {
                try
                {
                    studentCourses[key] = Convert.ToInt32(scors[i]);
                }
                catch
                {
                    studentCourses[key] = Random.Shared.Next(0, 20);
                }
                i++;
            }
            this.name = name;
            this.lastName = lastName;

        }
    }
    class Semester
    {
        public Student[] student;

        public static Dictionary<string, List<Tuple<string, int>>> courses = new()
        {
            {
                "importent", new ()
                {
                    new ("advancedProgramming1", 3),
                    new ("addvancedProgramming2", 3),
                    new ("OOP", 3)
                }
            },
            {
                "goodToKnow", new ()
                {
                    new("oses", 3),
                    new("alg", 3)
                }
            },
            {
                "shits", new()
                {
                    new ("interpretation", 1),
                    new ("math", 2),
                    new("workshop", 1),
                    new("English", 2) ,
                    new ("Sport", 1)
                }
            }
        };
        public float getArageImportants()
        {
            
        }
        


        public Semester(string path)
        {
            Console.WriteLine(path);
            if (File.Exists(path))

            {
                student = new Student[100];
                int i = 0;
                StreamReader raw = new StreamReader(path);
                while ((!raw.EndOfStream) && i < 100)
                {
                    string[] information;
                    try 
                    {
                        information = raw.ReadLine().Split(",");
                    } 
                    catch 
                    {
                        Console.WriteLine($"Bad line(line: {i++})");
                        continue;
                    }
                    if (information.Length > 0)
                    {
                        student[i] = new Student(information[0], information[1], (information.Skip(1).Skip(1).ToArray()));
                        i++;
                    }
                    
                }
            }
        }

    }
}
