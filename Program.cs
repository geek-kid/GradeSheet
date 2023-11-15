// Coded by Arya Taheri
using GradeSheet;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

Semester semester;
input:
    string? path;
    do
    {
        Console.Clear();
        Console.WriteLine("Students File?: ");
        path = Console.ReadLine()?.Replace("\"", "");

        if (string.IsNullOrWhiteSpace(path))
            Console.WriteLine("bad input try again");
    }
    while (string.IsNullOrWhiteSpace(path));

    try
    {
        semester = new(path);
    }
    catch
    {
        goto input;
    }

menu:
    Console.Clear();
    Console.WriteLine(@"Choose from menu(Just key Pad):
    1: avarage of all the courses
    2: avarage of important courses
    3: avarage of good to know courses
    4: avarage of shit courses
    5: find prime number from students points
    6: show students with grades");
    switch (Console.ReadKey(true).Key)
    {

        case ConsoleKey.NumPad1:
            ExecAvarageOfALL();
            Console.WriteLine("press Y to continue and N to Close");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    goto menu;
                default:
                    break;
            }
            break;
        
        case ConsoleKey.NumPad2:
            ExecAvarageImportant();
            Console.WriteLine("press Y to continue and N to Close");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    goto menu;
                default:
                    break;
            }
            break;

    case ConsoleKey.NumPad3:
        ExecAvarageGoodToKnow();
        Console.WriteLine("press Y to continue and N to Close");
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y:
                goto menu;
            default:
                break;
        }
        break;


    case ConsoleKey.NumPad4:
        ExecAvarageShits();
        Console.WriteLine("press Y to continue and N to Close");
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y:
                goto menu;
            default:
                break;
        }
        break;

    case ConsoleKey.NumPad5:
        semester.GetPrimeScores();
        Console.WriteLine("press Y to continue and N to Close");
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y:
                goto menu;
            default:
                break;
        }
        break;

        case ConsoleKey.NumPad6:
            ExecStudentsGrades();
            Console.WriteLine("press Y to continue and N to Close");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    goto menu;
                default:
                    break;
            }
            break;

    }
void ExecAvarageOfALL()
{
    List<Tuple<string, float>> average = semester.GetAverage();
    Console.WriteLine(@"you will sort average with what?:
    1: name
    2: score
    ");
    switch(Console.ReadKey(true).Key)
    { case ConsoleKey.NumPad1:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
        case ConsoleKey.NumPad2:
            foreach (var student in average.OrderBy(tuple => tuple.Item2).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
    }
}

void ExecAvarageImportant()
{
    List<Tuple<string, float>> average = semester.GetAverageImportants();
    Console.WriteLine(@"you will sort average with what?:
    1: name
    2: score
    ");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.NumPad1:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
        case ConsoleKey.NumPad2:
            foreach (var student in average.OrderBy(tuple => tuple.Item2).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
    }
}

void ExecAvarageGoodToKnow()
{
    List<Tuple<string, float>> average = semester.GetAverageGoodToKnow();
    Console.WriteLine(@"you will sort average with what?:
    1: name
    2: score
    ");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.NumPad1:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
        case ConsoleKey.NumPad2:
            foreach (var student in average.OrderBy(tuple => tuple.Item2).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
    }
}

void ExecAvarageShits()
{
    List<Tuple<string, float>> average = semester.GetAverageShits();
    Console.WriteLine(@"you will sort average with what?:
    1: name
    2: score
    ");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.NumPad1:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item1}");
            }
            break;

        case ConsoleKey.NumPad2:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
    }
}

void ExecStudentsGrades()
{
    List<Tuple<string, char>> average = semester.GetGrade();
    Console.WriteLine(@"you will sort average with what?:
    1: name
    2: grade
    ");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.NumPad1:
            foreach (var student in average.OrderBy(tuple => tuple.Item1).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
        case ConsoleKey.NumPad2:
            foreach (var student in average.OrderBy(tuple => tuple.Item2).ToList())
            {
                Console.WriteLine($"{student.Item1}| {student.Item2}");
            }
            break;
    }
}