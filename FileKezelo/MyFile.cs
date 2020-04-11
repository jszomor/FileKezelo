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
        StreamFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
        FileReader = new StreamReader(StreamFile);
        FileWriter = new StreamWriter(StreamFile);
      }
      catch(IOException e)
      {
        string customMessage = e.Message;
        int errorCode = e.HResult;
        ErrorHandler.PutError(customMessage, errorCode);
        throw new IOException($"message:{customMessage}, \n errorcode:{errorCode}");
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
