// CSV for Comma Separated Values
// 1, Mike, Tysan, 555-1313

using CsvHelper;
using CsvTestDotNet;
using System.Globalization;

string inputFile = @"C:\CSVFileTest\people-100.csv";
string outputFile = @"C:\CSVFileTest\filtered-people.csv";

List<PersonModel> outputRecords = new();

using var reader = new StreamReader(inputFile);
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
int i = 0;

var records = csv.GetRecords<PersonModel>();

foreach (var record in records)
{
    if (record.FirstName.StartsWith("S"))
    {
        outputRecords.Add(record);
    }
    Console.WriteLine(record.FirstName + " " + record.LastName);
    i++;
}


Console.WriteLine($"Number of records: {outputRecords.Count()}");

using var writer = new StreamWriter(outputFile);
using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);

csvOut.WriteRecords(outputRecords);