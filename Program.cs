// Coded by Arya Taheri
using GradeSheet;
using System.ComponentModel.Design;

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
        var s = new Semester(path);
    }
    catch
    {
        goto input;
    }

menu:
    Console.Clear();
    Console.WriteLine(@"Choose from menu:
    1: avarage of all the courses
    2: avarage of important courses
    3: avarage of good to know courses
    4: avarage of shit courses
    5: find prime number from students points
    6: show students with grades");
    switch (Console.ReadKey(true).Key)
    {

        case ConsoleKey.NumPad1:
            
            break;
        
        case ConsoleKey.NumPad2:
            break;
        
        case ConsoleKey.NumPad3:
            break;
        
        case ConsoleKey.NumPad4:
            break;
        
        case ConsoleKey.NumPad5:
            break;

        case ConsoleKey.NumPad6:
            break;

    }
