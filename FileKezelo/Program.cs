using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileKezelo
{
  class Program
  {
    static void Main(string[] args)
    {
      string fileName = "text.txt"; 
      try
      {
        var myFile = new MyFile(fileName);
      }
      catch(IOException ioEx)
      {
        Console.WriteLine($"bocs valami rosszul ment: \n {ioEx}");
      }
      finally
      {
        Console.WriteLine("Program vége");
      }
      Console.ReadKey();   
    }
  }
}
