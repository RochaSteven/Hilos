using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
namespace ParaleloTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\Hogar\foto1\";
            string path2 = @"C:\Users\Hogar\foto2\";
            string path3 = @"C:\Users\Hogar\foto3\";
            string[] lst = Directory.GetFiles(path1);
            Random r = new Random(99999999);
            Random r1 = new Random(99999999);


            //Copia de imágenes en serie
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var archivos1 in lst)
            {
                int a = r.Next();
                File.Copy(archivos1, path3 + "imagen" + a + ".jpg");
                
            }
            stopwatch.Stop();
            var ticks = stopwatch.ElapsedTicks;

            //Copia de imágenes en paralelo

            stopwatch.Start();
            Parallel.ForEach(lst, (archivo) =>
             {
              
                 int a = r1.Next();
                 File.Copy(archivo, path2 + "im" + a + ".jpg");
             });
           
            stopwatch.Stop();
            
            var ticks1 = stopwatch.ElapsedTicks;
            Console.WriteLine("se demoro en serie: " + ticks1);
            Console.WriteLine("se demoro en paralelo: " + ticks);

        }
    }
}
