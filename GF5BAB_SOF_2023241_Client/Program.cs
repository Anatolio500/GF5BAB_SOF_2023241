using GF5BAB_SOF_2023241_Webapp.Models;
using Newtonsoft.Json;
using System.Net;

System.Threading.Thread.Sleep(10000);

var wc = new WebClient();
var data = JsonConvert.DeserializeObject<IEnumerable<Part>>(wc.DownloadString("https://localhost:7142/api"));

Console.WriteLine("Parts count in the database: " +  data.Count());
Console.WriteLine("////////////////////////////////////////////////////////////");
Console.WriteLine();

foreach (var item in data)
{

    Console.WriteLine("Part's name: " + item.Name);
    Console.WriteLine("Part's serial number: " + item.SerialNumber);
    Console.WriteLine("---------------------------------------");
}