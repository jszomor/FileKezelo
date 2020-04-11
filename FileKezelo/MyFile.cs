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

    public MyFile(string fileName)
    {
      try
      {
        //using (StreamFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
        //{
        //  FileReader = new StreamReader(StreamFile);
        //  FileWriter = new StreamWriter(StreamFile);
        //}
        string sor;
        string[] adatok;
        string[] minden = File.ReadAllLines(fileName);
        if((sor = FileReader.ReadLine()) != null)
        {
          //adatok = sor.Split('\t');
          //if (adatok.Length != 3) continue;
          //Console.WriteLine(minden);
          for (int i = 0; i < minden.Length; i++)
          {
            Console.WriteLine(minden[i]);
          }
        }
      }
      catch(ObjectDisposedException dispEx)
      {
        string customMessage = "ObjectDisposedException";
        int errorCode = dispEx.HResult;
        ErrorHandler.PutError(customMessage, errorCode);
        throw new ObjectDisposedException($"message:{customMessage}, \n errorcode:{errorCode}");
      }
      catch(NullReferenceException ex)
      {
        string customMessage = "NullReferenceException";
        int errorCode = ex.HResult;
        ErrorHandler.PutError(customMessage, errorCode);
        throw new NullReferenceException($"message:{customMessage}, \n errorcode:{errorCode}");
      }
      catch(IOException e)
      {
        string customMessage = e.Message;
        int errorCode = e.HResult;
        ErrorHandler.PutError(customMessage, errorCode);
        throw new IOException($"message:{customMessage}, \n errorcode:{errorCode}");
      }
      catch(Exception ex)
      {
        string customMessage = "Genaral Error";
        int errorCode = ex.HResult;
        ErrorHandler.PutError(customMessage, errorCode);
        throw new ObjectDisposedException($"message:{customMessage}, \n errorcode:{errorCode}");
      }
    }
  }
  public static class ErrorHandler
  {
    public static int ErrorCode;
    public static int RiskLevel;
    public static int FieldOfError;
    public static string CustomMessage;

    public static void PutError(string customMessage, int errorCode)
    {
      //értéket ír a 3 property be
      ErrorCode = errorCode;
      CustomMessage = customMessage;
    }
    public static void GetError()
    {
      //kiveszti az értéket a 3 property ből
    }
  }
}
