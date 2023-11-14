// Coded by Arya Taheri
using GradeSheet;

void executer(){
    string path = null;
    do
    {
        Console.WriteLine("Students File?: ");
        path = Console.ReadLine();
        if (path == null)
        {
            Console.WriteLine("bad input try again");
        }
    } while (path != null);

    try
    {
        var s = new Semester(path);
    }
    catch {
        executer();
    }
}