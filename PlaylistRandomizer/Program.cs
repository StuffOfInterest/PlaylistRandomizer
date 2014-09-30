using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistRandomizer
{
    class Program
    {
        public static Random random = new Random();

        static void Main(string[] args)
        {
            var filename = @"C:\Users\Delbert\Documents\Visual Studio 2013\Projects\PlaylistRandomizer\PlaylistRandomizer\input.m3u";
            var outfilename = @"C:\Users\Delbert\Documents\Visual Studio 2013\Projects\PlaylistRandomizer\PlaylistRandomizer\output.m3u";
            
            string line;
            string header;
            var records = new List<Record>();

            using (var reader = new StreamReader(filename))
            {
                header = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    var record = new Record();
                    record.sortkey = random.NextDouble();
                    record.line1 = line;
                    record.line2 = reader.ReadLine();
                    records.Add(record);

                    Console.WriteLine(line);
                }
            }
            Console.WriteLine(string.Format("Read in {0} records.", records.Count));

            var sortedRecords = records.OrderBy(o => o.sortkey).ToList();

            using (var writer = new StreamWriter(outfilename))
            {
                writer.WriteLine(header);
                foreach (var record in sortedRecords)
                {
                    writer.WriteLine(record.line1);
                    writer.WriteLine(record.line2);
                }
            }

            Console.ReadLine();
        }
    }

    public class Record
    {
        public double sortkey { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
    }
}
