// Decompiled with JetBrains decompiler
// Type: AddInSpy.Globals
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System;

namespace AddInSpy
{
  internal class Globals
  {
    private static string errorMessage = (string) null;

    internal static string ErrorMessage
    {
      get
      {
        return Globals.errorMessage;
      }
      set
      {
        Globals.errorMessage = value;
      }
    }

    private Globals()
    {
    }

    internal static void AddErrorMessage(string newMessage)
    {
      if (Globals.errorMessage == null || Globals.errorMessage.Length == 0)
        Globals.errorMessage = newMessage;
      else
        Globals.errorMessage = string.Format("{0} {1}", (object) Globals.errorMessage, (object) newMessage);
    }

    internal static void AddException(Exception ex)
    {
      Globals.AddErrorMessage(ex.ToString());
    }
  }
}
