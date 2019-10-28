using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Handlebars_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {

                try
                {
                    Random rnd = new Random();
                    int test1 = rnd.Next(1, 30);
                    int test2 = rnd.Next(1, 30);
                    int test3 = rnd.Next(1, 30);
                    int test4 = rnd.Next(1, 30);

                    var context = new
                    {

                        uleft = string.Format("{0}", test1),
                        uright = string.Format("{0}", test2),
                        lleft = string.Format("{0}", test3),
                        lright = string.Format("{0}", test4),
                        footer = DateTime.Now
                    };

                    using (StreamReader sr = new StreamReader("template.html"))
                    {
                        String lines = sr.ReadToEnd();
                        sr.Close();

                        Console.WriteLine(lines);
                        var templateScript = Handlebars.Compile(lines);
                        var result = templateScript(context);
                        // Displaying the results
                        Console.WriteLine(result);



                        using (StreamWriter outputFile = new StreamWriter("index.html"))
                        {
                            foreach (char line in result)
                            {
                                outputFile.Write(line);
                            }
                        }


                        //Console.ReadLine();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                System.Threading.Thread.Sleep(10000);
            } while (true);
            


        }
    }
}
