// Decompiled with JetBrains decompiler
// Type: AddInSpy.Controller
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Input;

namespace AddInSpy
{
  public class Controller
  {
    private GridProxy gridProxy;
    private List<string> progIdsFound;
    private bool isUncPath;
    private bool isHttpPath;
    private string[] hostNames;
    private bool scanHKCU;
    private bool scanHKLM;
    private bool scanRemote;
    private bool scanManagedInterfaces;
    private bool scanNativeInterfaces;
    private bool scanDisabled;
    private bool scanFormRegions;
    private bool reportContext;
    private bool reportAddIns;
    public string HostAddress;
    public string HostName;
    public string UserName;
    public string DomainName;
    public string OsVersion;
    public string VstoSuppressDisplayAlerts;
    public string VstoLogAlerts;
    private bool autoRefresh;
    private bool isUiMode;
    private string reportFileName;

    public GridProxy GridProxy
    {
      get
      {
        return this.gridProxy;
      }
    }

    public string[] HostNames
    {
      get
      {
        return this.hostNames;
      }
      set
      {
        this.hostNames = value;
      }
    }

    public string[] ScanNames
    {
      set
      {
        this.scanHKCU = false;
        this.scanHKLM = false;
        this.scanRemote = false;
        this.scanManagedInterfaces = false;
        this.scanNativeInterfaces = false;
        this.scanDisabled = false;
        this.scanFormRegions = false;
        foreach (string str in value)
        {
          if (str == Resources.SCAN_HKCU)
            this.scanHKCU = true;
          else if (str == Resources.SCAN_HKLM)
            this.scanHKLM = true;
          else if (str == Resources.SCAN_REMOTE)
            this.scanRemote = true;
          else if (str == Resources.SCAN_MANAGED_INTERFACES)
            this.scanManagedInterfaces = true;
          else if (str == Resources.SCAN_NATIVE_INTERFACES)
            this.scanNativeInterfaces = true;
          else if (str == Resources.SCAN_DISABLED_ITEMS)
            this.scanDisabled = true;
          else if (str == Resources.SCAN_FORMREGIONS)
            this.scanFormRegions = true;
        }
      }
    }

    public string[] ReportTypes
    {
      set
      {
        this.reportContext = false;
        this.reportAddIns = false;
        foreach (string str in value)
        {
          if (str == Resources.REPORT_CONTEXT)
            this.reportContext = true;
          else if (str == Resources.REPORT_ADDINS)
            this.reportAddIns = true;
        }
      }
    }

    public bool AutoRefresh
    {
      get
      {
        return this.autoRefresh;
      }
      set
      {
        this.autoRefresh = value;
      }
    }

    public string ReportFileName
    {
      get
      {
        return this.reportFileName;
      }
      set
      {
        this.reportFileName = value;
      }
    }

    public Controller(bool uiMode)
    {
      this.isUiMode = uiMode;
      this.gridProxy = new GridProxy();
      this.progIdsFound = new List<string>();
      this.GetContextInformation();
    }

    public Controller(bool scanHKCU, bool scanHKLM, bool scanRemote, bool scanManagedInterfaces, bool scanNativeInterfaces, bool scanDisabled, bool scanFormRegions)
      : this(true)
    {
      this.scanHKCU = scanHKCU;
      this.scanHKLM = scanHKLM;
      this.scanRemote = scanRemote;
      this.scanManagedInterfaces = scanManagedInterfaces;
      this.scanNativeInterfaces = scanNativeInterfaces;
      this.scanDisabled = scanDisabled;
      this.scanFormRegions = scanFormRegions;
    }

    private void GetContextInformation()
    {
      IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();
      IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
      NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress();
      this.HostAddress = hostAddresses[0].ToString();
      this.HostName = globalProperties.HostName;
      this.UserName = Environment.UserName;
      this.DomainName = Environment.UserDomainName;
      this.OsVersion = Environment.OSVersion.VersionString;
      string str1 = Environment.GetEnvironmentVariable("VSTO_SUPPRESSDISPLAYALERTS");
      if (string.IsNullOrEmpty(str1))
        str1 = Resources.VALUE_UNKNOWN;
      this.VstoSuppressDisplayAlerts = str1;
      string str2 = Environment.GetEnvironmentVariable("VSTO_LOGALERTS");
      if (string.IsNullOrEmpty(str2))
        str2 = Resources.VALUE_UNKNOWN;
      this.VstoLogAlerts = str2;
    }

    public void Refresh()
    {
      this.RefreshAddInGrid();
      this.GetContextInformation();
    }

    private void RefreshAddInGrid()
    {
      this.gridProxy.Clear();
      this.progIdsFound.Clear();
      object obj = (object) null;
      if (this.isUiMode)
      {
        obj = (object) Mouse.OverrideCursor;
        Mouse.OverrideCursor = Cursors.Wait;
      }
      if (this.hostNames != null)
      {
        foreach (string hostName in this.hostNames)
        {
          if (this.scanHKCU)
          {
            using (RegistryKey regHive = Registry.CurrentUser)
              this.EnumerateRegisteredAddIns(regHive, hostName);
          }
          if (this.scanHKLM)
          {
            using (RegistryKey regHive = Registry.LocalMachine)
              this.EnumerateRegisteredAddIns(regHive, hostName);
          }
        }
      }
      if (!this.isUiMode)
        return;
      Mouse.OverrideCursor = (Cursor) obj;
    }

    private void EnumerateRegisteredAddIns(RegistryKey regHive, string hostName)
    {
      string regHiveName = (string) null;
      List<string> officeRegKeyNames = new List<string>();
      NameValueCollection registeredFormRegions = (NameValueCollection) null;
      RegistryReader.GetAddInsRegHiveNames(regHive, hostName, out regHiveName, officeRegKeyNames);
      foreach (string officeRegKeyName in officeRegKeyNames)
      {
          EvaluateRegisteredAddIn(regHive, hostName, regHiveName, ref registeredFormRegions, officeRegKeyName);
      }
    }

    private void EvaluateRegisteredAddIn(RegistryKey regHive, string hostName, string regHiveName, ref NameValueCollection registeredFormRegions, string officeRegKeyName)
    {
        try
        {
            if (hostName == "Outlook" && this.scanFormRegions)
                registeredFormRegions = RegistryReader.ReadFormRegionRegistrations(regHive);
            using (RegistryKey registryKey = regHive.OpenSubKey(officeRegKeyName))
            {
                if (registryKey == null)
                    return;
                foreach (string progId in registryKey.GetSubKeyNames())
                {
                    bool isDllPathValid = true;
                    NativeMethods.COMAddIn comAddIn = (NativeMethods.COMAddIn)null;
                    bool isValidRegistration = true;
                    this.isUncPath = false;
                    this.isHttpPath = false;
                    Globals.ErrorMessage = (string)null;
                    AddInData addInData = new AddInData(hostName, regHiveName, progId);
                    addInData.Wow6432 = registryKey.Name.Contains("Wow6432Node") ? true : false;
                    if (this.progIdsFound.Contains(addInData.ProgId))
                        addInData.StatusDescription = Resources.REGISTERED_MULTIPLE_TIMES;
                    else
                        this.progIdsFound.Add(addInData.ProgId);
                    try
                    {
                        using (RegistryKey addInKey = registryKey.OpenSubKey(addInData.ProgId))
                        {
                            if (addInKey != null)
                                addInData.GetData(addInKey, this.scanManagedInterfaces, this.scanNativeInterfaces, this.scanRemote, ref this.isUncPath, ref this.isHttpPath, ref isDllPathValid, ref isValidRegistration);
                            else
                                addInData.SetInvalidAddInKey();
                            if (isValidRegistration)
                            {
                                comAddIn = ComAddInUtilities.GetLoadedCOMAddInObjects(ref addInData);
                                if (this.isHttpPath)
                                    addInData.StatusDescription = Resources.HTTP_PARTIAL_INFORMATION;
                                else if (!this.scanRemote && this.isUncPath)
                                    addInData.StatusDescription = Resources.REMOTE_NOT_SELECTED;
                                else if (addInData.AssemblyPath != null && isDllPathValid)
                                    addInData.InstallDate = this.GetAddInInstallDate(addInData.AssemblyPath);
                                else
                                    addInData.SetInvalidPath();
                                if (addInData.AssemblyPath != null && addInData.AssemblyPath.EndsWith(".deploy"))
                                    addInData.AssemblyPath = addInData.AssemblyPath.Substring(0, addInData.AssemblyPath.IndexOf(".deploy"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Globals.AddException(ex);
                    }
                    if (Globals.ErrorMessage != null && Globals.ErrorMessage.Length > 0)
                        addInData.StatusDescription = !string.IsNullOrEmpty(addInData.StatusDescription) ? string.Format("{0} {1}", (object)addInData.StatusDescription, (object)Globals.ErrorMessage) : Globals.ErrorMessage;
                    if (this.scanDisabled)
                        addInData.ScanForDisabledItems();
                    if (addInData.HostName == "Outlook" && this.scanFormRegions)
                        addInData.ScanForFormRegions(registeredFormRegions);
                    this.gridProxy.AddDataRow(addInData);
                }
            }
            return;
        }
        catch (Exception ex)
        {
            Globals.AddException(ex);
            return;
        }
    }

    private string GetAddInInstallDate(string assemblyPath)
    {
      string str = (string) null;
      if (assemblyPath != null)
      {
        try
        {
          DateTime creationTime = Directory.GetCreationTime(Path.GetDirectoryName(assemblyPath));
          str = creationTime.ToShortDateString() + " - " + creationTime.ToLongTimeString();
        }
        catch (Exception ex)
        {
          Globals.AddException(ex);
        }
      }
      return str;
    }

    public void GenerateReport(bool reportContext, bool reportAddIns, string reportFileName)
    {
      new ReportWriter(this.gridProxy.AddInDataTable, this.HostAddress, this.HostName, this.UserName, this.DomainName, this.OsVersion, this.VstoSuppressDisplayAlerts, this.VstoLogAlerts).GenerateReport(reportContext, reportAddIns, reportFileName);
    }

    public void GenerateReport()
    {
      new ReportWriter(this.gridProxy.AddInDataTable, this.HostAddress, this.HostName, this.UserName, this.DomainName, this.OsVersion, this.VstoSuppressDisplayAlerts, this.VstoLogAlerts).GenerateReport(this.reportContext, this.reportAddIns, this.reportFileName);
    }
  }
}
