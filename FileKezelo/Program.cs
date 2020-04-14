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
    static void FirstErrHandlerFn(string customMessage, int errorCode, RiskLevels RiskLevel)
    {
      Console.WriteLine(customMessage);
    }
    static void Main(string[] args)
    {
      string fileName = "21esBusz22.txt";      
      var myFile = new MyFile();
      string customMessage;
      int errorCode;
      ErrorHandler.myErrHandlerFn = FirstErrHandlerFn;
      RiskLevels levels;
      if (myFile.FileOlvaso(fileName) == false)
      {
        ErrorHandler.GetError(out customMessage, out errorCode, out levels);
        Console.WriteLine("customMessage:{0} \n errorCode:{1} \n levels:{2}", customMessage, errorCode, levels);
      }
      else
      {

      }
      Console.ReadKey();   
    }
  }
}
