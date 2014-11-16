// Decompiled with JetBrains decompiler
// Type: AS.Properties.Resources
// Assembly: AS, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AFE2FA58-896E-487A-A656-63ED650F5324
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AS.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AS.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Resources.resourceMan, (object) null))
          Resources.resourceMan = new ResourceManager("AS.Properties.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resources.resourceCulture;
      }
      set
      {
        Resources.resourceCulture = value;
      }
    }

    internal static string ARG_HELP_DASH
    {
      get
      {
        return Resources.ResourceManager.GetString("ARG_HELP_DASH", Resources.resourceCulture);
      }
    }

    internal static string ARG_HELP_SLASH
    {
      get
      {
        return Resources.ResourceManager.GetString("ARG_HELP_SLASH", Resources.resourceCulture);
      }
    }

    internal static string OPTION_ALL
    {
      get
      {
        return Resources.ResourceManager.GetString("OPTION_ALL", Resources.resourceCulture);
      }
    }

    internal static string REPORT_ADDINS
    {
      get
      {
        return Resources.ResourceManager.GetString("REPORT_ADDINS", Resources.resourceCulture);
      }
    }

    internal static string REPORT_CONTEXT
    {
      get
      {
        return Resources.ResourceManager.GetString("REPORT_CONTEXT", Resources.resourceCulture);
      }
    }

    internal static string SCAN_DISABLED_ITEMS
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_DISABLED_ITEMS", Resources.resourceCulture);
      }
    }

    internal static string SCAN_FORMREGIONS
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_FORMREGIONS", Resources.resourceCulture);
      }
    }

    internal static string SCAN_HKCU
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_HKCU", Resources.resourceCulture);
      }
    }

    internal static string SCAN_HKLM
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_HKLM", Resources.resourceCulture);
      }
    }

    internal static string SCAN_MANAGED_INTERFACES
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_MANAGED_INTERFACES", Resources.resourceCulture);
      }
    }

    internal static string SCAN_NATIVE_INTERFACES
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_NATIVE_INTERFACES", Resources.resourceCulture);
      }
    }

    internal static string SCAN_REMOTE
    {
      get
      {
        return Resources.ResourceManager.GetString("SCAN_REMOTE", Resources.resourceCulture);
      }
    }

    internal static string SYNTAX_MESSAGE
    {
      get
      {
        return Resources.ResourceManager.GetString("SYNTAX_MESSAGE", Resources.resourceCulture);
      }
    }

    internal Resources()
    {
    }
  }
}
