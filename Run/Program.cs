// See https://aka.ms/new-console-template for more information
using Run;
using System.Text.Json;

Console.WriteLine("Hello, World!");

List<Block> blocks = new List<Block>();

string path = @"C:\Users\rvs\Desktop\Modul_2\Task3 - Blocks";

var files = Directory.GetFiles(path);
foreach (var file in files)
{
    var block = JsonSerializer.Deserialize<Block>(File.ReadAllText(file));
    if(block != null)
    {
        blocks.Add(block);
    }    
}

var exercise1 = blocks.Where(x => x.hash.StartsWith("000") && x.hash.EndsWith("000")).ToArray();

var exercise2 = blocks.Where(x => x.secret_info != "").ToArray();

var exercise3 = blocks.Select(x => x.transactions.Sum(c=>c.value)).Sum();

var exercise4 = blocks.DistinctBy(x=>x.hash).ToArray();

var exercise5 = blocks.DistinctBy(x => x.pre_hash).ToArray();

Console.WriteLine("Конец");


