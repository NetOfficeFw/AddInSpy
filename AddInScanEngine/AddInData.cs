// Decompiled with JetBrains decompiler
// Type: AddInSpy.AddInData
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text;

namespace AddInSpy
{
  public class AddInData
  {
    private string hostName;
    private bool isRunning;
    private bool isLoaded;
    private string addInType;
    private string friendlyName;
    private string progId;
    private string clsid;
    private string manifestPath;
    private string assemblyPath;
    private string loadBehavior;
    private string regHiveName;
    private string assemblyName;
    private string clrVersion;
    private bool isObjectExposed;
    private string supportedInterfaces;
    private string outlookFormRegions;
    private string vstoRuntime;
    private string installDate;
    private string assemblyVersion;
    private Bitmap statusImage;
    private bool status;
    private string statusDescription;
    private AppDomain currentDomain;
    private AssemblyScanner scanner;

    public string HostName
    {
      get
      {
        return this.hostName;
      }
      set
      {
        this.hostName = value;
      }
    }

    public bool IsRunning
    {
      get
      {
        return this.isRunning;
      }
      set
      {
        this.isRunning = value;
      }
    }

    public bool IsLoaded
    {
      get
      {
        return this.isLoaded;
      }
      set
      {
        this.isLoaded = value;
      }
    }

    public string AddInType
    {
      get
      {
        return this.addInType;
      }
      set
      {
        this.addInType = value;
      }
    }

    public string FriendlyName
    {
      get
      {
        return this.friendlyName;
      }
      set
      {
        this.friendlyName = value;
      }
    }

    public string ProgId
    {
      get
      {
        return this.progId;
      }
      set
      {
        this.progId = value;
      }
    }

    public string Clsid
    {
      get
      {
        return this.clsid;
      }
      set
      {
        this.clsid = value;
      }
    }

    public string ManifestPath
    {
      get
      {
        return this.manifestPath;
      }
      set
      {
        this.manifestPath = value;
      }
    }

    public string AssemblyPath
    {
      get
      {
        return this.assemblyPath;
      }
      set
      {
        this.assemblyPath = value;
      }
    }

    public string LoadBehavior
    {
      get
      {
        return this.loadBehavior;
      }
      set
      {
        this.loadBehavior = value;
      }
    }

    public string RegHiveName
    {
      get
      {
        return this.regHiveName;
      }
      set
      {
        this.regHiveName = value;
      }
    }

    public string AssemblyName
    {
      get
      {
        return this.assemblyName;
      }
      set
      {
        this.assemblyName = value;
      }
    }

    public string ClrVersion
    {
      get
      {
        return this.clrVersion;
      }
      set
      {
        this.clrVersion = value;
      }
    }

    public bool IsObjectExposed
    {
      get
      {
        return this.isObjectExposed;
      }
      set
      {
        this.isObjectExposed = value;
      }
    }

    public string SupportedInterfaces
    {
      get
      {
        return this.supportedInterfaces;
      }
      set
      {
        this.supportedInterfaces = value;
      }
    }

    public string OutlookFormRegions
    {
      get
      {
        return this.outlookFormRegions;
      }
      set
      {
        this.outlookFormRegions = value;
      }
    }

    public string VstoRuntime
    {
      get
      {
        return this.vstoRuntime;
      }
      set
      {
        this.vstoRuntime = value;
      }
    }

    public string InstallDate
    {
      get
      {
        return this.installDate;
      }
      set
      {
        this.installDate = value;
      }
    }

    public string AssemblyVersion
    {
      get
      {
        return this.assemblyVersion;
      }
      set
      {
        this.assemblyVersion = value;
      }
    }

    public Bitmap StatusImage
    {
      get
      {
        return this.statusImage;
      }
      set
      {
        this.statusImage = value;
      }
    }

    public bool Status
    {
      get
      {
        return this.status;
      }
      set
      {
        this.status = value;
      }
    }

    public string StatusDescription
    {
      get
      {
        return this.statusDescription;
      }
      set
      {
        this.statusDescription = value;
      }
    }

    public AddInData(string hostName, string regHiveName, string progId)
    {
      this.hostName = hostName;
      this.regHiveName = regHiveName;
      this.progId = progId;
      this.assemblyVersion = Resources.NOT_APPLICABLE;
      this.statusImage = Resources.OkImage;
      this.status = true;
      this.isRunning = false;
      this.isLoaded = false;
      this.addInType = (string) null;
      this.friendlyName = (string) null;
      this.clsid = (string) null;
      this.manifestPath = (string) null;
      this.assemblyPath = (string) null;
      this.loadBehavior = (string) null;
      this.assemblyName = (string) null;
      this.clrVersion = (string) null;
      this.isObjectExposed = false;
      this.supportedInterfaces = (string) null;
      this.vstoRuntime = (string) null;
      this.installDate = (string) null;
      this.statusDescription = string.Empty;
      this.outlookFormRegions = Resources.NOT_APPLICABLE;
      if (this.hostName == "Outlook")
        this.outlookFormRegions = (string) null;
      this.currentDomain = AppDomain.CurrentDomain;
      this.scanner = new AssemblyScanner();
      this.currentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(this.scanner.CurrentDomain_ReflectionOnlyAssemblyResolve);
    }

    internal void SetInvalidRegistration()
    {
      this.isLoaded = false;
      this.manifestPath = Resources.NOT_APPLICABLE;
      this.isObjectExposed = false;
      this.vstoRuntime = Resources.NOT_APPLICABLE;
      this.statusImage = Resources.WarningImage;
      this.status = false;
      this.statusDescription = Resources.REGISTRATION_INVALID;
    }

    internal void SetInvalidPath()
    {
      this.statusImage = Resources.WarningImage;
      this.status = false;
      this.statusDescription = Resources.PATH_INVALID;
    }

    internal void SetNativeScanFailed()
    {
      this.statusImage = Resources.WarningImage;
      this.status = false;
      this.statusDescription = Resources.NATIVE_SCAN_FAILED;
    }

    internal void SetInvalidAddInKey()
    {
      this.statusImage = Resources.WarningImage;
      this.status = false;
      this.statusDescription = Resources.REGISTRATION_INVALID;
    }

    internal void SetUnknownValues()
    {
      if (this.hostName == null)
        this.hostName = Resources.VALUE_UNKNOWN;
      if (this.addInType == null)
        this.addInType = Resources.VALUE_UNKNOWN;
      if (this.friendlyName == null)
        this.friendlyName = Resources.VALUE_UNKNOWN;
      if (this.progId == null)
        this.progId = Resources.VALUE_UNKNOWN;
      if (this.clsid == null)
        this.clsid = Resources.VALUE_UNKNOWN;
      if (this.manifestPath == null)
        this.manifestPath = Resources.VALUE_UNKNOWN;
      if (this.assemblyPath == null)
        this.assemblyPath = Resources.VALUE_UNKNOWN;
      if (this.loadBehavior == null)
        this.loadBehavior = Resources.VALUE_UNKNOWN;
      if (this.regHiveName == null)
        this.regHiveName = Resources.VALUE_UNKNOWN;
      if (this.assemblyName == null)
        this.assemblyName = Resources.VALUE_UNKNOWN;
      if (this.clrVersion == null)
        this.clrVersion = Resources.VALUE_UNKNOWN;
      if (this.supportedInterfaces == null)
        this.supportedInterfaces = Resources.VALUE_UNKNOWN;
      if (this.outlookFormRegions == null)
        this.outlookFormRegions = Resources.VALUE_UNKNOWN;
      if (this.vstoRuntime == null)
        this.vstoRuntime = Resources.VALUE_UNKNOWN;
      if (this.installDate == null)
        this.installDate = Resources.VALUE_UNKNOWN;
      if (this.assemblyVersion != null)
        return;
      this.assemblyVersion = Resources.VALUE_UNKNOWN;
    }

    internal void GetData(RegistryKey addInKey, bool scanManagedInterfaces, bool scanNativeInterfaces, bool scanRemote, ref bool isUncPath, ref bool isHttpPath, ref bool isDllPathValid, ref bool isValidRegistration)
    {
      this.friendlyName = (string) addInKey.GetValue("FriendlyName");
      this.clsid = RegistryReader.GetCLSIDFromProgID(this.progId);
      this.loadBehavior = addInKey.GetValue("LoadBehavior").ToString();
      this.manifestPath = (string) addInKey.GetValue("Manifest");
      if (this.manifestPath == null && string.IsNullOrEmpty(this.clsid))
      {
        this.SetInvalidRegistration();
        isDllPathValid = false;
        isValidRegistration = false;
      }
      else
      {
        if (this.manifestPath != null)
        {
          isDllPathValid = this.GetVstoAddInData(scanManagedInterfaces, scanRemote, ref isUncPath, ref isHttpPath);
          if (!isDllPathValid || this.assemblyName == null || this.clrVersion == null)
            this.SetInvalidPath();
        }
        else
        {
          this.manifestPath = Resources.NOT_APPLICABLE;
          if (RegistryReader.GetIsManagedCodeCategoryRegistered(this.clsid) || RegistryReader.GetIsMscoreeRegistered(this.clsid))
          {
            isDllPathValid = this.GetManagedAddInData(scanManagedInterfaces);
          }
          else
          {
            bool isNativeScanCompleted = false;
            isDllPathValid = this.GetNativeAddInData(scanNativeInterfaces, out isNativeScanCompleted);
            if (!isNativeScanCompleted)
              this.SetNativeScanFailed();
          }
        }
        if (this.assemblyPath != null && isDllPathValid)
          this.CleanAssemblyPath(ref this.assemblyPath, ref isDllPathValid);
        else
          this.statusDescription = Resources.PATH_INVALID;
      }
    }

    private void CleanAssemblyPath(ref string assemblyPath, ref bool isDllPathValid)
    {
      assemblyPath = assemblyPath.Trim('"');
      foreach (char ch in Path.GetInvalidPathChars())
      {
        if (assemblyPath.IndexOf(ch) > 0)
        {
          assemblyPath = (string) null;
          isDllPathValid = false;
          break;
        }
      }
    }

    internal void ScanForDisabledItems()
    {
      string hostName = this.hostName;
      if (this.addInType == "Managed")
        this.assemblyPath = "mscoree.dll";
      if (this.hostName == "Project")
        hostName = "MS Project";
      string disabledStatus = string.Empty;
      RegistryReader.ReadResiliencyRegistryKeys(hostName, this.assemblyPath, this.friendlyName, out disabledStatus);
      if (string.IsNullOrEmpty(disabledStatus))
        return;
      this.statusImage = Resources.WarningImage;
      this.status = false;
      this.statusDescription = !string.IsNullOrEmpty(this.statusDescription) ? string.Format("{0} {1}", (object) this.statusDescription, (object) disabledStatus) : disabledStatus;
    }

    internal void ScanForFormRegions(NameValueCollection registeredFormRegions)
    {
      string[] values = registeredFormRegions.GetValues(this.progId);
      if (values != null)
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < values.Length; ++index)
        {
          stringBuilder.Append(values[index]);
          if (index < values.Length - 1)
            stringBuilder.Append("; ");
          else
            stringBuilder.Append(".");
        }
        this.outlookFormRegions = ((object) stringBuilder).ToString();
      }
      else
        this.outlookFormRegions = Resources.SECONDARY_INTERFACES_NONE;
    }

    internal bool GetVstoAddInData(bool scanManagedInterfaces, bool scanRemote, ref bool isUncPath, ref bool isHttpPath)
    {
      bool flag = true;
      string[] assemblyDetails = (string[]) null;
      this.assemblyPath = (string) null;
      this.vstoRuntime = (string) null;
      this.assemblyVersion = Resources.NOT_APPLICABLE;
      this.addInType = Resources.ADDIN_TYPE_VSTO;
      this.assemblyName = (string) null;
      this.clrVersion = (string) null;
      this.supportedInterfaces = (string) null;
      string str = string.Empty;
      if (this.manifestPath.EndsWith(".manifest"))
      {
        this.assemblyPath = this.manifestPath.Substring(0, this.manifestPath.LastIndexOf(".manifest"));
        this.vstoRuntime = "2005 SE";
      }
      else if (this.manifestPath.EndsWith(".vsto|vstolocal"))
      {
        this.vstoRuntime = "2008";
        this.clsid = Resources.NOT_APPLICABLE;
        this.assemblyPath = this.manifestPath.Substring(0, this.manifestPath.LastIndexOf(".vsto|vstolocal")) + ".dll";
      }
      else if (this.manifestPath.EndsWith(".vsto"))
      {
        this.vstoRuntime = "2008";
        this.clsid = Resources.NOT_APPLICABLE;
        string[] clickOnceInfo = ManifestReader.GetClickOnceInfo(ref this.manifestPath, scanRemote, ref isUncPath, ref isHttpPath);
        this.assemblyPath = clickOnceInfo[0];
        this.assemblyVersion = clickOnceInfo[1];
      }
      if (File.Exists(this.assemblyPath))
        assemblyDetails = this.scanner.GetAssemblyInfo(this.assemblyPath, this.hostName, true);
      if (assemblyDetails != null && assemblyDetails.Length > 1)
      {
        this.assemblyName = assemblyDetails[0];
        this.clrVersion = assemblyDetails[1];
        this.supportedInterfaces = !scanManagedInterfaces ? (string) null : this.GetSupportedInterfaces(assemblyDetails);
      }
      else
      {
        flag = false;
        this.assemblyName = (string) null;
        this.clrVersion = (string) null;
        this.supportedInterfaces = (string) null;
      }
      return flag;
    }

    internal bool GetManagedAddInData(bool scanManagedInterfaces)
    {
      bool flag = true;
      this.assemblyName = (string) null;
      this.clrVersion = (string) null;
      this.supportedInterfaces = (string) null;
      this.addInType = Resources.ADDIN_TYPE_MANAGED;
      this.assemblyPath = RegistryReader.GetInprocServerFromClsid(this.clsid, "CodeBase");
      if (this.assemblyPath != null && File.Exists(this.assemblyPath))
      {
        string[] assemblyInfo = this.scanner.GetAssemblyInfo(this.assemblyPath, this.hostName, false);
        this.assemblyName = assemblyInfo[0];
        this.clrVersion = assemblyInfo[1];
        this.supportedInterfaces = !scanManagedInterfaces ? (string) null : this.GetSupportedInterfaces(assemblyInfo);
      }
      else
      {
        flag = false;
        this.assemblyName = (string) null;
        this.clrVersion = (string) null;
        this.supportedInterfaces = (string) null;
      }
      this.vstoRuntime = Resources.NOT_APPLICABLE;
      return flag;
    }

    internal bool GetNativeAddInData(bool scanNativeInterfaces, out bool isNativeScanCompleted)
    {
      bool flag = true;
      this.addInType = Resources.ADDIN_TYPE_NATIVE;
      this.assemblyPath = (string) null;
      this.assemblyName = Resources.NOT_APPLICABLE;
      this.clrVersion = Resources.NOT_APPLICABLE;
      this.vstoRuntime = Resources.NOT_APPLICABLE;
      this.supportedInterfaces = (string) null;
      isNativeScanCompleted = true;
      string inprocServerFromClsid = RegistryReader.GetInprocServerFromClsid(this.clsid, "");
      if (inprocServerFromClsid != null)
        this.assemblyPath = inprocServerFromClsid.Trim('"');
      else
        flag = false;
      if (scanNativeInterfaces)
      {
        if (this.assemblyPath != null && File.Exists(this.assemblyPath))
        {
          this.supportedInterfaces = new NativeAddInScanner(this.hostName).GetSupportedInterfaces(this.clsid);
          if (this.supportedInterfaces == null)
            isNativeScanCompleted = false;
        }
        else
          flag = false;
      }
      return flag;
    }

    private string GetSupportedInterfaces(string[] assemblyDetails)
    {
      string str = (string) null;
      try
      {
        if (assemblyDetails != null)
        {
          StringBuilder stringBuilder = new StringBuilder();
          for (int index = 2; index < assemblyDetails.Length; ++index)
          {
            stringBuilder.Append(assemblyDetails[index]);
            if (index + 1 < assemblyDetails.Length)
              stringBuilder.Append(", ");
          }
          str = ((object) stringBuilder).ToString();
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      return str;
    }
  }
}
