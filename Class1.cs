namespace GradeSheet
{
    class Student
    {
        public string Name;
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

        public Student(string name)
        {
            foreach (var key in studentCourses.Keys)
                studentCourses[key] = Random.Shared.Next(0, 20);

            Name = name;
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
                    new ("advancedProgramming1", 2),
                    new ("addvancedProgramming2", 2),
                    new ("OOP", 2)
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


        public Semester()
        {
            String[] name = randomName();
            student = new Student[100];
            for (int i = 0; i < 100; i++)
            {
                student[i] = new Student(name[i]);
            }
        }
        static string[] randomName()
        {
            List<string> toReturn = new();
            string[] names = { "ali", "hasan", "hossein", "mohammad", "mehdi", "arya", "arman", "abbas", "adel", "farshid", "ebrahim", "saeed", "behzad", "sajad", "kazem", "amin", "milad", "ehsan", "mobin", "bahman", };
            string[] families = { "taheri", "hafezi", "amini", "kazemi", "rahimi", "ghafari", "mardani", "azhari", "enayati" };
            
            while (toReturn.Count < 100)
            {
                string tmpname = names[Random.Shared.Next(0, names.Length - 1)] + " " + families[Random.Shared.Next(0, families.Length - 1)];

                if (!toReturn.Contains(tmpname))
                    toReturn.Add(tmpname);
            }

            return toReturn.ToArray();
        }

    }
}
