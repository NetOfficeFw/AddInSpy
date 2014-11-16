// Decompiled with JetBrains decompiler
// Type: AddInSpy.GacEnumerator
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.Text;

namespace AddInSpy
{
  internal class GacEnumerator
  {
    private NativeMethods.IAssemblyEnum assemblyEnum = (NativeMethods.IAssemblyEnum) null;
    private bool done;

    public GacEnumerator(string assemblyName)
    {
      NativeMethods.IAssemblyName ppAssemblyNameObj = (NativeMethods.IAssemblyName) null;
      if (assemblyName == null)
        return;
      NativeMethods.CreateAssemblyNameObject(out ppAssemblyNameObj, assemblyName, NativeMethods.CreateAssemblyNameObjectFlags.CANOF_PARSE_DISPLAY_NAME, IntPtr.Zero);
      NativeMethods.CreateAssemblyEnum(out this.assemblyEnum, IntPtr.Zero, ppAssemblyNameObj, NativeMethods.AssemblyCacheFlags.GAC, IntPtr.Zero);
    }

    public static string QueryAssemblyInfo(string assemblyName)
    {
      if (assemblyName == null)
        throw new ArgumentException(Resources.INVALID_ASSEMBLYNAME, "assemblyName");
      NativeMethods.AssemblyInfo assemblyInfo = new NativeMethods.AssemblyInfo();
      assemblyInfo.cchBuf = 1024;
      assemblyInfo.currentAssemblyPath = new string(char.MinValue, assemblyInfo.cchBuf);
      NativeMethods.IAssemblyCache ppAsmCache = (NativeMethods.IAssemblyCache) null;
      NativeMethods.CreateAssemblyCache(out ppAsmCache, 0);
      ppAsmCache.QueryAssemblyInfo(0, assemblyName, ref assemblyInfo);
      return assemblyInfo.currentAssemblyPath;
    }

    public string GetNextAssembly()
    {
      NativeMethods.IAssemblyName ppName = (NativeMethods.IAssemblyName) null;
      if (this.done)
        return (string) null;
      this.assemblyEnum.GetNextAssembly((IntPtr) 0, out ppName, 0);
      if (ppName != null)
      {
        int pccDisplayName = 1024;
        StringBuilder pDisplayName = new StringBuilder(pccDisplayName);
        ppName.GetDisplayName(pDisplayName, ref pccDisplayName, 167);
        return ((object) pDisplayName).ToString();
      }
      else
      {
        this.done = true;
        return (string) null;
      }
    }
  }
}
