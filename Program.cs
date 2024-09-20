<<<<<<< HEAD
﻿using Newtonsoft.Json;
=======
﻿using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.VisualBasic;


// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }


// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         if (file.EndsWith("sales.json")) salesFiles.Add(file);
//     }

//     return salesFiles;
// }


// Console.WriteLine(Directory.GetCurrentDirectory());
// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);
// string downldPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
// Console.WriteLine(downldPath);


// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// Console.WriteLine(Path.Combine("stores", "201"));


// Console.WriteLine(Path.GetExtension("sales.json"));

// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);

// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");


// var currentDirectory = Directory.GetCurrentDirectory();

// var storesDirectory = Path.Combine(currentDirectory, "stores");

// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }


// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);

//         if (extension == ".json") salesFiles.Add(file);
//     }

//     return salesFiles;
// }


// var filePath =  Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir");

// bool doesDirectoryExist = Directory.Exists(filePath);

// if (!doesDirectoryExist) 
// {
//     Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir"));
// }
// else Console.WriteLine("Directory Exists.");

// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");


// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);

//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }


// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");

// var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");

// Directory.CreateDirectory(salesTotalDir);

// var salesFiles = FindFiles(storesDirectory);

// File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

// var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// // Console.WriteLine(salesJson);

// var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

// Console.WriteLine(salesData?.Total);

// var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

// File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data?.Total.ToString()}{Environment.NewLine}");

// File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data?.Total}{Environment.NewLine}");

// class SalesTotal 
// {
//     public double Total { get; set; }
// }



>>>>>>> c5444ec685af21d94fbeec0825d49d1f3b40657e

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
<<<<<<< HEAD
=======

>>>>>>> c5444ec685af21d94fbeec0825d49d1f3b40657e
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);

        if (extension == ".json") salesFiles.Add(file);
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

<<<<<<< HEAD
    List<Tuple<string, double>> filesSales = new List<Tuple<string, double>>();

    string writeData = String.Empty;

    foreach (var file in salesFiles)
    {
        var fileName = $"{Path.GetFileName(Path.GetDirectoryName(file))}{Path.DirectorySeparatorChar}{Path.GetFileName(file)}";

=======
    foreach (var file in salesFiles)
    {
>>>>>>> c5444ec685af21d94fbeec0825d49d1f3b40657e
        string salesJson = File.ReadAllText(file);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        salesTotal += data?.Total ?? 0;
<<<<<<< HEAD

        filesSales.Add(new Tuple<string, double>(fileName, data?.Total ?? 0.0));
    }

    writeData += $"Sales Summary{Environment.NewLine}";
    writeData += $"---------------------{Environment.NewLine}";

    writeData += $"Total Sales: ${Math.Round(salesTotal, 2)}{Environment.NewLine}";
    writeData += $"{Environment.NewLine}Details:{Environment.NewLine}";



    foreach (var tup in filesSales)
    {
        writeData += $"\t{tup.Item1}: ${tup.Item2}{Environment.NewLine}";
    }

    File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}sales-summary.txt", writeData);

    return salesTotal;
}

record SalesData(double Total);
=======
    }

    return salesTotal;
}

record SalesData (double Total);
>>>>>>> c5444ec685af21d94fbeec0825d49d1f3b40657e
