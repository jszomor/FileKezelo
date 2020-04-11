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
      string fileName = "21esBusz.txt"; 
      try
      {
        var myFile = new MyFile(fileName);
      }
      catch (NullReferenceException ex)
      {
        Console.WriteLine("ErrorCode: {0}", ErrorHandler.ErrorCode);
        Console.WriteLine("Message: {0}", ErrorHandler.CustomMessage);
        Console.ReadKey();
        Console.WriteLine($"bocs valami rosszul ment: \n {ex}");
      }
      catch (ObjectDisposedException dispEx)
      {
        Console.WriteLine("ErrorCode: {0}", ErrorHandler.ErrorCode);
        Console.WriteLine("Message: {0}", ErrorHandler.CustomMessage);
        Console.ReadKey();
        Console.WriteLine($"bocs valami rosszul ment: \n {dispEx}");
      }
      catch (IOException ioEx)
      {

        Console.WriteLine("ErrorCode: {0}", ErrorHandler.ErrorCode);
        Console.WriteLine("Message: {0}", ErrorHandler.CustomMessage);
        Console.ReadKey();
        Console.WriteLine($"bocs valami rosszul ment: \n {ioEx}");
      }
      catch (Exception ex)
      {

        Console.WriteLine("ErrorCode: {0}", ErrorHandler.ErrorCode);
        Console.WriteLine("Message: {0}", ErrorHandler.CustomMessage);
        Console.ReadKey();
        Console.WriteLine($"bocs valami rosszul ment: \n {ex}");
      }
      finally
      {
        Console.WriteLine("Program vége");
      }
      Console.ReadKey();   
    }
  }
}
