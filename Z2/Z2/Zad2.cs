using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    class Zad2
    {

        public static Task<int[][]> ReadAllLinesAsync(string path)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8);
        }

        public static async Task<int[][]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            var lines = new List<string>();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 512, FileOptions.Asynchronous))
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }
            }

            var result = lines.Select(x => (x.Split(' ').Select(Int32.Parse).ToArray())).ToArray();

            return result;
        }

        public Zad2(int a, int b)
        {
            ReadAllLinesAsync("abc.txt").ContinueWith(
                (t) => {
                    int[][] table = t.Result;
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            Console.Write(table[i][j] + " ");
                        }
                        Console.WriteLine();
                    }
                });
        }


    }
}
