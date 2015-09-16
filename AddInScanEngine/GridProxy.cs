// Decompiled with JetBrains decompiler
// Type: AddInSpy.GridProxy
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using AddInSpy.Properties;
using System.Data;
using System.Drawing;

namespace AddInSpy
{
  public class GridProxy
  {
    private int item = 1;
    private DataTable dataTable;

    public DataTable AddInDataTable
    {
      get
      {
        return this.dataTable;
      }
    }

    public int AddInCount
    {
      get
      {
        return this.dataTable.Rows.Count;
      }
    }

    public GridProxy()
    {
      this.InitializeDataColumns();
    }

    private void InitializeDataColumns()
    {
      this.dataTable = new DataTable();
      this.dataTable.Columns.Add("Item", typeof (int));
      this.dataTable.Columns.Add("Host");
      this.dataTable.Columns.Add("Running", typeof (bool));
      this.dataTable.Columns.Add("Loaded", typeof (bool));
      this.dataTable.Columns.Add("Type");
      this.dataTable.Columns.Add("FriendlyName");
      this.dataTable.Columns.Add("ProgID");
      this.dataTable.Columns.Add("CLSID");
      this.dataTable.Columns.Add("Manifest");
      this.dataTable.Columns.Add("DllPath");
      this.dataTable.Columns.Add("LoadBehavior");
      this.dataTable.Columns.Add("RegHive");
      this.dataTable.Columns.Add("Wow6432", typeof (bool));
      this.dataTable.Columns.Add("AssemblyName");
      this.dataTable.Columns.Add("CLR_version");
      this.dataTable.Columns.Add("Exposed", typeof (bool));
      this.dataTable.Columns.Add("Interfaces");
      this.dataTable.Columns.Add("FormRegions");
      this.dataTable.Columns.Add("VSTOR");
      this.dataTable.Columns.Add("Installed");
      this.dataTable.Columns.Add("PubVer");
      this.dataTable.Columns.Add("Status2", typeof (Bitmap));
      this.dataTable.Columns.Add("Status", typeof (bool));
      this.dataTable.Columns.Add("StatusDescription");
    }

    public void Clear()
    {
      this.item = 1;
      this.dataTable.Rows.Clear();
    }

    public void AddDataRow(AddInData addInData)
    {
      addInData.SetUnknownValues();
      if (!string.IsNullOrEmpty(addInData.StatusDescription))
        addInData.StatusImage = Resources.WarningImage;
      this.dataTable.Rows.Add(
          (object) this.item,
          (object) addInData.HostName,
          (object) addInData.IsRunning,
          (object) addInData.IsLoaded,
          (object) addInData.AddInType,
          (object) addInData.FriendlyName,
          (object) addInData.ProgId,
          (object) addInData.Clsid,
          (object) addInData.ManifestPath,
          (object) addInData.AssemblyPath,
          (object) addInData.LoadBehavior,
          (object) addInData.RegHiveName,
          (object) addInData.Wow6432,
          (object) addInData.AssemblyName,
          (object) addInData.ClrVersion,
          (object) addInData.IsObjectExposed,
          (object) addInData.SupportedInterfaces,
          (object) addInData.OutlookFormRegions,
          (object) addInData.VstoRuntime,
          (object) addInData.InstallDate,
          (object) addInData.AssemblyVersion,
          (object) addInData.StatusImage,
          (object) addInData.Status,
          (object) addInData.StatusDescription
      );
      ++this.item;
    }
  }
}
