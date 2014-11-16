// Decompiled with JetBrains decompiler
// Type: AddInSpy.RegistryReader
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Text;

namespace AddInSpy
{
  internal class RegistryReader
  {
    private static string formRegionRegKeyName = "Software\\Microsoft\\Office\\Outlook\\FormRegions";

    internal static void GetAddInsRegHiveNames(RegistryKey regHive, string hostName, out string regHiveName, out string officeRegKeyName)
    {
      regHiveName = (string) null;
      officeRegKeyName = (string) null;
      regHiveName = regHive != Registry.CurrentUser ? "HKLM" : "HKCU";
      if (hostName == "Visio")
        officeRegKeyName = "Software\\Microsoft\\Visio\\Addins";
      else if (hostName == "Project")
        officeRegKeyName = "Software\\Microsoft\\Office\\MS Project\\Addins";
      else
        officeRegKeyName = "Software\\Microsoft\\Office\\" + hostName + "\\Addins";
    }

    internal static string GetInprocServerFromClsid(string clsid, string codeBase)
    {
      string uriString = (string) null;
      try
      {
        RegistryKey registryKey;
        using (registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + clsid + "\\InprocServer32"))
        {
          if (registryKey != null)
          {
            uriString = (string) registryKey.GetValue(codeBase);
            if (uriString != null && uriString.StartsWith("file:///"))
              uriString = new Uri(uriString).LocalPath;
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return uriString;
    }

    internal static bool GetIsManagedCodeCategoryRegistered(string clsid)
    {
      bool flag = false;
      try
      {
        RegistryKey registryKey;
        using (registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + clsid + "\\Implemented Categories\\{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}"))
        {
          if (registryKey != null)
            flag = true;
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return flag;
    }

    internal static bool GetIsMscoreeRegistered(string clsid)
    {
      bool flag = false;
      try
      {
        RegistryKey registryKey;
        using (registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + clsid + "\\InprocServer32"))
        {
          if (registryKey != null)
          {
            if (((string) registryKey.GetValue((string) null)).Equals("mscoree.dll", StringComparison.InvariantCultureIgnoreCase))
              flag = true;
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return flag;
    }

    internal static string GetCLSIDFromProgID(string progId)
    {
      string str = (string) null;
      try
      {
        using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(progId + "\\CLSID"))
        {
          if (registryKey != null)
            str = (string) registryKey.GetValue((string) null);
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return str;
    }

    internal static bool ReadResiliencyRegistryKeys(string hostName, string addInPath, string addInFriendlyName, out string disabledStatus)
    {
      disabledStatus = string.Empty;
      bool flag = false;
      string[] strArray = new string[2]
      {
        "11.0",
        "12.0"
      };
      foreach (string officeVersion in strArray)
      {
        if (RegistryReader.ReadDisabledItems(hostName, officeVersion, addInPath, addInFriendlyName))
        {
          string str = string.Format(Resources.ADDIN_DISABLED, (object) hostName, (object) officeVersion);
          disabledStatus = disabledStatus.Length != 0 ? string.Format("{0} {1}", (object) disabledStatus, (object) str) : str;
          flag = true;
        }
      }
      return flag;
    }

    private static bool ReadDisabledItems(string appName, string officeVersion, string addInPath, string addInFriendlyName)
    {
      bool flag = false;
      string name1 = string.Format("Software\\Microsoft\\Office\\{0}\\{1}\\Resiliency\\DisabledItems", (object) officeVersion, (object) appName);
      try
      {
        using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name1))
        {
          if (registryKey != null)
          {
            foreach (string name2 in registryKey.GetValueNames())
            {
              Encoding unicode = Encoding.Unicode;
              byte[] bytes = (byte[]) registryKey.GetValue(name2);
              char[] chars = new char[unicode.GetCharCount(bytes, 0, bytes.Length)];
              unicode.GetChars(bytes, 0, bytes.Length, chars, 0);
              string str1 = new string(chars);
              int length1 = str1.LastIndexOf(char.MinValue);
              string str2 = str1.Substring(0, length1);
              int length2 = str2.LastIndexOf(char.MinValue);
              string str3 = str2.Substring(0, length2);
              int num = str3.LastIndexOf(char.MinValue);
              string strB1 = str3.Substring(num + 1);
              string strB2 = str2.Substring(length2 + 1, str1.Length - length2 - 2);
              if (string.Compare(addInPath, strB1, true) == 0 && string.Compare(addInFriendlyName, strB2, true) == 0)
              {
                flag = true;
                break;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return flag;
    }

    internal static NameValueCollection ReadFormRegionRegistrations(RegistryKey regHive)
    {
      NameValueCollection nameValueCollection = new NameValueCollection();
      try
      {
        using (RegistryKey registryKey1 = regHive.OpenSubKey(RegistryReader.formRegionRegKeyName))
        {
          if (registryKey1 != null)
          {
            foreach (string name1 in registryKey1.GetSubKeyNames())
            {
              using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
              {
                foreach (string name2 in registryKey2.GetValueNames())
                {
                  string name3 = ((string) registryKey2.GetValue(name2)).TrimStart('=');
                  string str = string.Format(Resources.MESSAGECLASS_FORMREGION, (object) name1, (object) name2);
                  nameValueCollection.Add(name3, str);
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return nameValueCollection;
    }
  }
}
