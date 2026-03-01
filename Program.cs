using System;

class Program
{
    static void Main()
    {
        // Create the hash table
        SimpleHashTable sh = new SimpleHashTable();

        // Put a value in
        sh.Insert("age", 42);

        // Get the value backgit
        int? result = sh.GetValue("age");

        // Print it
        Console.WriteLine(result);
    }
}