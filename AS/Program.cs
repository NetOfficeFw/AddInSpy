// Decompiled with JetBrains decompiler
// Type: AS.Program
// Assembly: AS, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AFE2FA58-896E-487A-A656-63ED650F5324
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AS.exe

using AddInSpy;
using AS.Properties;
using System;

namespace AS
{
  public class Program
  {
    private string[] hostNames = new string[11]
    {
      "Access",
      "Excel",
      "FrontPage",
      "InfoPath",
      "Outlook",
      "PowerPoint",
      "Project",
      "Publisher",
      "SharePoint Designer",
      "Visio",
      "Word"
    };
    private string[] scanNames = new string[7]
    {
      Resources.SCAN_HKCU,
      Resources.SCAN_HKLM,
      Resources.SCAN_REMOTE,
      Resources.SCAN_MANAGED_INTERFACES,
      Resources.SCAN_NATIVE_INTERFACES,
      Resources.SCAN_DISABLED_ITEMS,
      Resources.SCAN_FORMREGIONS
    };
    private string[] reportTypes = new string[2]
    {
      Resources.REPORT_CONTEXT,
      Resources.REPORT_ADDINS
    };
    private Controller controller;

    public Program()
    {
      this.controller = new Controller(false);
    }

    public static void Main(string[] args)
    {
      Program program = new Program();
      try
      {
        if (args[0] == Resources.ARG_HELP_SLASH || args[0] == Resources.ARG_HELP_DASH || !program.ParseCommandLine(args))
        {
          Console.WriteLine(string.Format(Resources.SYNTAX_MESSAGE, (object) Environment.NewLine));
        }
        else
        {
          program.controller.Refresh();
          program.controller.GenerateReport();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    public bool ParseCommandLine(string[] args)
    {
      bool flag = true;
      if (args.Length > 0)
      {
        foreach (string str in args)
        {
          if (str.StartsWith("/") || str.StartsWith("-"))
          {
            string[] strArray1 = str.Split(new char[2]
            {
              '=',
              ','
            });
            if (strArray1.Length < 2)
            {
              flag = false;
              break;
            }
            else
            {
              string[] strArray2 = new string[strArray1.Length - 1];
              Array.Copy((Array) strArray1, 1, (Array) strArray2, 0, strArray2.Length);
              for (int index = 0; index < strArray2.Length; ++index)
                strArray2[index] = strArray2[index].ToLowerInvariant();
              switch (strArray1[0].ToLowerInvariant())
              {
                case "/h":
                case "/hosts":
                case "-h":
                case "-hosts":
                  if (strArray2.Length == 1 && strArray2[0] == Resources.OPTION_ALL)
                  {
                    strArray2 = (string[]) this.hostNames.Clone();
                  }
                  else
                  {
                    for (int index = 0; index < strArray2.Length; ++index)
                    {
                      switch (strArray2[index])
                      {
                        case "access":
                          strArray2[index] = "Access";
                          break;
                        case "excel":
                          strArray2[index] = "Excel";
                          break;
                        case "frontpage":
                          strArray2[index] = "FrontPage";
                          break;
                        case "infopath":
                          strArray2[index] = "InfoPath";
                          break;
                        case "outlook":
                          strArray2[index] = "Outlook";
                          break;
                        case "powerpoint":
                          strArray2[index] = "PowerPoint";
                          break;
                        case "project":
                          strArray2[index] = "Project";
                          break;
                        case "publisher":
                          strArray2[index] = "Publisher";
                          break;
                        case "sharepointdesigner":
                          strArray2[index] = "SharePoint Designer";
                          break;
                        case "visio":
                          strArray2[index] = "Visio";
                          break;
                        case "word":
                          strArray2[index] = "Word";
                          break;
                        default:
                          flag = false;
                          break;
                      }
                    }
                  }
                  this.controller.HostNames = strArray2;
                  break;
                case "/s":
                case "/scans":
                case "-s":
                case "-scans":
                  if (strArray2.Length == 1 && strArray2[0] == Resources.OPTION_ALL)
                  {
                    strArray2 = (string[]) this.scanNames.Clone();
                  }
                  else
                  {
                    for (int index = 0; index < strArray2.Length; ++index)
                    {
                      switch (strArray2[index])
                      {
                        case "hkcu":
                          strArray2[index] = Resources.SCAN_HKCU;
                          break;
                        case "hklm":
                          strArray2[index] = Resources.SCAN_HKLM;
                          break;
                        case "remote":
                          strArray2[index] = Resources.SCAN_REMOTE;
                          break;
                        case "managedinterfaces":
                          strArray2[index] = Resources.SCAN_MANAGED_INTERFACES;
                          break;
                        case "nativeinterfaces":
                          strArray2[index] = Resources.SCAN_NATIVE_INTERFACES;
                          break;
                        case "disableditems":
                          strArray2[index] = Resources.SCAN_DISABLED_ITEMS;
                          break;
                        case "formregions":
                          strArray2[index] = Resources.SCAN_FORMREGIONS;
                          break;
                        default:
                          flag = false;
                          break;
                      }
                    }
                  }
                  this.controller.ScanNames = strArray2;
                  break;
                case "/r":
                case "/reports":
                case "-r":
                case "-reports":
                  if (strArray2.Length == 1 && strArray2[0] == Resources.OPTION_ALL)
                  {
                    strArray2 = (string[]) this.reportTypes.Clone();
                  }
                  else
                  {
                    for (int index = 0; index < strArray2.Length; ++index)
                    {
                      switch (strArray2[index])
                      {
                        case "context":
                          strArray2[index] = Resources.REPORT_CONTEXT;
                          break;
                        case "addins":
                          strArray2[index] = Resources.REPORT_ADDINS;
                          break;
                        default:
                          flag = false;
                          break;
                      }
                    }
                  }
                  this.controller.ReportTypes = strArray2;
                  break;
                case "/o":
                case "/output":
                case "-o":
                case "-output":
                  this.controller.ReportFileName = strArray1[1];
                  break;
                default:
                  flag = false;
                  break;
              }
            }
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }
  }
}
