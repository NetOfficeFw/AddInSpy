// Decompiled with JetBrains decompiler
// Type: AddInSpy.ManifestReader
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace AddInSpy
{
  internal class ManifestReader
  {
    internal static string[] GetClickOnceInfo(ref string manifestPath, bool scanRemote, ref bool isUncPath, ref bool isHttpPath)
    {
      string[] strArray = new string[2];
      string str1 = string.Empty;
      string baseDir = string.Empty;
      string str2 = string.Empty;
      XmlDocument deployDoc = new XmlDocument();
      if (manifestPath == null || manifestPath.Length == 0)
        throw new ArgumentException(Resources.EMPTY_MANIFESTPATH);
      try
      {
        Uri uri = new Uri(manifestPath);
        bool flag;
        if (uri.IsLoopback)
          flag = ManifestReader.GetManifestFromLocalPath(deployDoc, ref manifestPath, out baseDir);
        else if (uri.IsUnc)
        {
          isUncPath = true;
          flag = scanRemote && ManifestReader.GetManifestFromUncPath(deployDoc, ref manifestPath, out baseDir);
        }
        else if (uri.Host != null && uri.Host.Length > 0)
        {
          isHttpPath = true;
          flag = scanRemote && ManifestReader.GetManifestFromHttpUrlPath(manifestPath, deployDoc, out baseDir);
        }
        else
          flag = false;
        if (flag)
        {
          XmlNamespaceManager nsmgr = new XmlNamespaceManager(deployDoc.NameTable);
          nsmgr.AddNamespace("asmv1", "urn:schemas-microsoft-com:asm.v1");
          nsmgr.AddNamespace("def", "urn:schemas-microsoft-com:asm.v2");
          XmlNode xmlNode1 = (XmlNode) deployDoc.DocumentElement;
          XmlNode xmlNode2 = xmlNode1.SelectSingleNode("/asmv1:assembly/def:dependency/def:dependentAssembly", nsmgr);
          XmlNode xmlNode3 = xmlNode1.SelectSingleNode("/asmv1:assembly/def:dependency/def:dependentAssembly/def:assemblyIdentity", nsmgr);
          string path2_1 = xmlNode2.Attributes["codebase"].Value;
          string path2_2 = xmlNode3.Attributes["name"].Value;
          str2 = xmlNode3.Attributes["version"].Value;
          if (isHttpPath)
          {
            string str3 = (baseDir + path2_1).Replace("\\", "/");
            str1 = str3.Substring(0, str3.LastIndexOf(".manifest")) + ".deploy";
          }
          else
            str1 = Path.Combine(Path.GetDirectoryName(Path.Combine(baseDir, path2_1)), path2_2) + ".deploy";
        }
        else
        {
          str1 = (string) null;
          str2 = (string) null;
        }
      }
      catch (Exception ex)
      {
        Globals.AddException(ex);
      }
      strArray[0] = str1;
      strArray[1] = str2;
      return strArray;
    }

    private static bool GetManifestFromLocalPath(XmlDocument deployDoc, ref string manifestPath, out string baseDir)
    {
      bool flag = true;
      string uriString = manifestPath.Substring("file:///".Length);
      manifestPath = new Uri(uriString).LocalPath;
      baseDir = Path.GetDirectoryName(manifestPath);
      if (System.IO.File.Exists(manifestPath))
        deployDoc.Load(manifestPath);
      else
        flag = false;
      return flag;
    }

    private static bool GetManifestFromUncPath(XmlDocument deployDoc, ref string manifestPath, out string baseDir)
    {
      bool flag = true;
      string uriString = manifestPath.Substring("file:".Length);
      manifestPath = new Uri(uriString).LocalPath;
      string str = Path.GetFileName(manifestPath);
      try
      {
        str = Path.Combine(Path.GetTempPath(), str);
        System.IO.File.Copy(manifestPath, str, true);
      }
      catch (Exception ex)
      {
        flag = false;
      }
      baseDir = Path.GetDirectoryName(manifestPath);
      deployDoc.Load(str);
      return flag;
    }

    private static bool GetManifestFromHttpUrlPath(string manifestPath, XmlDocument deployDoc, out string baseDir)
    {
      bool flag = true;
      try
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(manifestPath);
        httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
        HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
        deployDoc.LoadXml(streamReader.ReadToEnd());
        httpWebResponse.Close();
        streamReader.Close();
      }
      catch (Exception ex)
      {
        flag = false;
      }
      baseDir = manifestPath.Substring(0, manifestPath.LastIndexOf('/') + 1);
      return flag;
    }
  }
}
