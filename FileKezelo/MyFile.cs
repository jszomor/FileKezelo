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
    public bool FileOlvaso(string fileName)
    {
      try
      {
        string newFile = "ujFile.txt";
        Encoding e = Encoding.GetEncoding(1250);
        FileStream openFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
        string beolvasottSor;
        string ujsor;
        using (StreamReader fileToRead = new StreamReader(openFile, e))
        {
          StreamWriter fileToWrite = new StreamWriter(newFile, false, e);

          while ((beolvasottSor = fileToRead.ReadLine()) != null)
          {
            ujsor = beolvasottSor.Replace("utca", "park");
            fileToWrite.WriteLine(ujsor);
          }
          fileToWrite.Close();
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
