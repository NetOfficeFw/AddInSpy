// Decompiled with JetBrains decompiler
// Type: AddInSpy.NativeMethods
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace AddInSpy
{
  internal static class NativeMethods
  {
    [DllImport("fusion.dll", PreserveSig = false)]
    internal static extern int CreateAssemblyCache(out NativeMethods.IAssemblyCache ppAsmCache, int reserved);

    [DllImport("fusion.dll", PreserveSig = false)]
    internal static extern int CreateAssemblyNameObject(out NativeMethods.IAssemblyName ppAssemblyNameObj, [MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName, NativeMethods.CreateAssemblyNameObjectFlags flags, IntPtr pvReserved);

    [DllImport("fusion.dll", PreserveSig = false)]
    internal static extern int CreateAssemblyEnum(out NativeMethods.IAssemblyEnum ppEnum, IntPtr pUnkReserved, NativeMethods.IAssemblyName pName, NativeMethods.AssemblyCacheFlags flags, IntPtr pvReserved);

    [Flags]
    internal enum AssemblyCacheFlags
    {
      GAC = 2,
    }

    internal enum CreateAssemblyNameObjectFlags
    {
      CANOF_PARSE_DISPLAY_NAME = 1,
    }

    [Flags]
    internal enum AssemblyNameDisplayFlags
    {
      VERSION = 1,
      CULTURE = 2,
      PUBLIC_KEY_TOKEN = 4,
      PROCESSORARCHITECTURE = 32,
      RETARGETABLE = 128,
      ALL = RETARGETABLE | PROCESSORARCHITECTURE | PUBLIC_KEY_TOKEN | CULTURE | VERSION,
    }

    [Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    internal interface IAssemblyCache
    {
      [SpecialName]
      void _VtblGap1_1();

      void QueryAssemblyInfo(int flags, [MarshalAs(UnmanagedType.LPWStr)] string assemblyName, ref NativeMethods.AssemblyInfo assemblyInfo);

      [SpecialName]
      void _VtblGap3_3();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CD193BC0-B4BC-11d2-9833-00C04FC31D2E")]
    [ComImport]
    internal interface IAssemblyName
    {
      [SpecialName]
      void _VtblGap1_2();

      void Finalize();

      void GetDisplayName(StringBuilder pDisplayName, ref int pccDisplayName, int displayFlags);

      [SpecialName]
      void _VtblGap5_5();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("21b8916c-f28e-11d2-a473-00c04f8ef448")]
    [ComImport]
    internal interface IAssemblyEnum
    {
      void GetNextAssembly(IntPtr pvReserved, out NativeMethods.IAssemblyName ppName, int flags);

      [SpecialName]
      void _VtblGap2_2();
    }

    internal struct AssemblyInfo
    {
      public int cbAssemblyInfo;
      public int assemblyFlags;
      public long assemblySizeInKB;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string currentAssemblyPath;
      public int cchBuf;
    }

    [Guid("000C0339-0000-0000-C000-000000000046")]
    [TypeLibType((short) 4288)]
    [ComImport]
    public interface COMAddIns : IEnumerable
    {
      [DispId(1610743808)]
      object Application { [DispId(1610743808), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(1610743809)]
      int Creator { [DispId(1610743809), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(1)]
      int Count { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(3)]
      object Parent { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(0)]
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      [return: MarshalAs(UnmanagedType.Interface)]
      NativeMethods.COMAddIn Item([MarshalAs(UnmanagedType.Struct), In] ref object Index);

      [SpecialName]
      void _VtblGap4_1();

      [DispId(2)]
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      void Update();

      [DispId(4)]
      [TypeLibFunc((short) 1088)]
      [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
      void SetAppModal([In] bool varfModal);
    }

    [Guid("000C033A-0000-0000-C000-000000000046")]
    [TypeLibType((short) 4288)]
    [ComImport]
    public interface COMAddIn
    {
      [DispId(1610743808)]
      object Application { [DispId(1610743808), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(1610743809)]
      int Creator { [DispId(1610743809), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(0)]
      //[IndexerName("Description")]
      string Description { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] set; }

      [DispId(3)]
      string ProgId { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(4)]
      string Guid { [DispId(4), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

      [DispId(6)]
      bool Connect { [DispId(6), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(6), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] set; }

      [DispId(7)]
      object Object { [DispId(7), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(7), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] set; }

      [DispId(8)]
      object Parent { [DispId(8), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
    }
  }
}
