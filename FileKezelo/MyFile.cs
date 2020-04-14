using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileKezelo
{
  public class MyFile
  {
    StreamReader FileReader;
    StreamWriter FileWriter;
    FileStream StreamFile;

    public bool FileOlvaso(string fileName)
    {
      try
      {
        //StreamFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);        
        //FileReader = new StreamReader(StreamFile);
        //FileWriter = new StreamWriter(StreamFile);
        
        //string sor;
        //string[] adatok;
        string[] minden = File.ReadAllLines(fileName);
        //if((sor = FileReader.ReadLine()) != null)
        {
          //adatok = sor.Split('\t');
          //if (adatok.Length != 3) continue;
          //Console.WriteLine(minden);
          for (int i = 0; i < minden.Length; i++)
          {
            Console.WriteLine(minden[i]);
          }
        }
        return true;
      }
      catch(Exception ex)
      {
        string customMessage = "General Error";
        int errorCode = ex.HResult;
        ErrorHandler.PutError(customMessage, errorCode, RiskLevels.lowError);
        return false;
        //throw new ObjectDisposedException($"message:{customMessage}, \n errorcode:{errorCode}");
      }
    }
  }
  public static class ErrorHandler
  {
    public static int ErrorCode;
    public static RiskLevels ErrorLevel;
    //public static int FieldOfError;
    public static string CustomMessage;
    public delegate void ErrHandlerFn(string customMessage, int errorCode, RiskLevels RiskLevel);

    public static ErrHandlerFn myErrHandlerFn = null;

    public static void PutError(string customMessage, int errorCode, RiskLevels levels)
    {
      //értéket ír a 3 property be
      ErrorCode = errorCode;
      CustomMessage = customMessage;
      ErrorLevel = levels;
      if (myErrHandlerFn != null)
      {
        myErrHandlerFn(customMessage, errorCode, levels);
      }
    }
    public static void GetError(out string customMessage, out int errorCode, out RiskLevels levels)
    {
      customMessage = CustomMessage;
      errorCode = ErrorCode;
      levels = ErrorLevel;
    }
  }
  public enum RiskLevels
  {
    none = 0,
    warning = 1,
    lowError = 2,
    highError = 3,
    impossibleError = 4
  }
}
