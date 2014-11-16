// Decompiled with JetBrains decompiler
// Type: AddInSpy.AssemblyScanner
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace AddInSpy
{
  internal class AssemblyScanner
  {
    private string ribbonTypeName = "Microsoft.Office.Tools.Ribbon.OfficeRibbon";
    private string formRegionTypeName = "Microsoft.Office.Tools.Outlook.FormRegionControl";
    private Type[] exportedTypes;
    private string assemblyFolder;

    public string[] GetAssemblyInfo(string fileName, string hostName, bool isVstoAddIn)
    {
      string[] strArray = (string[]) null;
      try
      {
        this.assemblyFolder = Path.GetDirectoryName(fileName);
        Assembly assembly = Assembly.ReflectionOnlyLoadFrom(fileName);
        this.exportedTypes = assembly.GetExportedTypes();
        ArrayList assemblyInfo = new ArrayList();
        assemblyInfo.Add((object) assembly.FullName);
        assemblyInfo.Add((object) assembly.ImageRuntimeVersion);
        if (isVstoAddIn)
        {
          this.CheckFormRegionType(assembly, ref assemblyInfo);
          this.CheckRibbonType(ref assemblyInfo);
          this.CheckCustomTaskPaneType(assembly, ref assemblyInfo);
        }
        int num = 0;
        foreach (KeyValuePair<string, Guid> keyValuePair in (IEnumerable<KeyValuePair<string, Guid>>) new SecondaryExtensibility(hostName).AddInInterfaces)
        {
          if (this.IsInterfaceImplemented(keyValuePair.Value))
          {
            assemblyInfo.Add((object) keyValuePair.Key);
            ++num;
          }
        }
        if (assemblyInfo.Count < 3)
          assemblyInfo.Add((object) Resources.SECONDARY_INTERFACES_NONE);
        strArray = (string[]) assemblyInfo.ToArray(typeof (string));
      }
      catch (TypeLoadException ex)
      {
        Globals.AddErrorMessage(string.Format(Resources.TYPELOADEXCEPTION_MESSAGE, (object) Environment.NewLine, (object) fileName, (object) ex.ToString()));
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return strArray;
    }

    private bool IsInterfaceImplemented(Guid iid)
    {
      bool flag = false;
      foreach (Type type in this.exportedTypes)
      {
        if (type.FindInterfaces(new TypeFilter(AssemblyScanner.InterfaceFilterHandler), (object) iid).Length > 0)
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    private static bool InterfaceFilterHandler(Type type, object filterCondition)
    {
      bool flag = false;
      if (type != null && type.GUID == (Guid) filterCondition)
        flag = true;
      return flag;
    }

    internal Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
    {
      Assembly assembly = (Assembly) null;
      string assemblyName = args.Name.Split(',')[0];
      try
      {
        try
        {
          string assemblyFile = Path.Combine(this.assemblyFolder, assemblyName + ".dll");
          if (assemblyFile != null && assemblyFile.Length > 0)
          {
            try
            {
              assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
            }
            catch (Exception ex1)
            {
              try
              {
                assembly = Assembly.ReflectionOnlyLoadFrom(this.GetAssemblyGacPath(assemblyName));
              }
              catch (Exception ex2)
              {
                assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile + ".deploy");
              }
            }
          }
        }
        catch (Exception ex1)
        {
          string assemblyFile = Path.Combine(this.assemblyFolder, assemblyName + ".exe");
          if (assemblyFile != null && assemblyFile.Length > 0)
          {
            try
            {
              assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
            }
            catch (Exception ex2)
            {
              try
              {
                assembly = Assembly.ReflectionOnlyLoadFrom(this.GetAssemblyGacPath(assemblyName));
              }
              catch (Exception ex3)
              {
                assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile + ".deploy");
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
      return assembly;
    }

    private string GetAssemblyGacPath(string assemblyName)
    {
      string str1 = (string) null;
      GacEnumerator gacEnumerator = new GacEnumerator(assemblyName);
      string str2 = string.Empty;
      while (true)
      {
        string nextAssembly = gacEnumerator.GetNextAssembly();
        try
        {
          if (nextAssembly != null)
          {
            if (str2 != string.Empty && this.CompareVersionNumbers(str2, nextAssembly) == 1)
            {
              str1 = GacEnumerator.QueryAssemblyInfo(str2);
              break;
            }
            else
            {
              str1 = GacEnumerator.QueryAssemblyInfo(nextAssembly);
              str2 = nextAssembly;
            }
          }
          else
            break;
        }
        catch (Exception ex)
        {
          Globals.AddException(ex);
        }
      }
      return str1;
    }

    public int CompareVersionNumbers(string assemblyA, string assemblyB)
    {
      int num = 0;
      string[] strArray1 = assemblyA.Split(',')[1].Substring("Version=".Length + 1).Split('.');
      string[] strArray2 = assemblyB.Split(',')[1].Substring("Version=".Length + 1).Split('.');
      int[] numArray1 = new int[4];
      int[] numArray2 = new int[4];
      for (int index = 0; index < 4; ++index)
      {
        numArray1[index] = Convert.ToInt32(strArray1[index]);
        numArray2[index] = Convert.ToInt32(strArray2[index]);
      }
      if (numArray1[0] < numArray2[0])
        num = -1;
      else if (numArray1[0] > numArray2[0])
        num = 1;
      else if (numArray1[1] < numArray2[1])
        num = -1;
      else if (numArray1[1] > numArray2[1])
        num = 1;
      else if (numArray1[2] < numArray2[2])
        num = -1;
      else if (numArray1[2] > numArray2[2])
        num = 1;
      else if (numArray1[3] < numArray2[3])
        num = -1;
      else if (numArray1[3] > numArray2[3])
        num = 1;
      return num;
    }

    private void CheckFormRegionType(Assembly assembly, ref ArrayList assemblyInfo)
    {
      try
      {
        foreach (Type type in assembly.GetTypes())
        {
          if (type.BaseType != null && type.BaseType.FullName == this.formRegionTypeName)
          {
            assemblyInfo.Add((object) Resources.VSTO_FORMREGION);
            break;
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
    }

    private void CheckRibbonType(ref ArrayList assemblyInfo)
    {
      foreach (Type type in this.exportedTypes)
      {
        if (type.BaseType != null && type.BaseType.BaseType != null && (type.BaseType.FullName == this.ribbonTypeName || type.BaseType.BaseType.FullName == this.ribbonTypeName))
        {
          assemblyInfo.Add((object) Resources.VSTO_RIBBON);
          break;
        }
      }
    }

    private void CheckCustomTaskPaneType(Assembly assembly, ref ArrayList assemblyInfo)
    {
      try
      {
        foreach (Type type in assembly.GetTypes())
        {
          foreach (MethodBase method1 in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
          {
            foreach (MethodInstruction methodInstruction in new ILReader(method1))
            {
              try
              {
                if (methodInstruction != null)
                {
                  if (methodInstruction.OpCode == OpCodes.Callvirt)
                  {
                    MethodBase method2 = methodInstruction.Method;
                    if (method2 != null && string.Format("{0}.{1}", (object) method2.DeclaringType, (object) method2.Name) == "Microsoft.Office.Tools.CustomTaskPaneCollection.Add")
                      assemblyInfo.Add((object) Resources.VSTO_TASKPANE);
                  }
                }
              }
              catch (Exception ex)
              {
                Debug.WriteLine(ex.ToString());
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
    }
  }
}
