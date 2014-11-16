// Decompiled with JetBrains decompiler
// Type: AddInSpy.ComAddInUtilities
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AddInSpy
{
  internal class ComAddInUtilities
  {
    internal static NativeMethods.COMAddIn GetLoadedCOMAddInObjects(ref AddInData addInData)
    {
      addInData.IsRunning = false;
      addInData.IsLoaded = false;
      addInData.IsObjectExposed = false;
      object app = (object) null;
      NativeMethods.COMAddIn comAddIn = (NativeMethods.COMAddIn) null;
      addInData.IsRunning = ComAddInUtilities.GetRunningApplicationObject(addInData.HostName, out app);
      if (addInData.IsRunning)
      {
        addInData.IsLoaded = ComAddInUtilities.GetCOMAddIn(app, addInData.ProgId, out comAddIn);
        if (addInData.IsLoaded && comAddIn.Object != null)
          addInData.IsObjectExposed = true;
      }
      return comAddIn;
    }

    private static bool GetRunningApplicationObject(string hostName, out object app)
    {
      bool flag = false;
      app = (object) null;
      try
      {
        switch (hostName)
        {
          case "Access":
            app = Marshal.GetActiveObject("Access.Application");
            break;
          case "Excel":
            app = Marshal.GetActiveObject("Excel.Application");
            break;
          case "FrontPage":
            app = Marshal.GetActiveObject("FrontPage.Application");
            break;
          case "InfoPath":
            app = Marshal.GetActiveObject("InfoPath.Application");
            break;
          case "Outlook":
            app = Marshal.GetActiveObject("Outlook.Application");
            break;
          case "PowerPoint":
            app = Marshal.GetActiveObject("PowerPoint.Application");
            break;
          case "Project":
            app = Marshal.GetActiveObject("MSProject.Application");
            break;
          case "Publisher":
            app = Marshal.GetActiveObject("Publisher.Application");
            break;
          case "SharePoint Designer":
            app = Marshal.GetActiveObject("SharePointDesigner.Application");
            break;
          case "Visio":
            app = Marshal.GetActiveObject("Visio.Application");
            break;
          case "Word":
            app = Marshal.GetActiveObject("Word.Application");
            break;
        }
        flag = true;
      }
      catch (Exception ex)
      {
      }
      return flag;
    }

    private static bool GetCOMAddIn(object app, string addInProgId, out NativeMethods.COMAddIn comAddIn)
    {
      bool flag = false;
      comAddIn = (NativeMethods.COMAddIn) null;
      long num = -2147418111L;
      if (app != null)
      {
        Type type = app.GetType();
        try
        {
          NativeMethods.COMAddIns comAddIns = (NativeMethods.COMAddIns) type.InvokeMember("COMAddIns", BindingFlags.GetProperty, (Binder) null, app, (object[]) null);
          if (comAddIns != null)
          {
            foreach (NativeMethods.COMAddIn comAddIn1 in (IEnumerable) comAddIns)
            {
              if (comAddIn1.ProgId == addInProgId)
              {
                comAddIn = comAddIn1;
                if (comAddIn.Connect)
                {
                  flag = true;
                  break;
                }
                else
                  break;
              }
            }
          }
        }
        catch (COMException ex)
        {
          if ((long) ex.ErrorCode == num)
            Globals.AddErrorMessage(Resources.RPC_E_CALL_REJECTED_MESSAGE);
          else
            Globals.AddException((Exception) ex);
        }
      }
      return flag;
    }
  }
}
