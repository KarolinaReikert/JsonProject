using System.Text.Json;

namespace JsonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Raimonds", 32, false);
            Worker worker2 = new Worker("Anna", 31, true);
            Worker worker3 = new Worker("Toms", 25, true);

            string jsonStringWorker1 = JsonSerializer.Serialize(worker1);
            Console.WriteLine(jsonStringWorker1);
           
            File.WriteAllText("ThisIsWorker1.json", jsonStringWorker1);
            
            Worker sameObjectWorker = JsonSerializer.Deserialize<Worker>(jsonStringWorker1);
            
            Console.WriteLine($"Worker name: {sameObjectWorker.Name}");
            Console.WriteLine($"Worker age: {sameObjectWorker.Age}");
            Console.WriteLine($"Workers car: {sameObjectWorker.Car}");

            List<Worker> workers = new List<Worker>();

            workers.Add( worker1 );
            workers.Add( worker2 );
            workers.Add( worker3 );

            var jsonDataWorkers = JsonSerializer.Serialize(workers);

            Console.WriteLine(jsonDataWorkers);

            var listFromJson = JsonSerializer.Deserialize<List<Worker>>(jsonDataWorkers);

            var getLinq = from item in listFromJson
                          select item;


        }
        static void ShowListValues(IEnumerable<Worker> list)
        {
            foreach(Worker elementData in list)
            {
                Console.WriteLine($"Worker name: {elementData.Name}");
                Console.WriteLine($"Worker age: {elementData.Age}");
                Console.WriteLine($"Workers car: {elementData.Car}");
            }
        }
    }
}