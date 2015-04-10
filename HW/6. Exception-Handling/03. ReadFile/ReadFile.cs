// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the  console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Text;

class ReadFile
{
    static string FilePath()
    {
        Console.Write("Enter patch to the file: ");
        string filePath = Console.ReadLine();
        return filePath;
    }

    static void ReadingFile(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            string fileContents = reader.ReadToEnd();
            Console.WriteLine(fileContents);
        }
    }

    static void Main()
    {
        try
        {
            ReadingFile(FilePath());
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Could not find file: ");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("invalid path to the file");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access is denied you do not have read permission");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("The file cannot be opened due to I/O error.");
        }
    }
}

// C:\WINDOWS\win.ini