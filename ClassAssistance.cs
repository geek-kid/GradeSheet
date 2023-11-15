using System;
using System.Collections.Generic;

namespace GradeSheet
{
    class Student
    {
        public string name;
        public string lastName;
        readonly Dictionary<string, int> studentCourses = new() {
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

        public float GetAverage(List<Tuple<string, int>> toAverage)
        {
            int sum = 0;
            foreach(var course in toAverage)
                sum += studentCourses[course.Item1]*course.Item2;
            
            return sum / toAverage.Count;
        }

        public Tuple<string, char> CalcGrade(List<Tuple<string, int>> toAverage) 
        {
            Tuple<string, char> toReturn;
            switch (GetAverage(toAverage))
            {
                case <= 20 and >= 17:
                    grade = 'A';
                    break;
                case < 17 and >= 15:
                    grade = 'B';
                    break;
                case < 15 and >= 13:
                    grade = 'C';
                    break;
                case < 13 and >= 10:
                    grade = 'D';
                    break;
                case < 10 and >= 7:
                    grade = 'E';
                    break;
                case < 7 and >= 3:
                    grade = 'F';
                    break;
                case < 3 and >= 0:
                    grade = 'G';
                    break;
                default:
                    grade = 'N';
                    break;
            }

            toReturn = new(name, grade);
            return toReturn;
        }

        public void GetPrimeNumber()
        {
            string toPrint = $"{name} {lastName} | ";
            foreach (var course in studentCourses)
            {
                if (course.Value >= 2)
                    continue;

                for (int i = 2; i <= Math.Sqrt(course.Value); i++)
                    if (course.Value % i == 0) 
                        continue;
                toPrint += $"{course.Key}: {course.Value}, ";
                
            }
            Console.WriteLine(toPrint);
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
        public Student[] students;

        public static Dictionary<string, List<Tuple<string, int>>> courses = new()
        {
            {
                "important", new ()
                {
                    new ("advancedProgramming1", 3),
                    new ("advancedProgramming2", 3),
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
        public List<Tuple<string, float>> GetAverageImportants()
        {
            List<Tuple<string, float>> toReturn = new();
            foreach(Student student in students)
            {
                toReturn.Add(new Tuple<string, float>(student.name + " " + student.lastName, student.GetAverage(courses["important"])));
            }
            return toReturn;
        }

        public List<Tuple<string, float>> GetAverageShits()
        {
            List<Tuple<string, float>> toReturn = new();
            foreach (Student student in students)
            {
                toReturn.Add(new Tuple<string, float>(student.name + " " + student.lastName, student.GetAverage(courses["shits"])));
            }
            return toReturn;
        }

        public List<Tuple<string, float>> GetAverageGoodToKnow()
        {
            List<Tuple<string, float>> toReturn = new();
            foreach (Student student in students)
            {
                toReturn.Add(new Tuple<string, float>(student.name + " " + student.lastName, student.GetAverage(courses["goodToKnow"])));
            }
            return toReturn;
        }

        public List<Tuple<string, float>> GetAverage()
        {
            List<Tuple<string, float>> toReturn = new();
            foreach (Student student in students)
            {
                toReturn.Add(new Tuple<string, float>(student.name + " " + student.lastName, student.GetAverage(courses.Values.SelectMany(list => list).ToList()))) ;
            }
            return toReturn;
        }

        public List<Tuple<string, char>> GetGrade()
        {
            List<Tuple<string, float>> toReturn = new();
            foreach (Student student in students)
            {
                toReturn.Add(calc);
            }
            return toReturn;
        }


        public Semester(string path)
        {
            Console.WriteLine(path);
            if (File.Exists(path))
            {
                students = new Student[100];
                int i = 0;

                StreamReader raw = new(path);
                while ((!raw.EndOfStream))
                {
                    string[] information;
                    string? line = raw.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    if (!line.Contains(','))
                        continue;

                    try
                    {
                        information = line.Split(',');
                    }
                    catch
                    {
                        Console.WriteLine($"Bad line(line: {i++})");
                        continue;
                    }

                    if (information.Length > 3)
                        students[i++] = new Student(information[0], information[1], information.Skip(2).ToArray());

                    if (i > 99)
                        break;
                    GetAverage();
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
                throw new Exception();
            }
        }

    }
}
