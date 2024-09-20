using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
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

    List<Tuple<string, double>> filesSales = new List<Tuple<string, double>>();

    string writeData = String.Empty;

    foreach (var file in salesFiles)
    {
        var fileName = $"{Path.GetFileName(Path.GetDirectoryName(file))}{Path.DirectorySeparatorChar}{Path.GetFileName(file)}";

        string salesJson = File.ReadAllText(file);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        salesTotal += data?.Total ?? 0;

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