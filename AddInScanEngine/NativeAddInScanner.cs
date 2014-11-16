// Decompiled with JetBrains decompiler
// Type: AddInSpy.NativeAddInScanner
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AddInSpy
{
  internal class NativeAddInScanner
  {
    private SecondaryExtensibility secondaryExtensibility;

    internal SecondaryExtensibility SecondaryExtensibility
    {
      get
      {
        return this.secondaryExtensibility;
      }
    }

    public NativeAddInScanner(string hostName)
    {
      this.secondaryExtensibility = new SecondaryExtensibility(hostName);
    }

    internal string GetSupportedInterfaces(string guid)
    {
      string str = (string) null;
      List<string> list = new List<string>();
      IntPtr pUnk = IntPtr.Zero;
      IntPtr ppv = IntPtr.Zero;
      if (guid == "{5B7AB748-6D2E-4827-90A5-32B426DC61B7}" || guid == "{EFEF7FDB-0CED-4FB6-B3BB-3C50D39F4120}" || guid == "{F959DBBB-3867-41F2-8E5F-3B8BEFAA81B3}")
      {
        Globals.AddErrorMessage(Resources.PROBLEM_OUTLOOK_ADDIN);
        return str;
      }
      else
      {
        try
        {
          pUnk = Marshal.GetIUnknownForObject(Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(guid), true)));
          foreach (KeyValuePair<string, Guid> keyValuePair in (IEnumerable<KeyValuePair<string, Guid>>) this.secondaryExtensibility.AddInInterfaces)
          {
            Guid iid = keyValuePair.Value;
            if (Marshal.QueryInterface(pUnk, ref iid, out ppv) >= 0 && ppv != IntPtr.Zero)
            {
              list.Add(keyValuePair.Key);
              Marshal.Release(ppv);
              ppv = IntPtr.Zero;
            }
          }
          if (list.Count > 0)
          {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < list.Count; ++index)
            {
              stringBuilder.Append(list[index]);
              if (index + 1 < list.Count)
                stringBuilder.Append(", ");
            }
            str = ((object) stringBuilder).ToString();
          }
          else
            str = Resources.SECONDARY_INTERFACES_NONE;
        }
        catch (FileNotFoundException ex)
        {
          Globals.AddException((Exception) ex);
        }
        catch (Exception ex)
        {
          Globals.AddException(ex);
        }
        finally
        {
          if (ppv != IntPtr.Zero)
            Marshal.Release(ppv);
          if (pUnk != IntPtr.Zero)
            Marshal.Release(pUnk);
        }
        return str;
      }
    }
  }
}
