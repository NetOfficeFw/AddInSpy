// Decompiled with JetBrains decompiler
// Type: AddInSpy.ReportWriter
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.Data;
using System.Xml;

namespace AddInSpy
{
  internal class ReportWriter
  {
    private DataTable dataTable;
    private string hostAddress;
    private string hostName;
    private string userName;
    private string domainName;
    private string osVersion;
    private string vstoSuppressDisplayAlerts;
    private string vstoLogAlerts;

    public ReportWriter(DataTable dataTable, string hostAddress, string hostName, string userName, string domainName, string osVersion, string vstoSuppressDisplayAlerts, string vstoLogAlerts)
    {
      this.dataTable = dataTable;
      this.hostAddress = hostAddress;
      this.hostName = hostName;
      this.userName = userName;
      this.domainName = domainName;
      this.osVersion = osVersion;
      this.vstoSuppressDisplayAlerts = vstoSuppressDisplayAlerts;
      this.vstoLogAlerts = vstoLogAlerts;
    }

    internal void GenerateReport(bool reportContext, bool reportAddIns, string reportFileName)
    {
      XmlDocument contextXml = (XmlDocument) null;
      XmlDocument addInXml = (XmlDocument) null;
      if (reportContext)
        contextXml = this.GetContextXml();
      if (reportAddIns)
        addInXml = this.GetAddInsXml();
      this.Export(contextXml, addInXml, reportFileName);
    }

    private XmlDocument GetAddInsXml()
    {
      DataTable dataTable = this.dataTable.Copy();
      dataTable.TableName = "addIn";
      dataTable.Columns.Remove("Status2");
      string xml = new DataSet("addIns")
      {
        Tables = {
          dataTable
        }
      }.GetXml();
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(xml);
      foreach (XmlNode xmlNode in xmlDocument.SelectNodes("addIns/addIn/Status"))
        xmlNode.InnerXml = xmlNode.InnerXml.CompareTo(Resources.STATUS_TRUE) != 0 ? Resources.STATUS_ALERT : Resources.STATUS_OK;
      return xmlDocument;
    }

    private XmlDocument GetContextXml()
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement element1 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_CONTEXT);
      XmlElement element2 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_TIMESTAMP);
      element2.InnerText = DateTime.Now.ToString();
      element1.AppendChild((XmlNode) element2);
      XmlElement element3 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_MACHINE);
      element3.InnerText = this.hostName;
      element1.AppendChild((XmlNode) element3);
      XmlElement element4 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_IPADDRESS);
      element4.InnerText = this.hostAddress;
      element1.AppendChild((XmlNode) element4);
      XmlElement element5 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_USERNAME);
      element5.InnerText = this.userName;
      element1.AppendChild((XmlNode) element5);
      XmlElement element6 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_DOMAINNAME);
      element6.InnerText = this.domainName;
      element1.AppendChild((XmlNode) element6);
      XmlElement element7 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_OS);
      element7.InnerText = this.osVersion;
      element1.AppendChild((XmlNode) element7);
      xmlDocument.AppendChild((XmlNode) element1);
      return xmlDocument;
    }

    private void Export(XmlDocument contextXml, XmlDocument addInXml, string reportFileName)
    {
      if (contextXml == null && addInXml == null)
      {
        Globals.AddErrorMessage(Resources.CONTEXT_ADDIN_EMPTY);
      }
      else
      {
        XmlDocument xmlDocument = new XmlDocument();
        XmlElement element1 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_REPORT);
        xmlDocument.AppendChild((XmlNode) element1);
        if (contextXml != null)
        {
          XmlElement element2 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_CONTEXT);
          element2.InnerXml = contextXml.FirstChild.InnerXml;
          xmlDocument.FirstChild.AppendChild((XmlNode) element2);
          if (addInXml != null)
          {
            XmlElement element3 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_ADDINS);
            element3.InnerXml = addInXml.FirstChild.InnerXml;
            xmlDocument.FirstChild.AppendChild((XmlNode) element3);
          }
        }
        else if (addInXml != null)
        {
          XmlElement element2 = xmlDocument.CreateElement(Resources.REPORT_ELEMENT_ADDINS);
          element2.InnerXml = addInXml.FirstChild.InnerXml;
          xmlDocument.FirstChild.AppendChild((XmlNode) element2);
        }
        if (reportFileName == null || reportFileName.Length == 0)
          reportFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + string.Format("{0}_{1}@{2}", (object) this.hostAddress, (object) this.userName, (object) this.domainName).Replace(":", ".") + ".xml";
        xmlDocument.Save(reportFileName);
      }
    }
  }
}
