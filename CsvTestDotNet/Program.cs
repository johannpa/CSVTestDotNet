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

var records = csv.GetRecords<PersonModel>();

foreach (var record in records)
{
    
   Console.WriteLine(record.FirstName + " " + record.LastName);
    
}