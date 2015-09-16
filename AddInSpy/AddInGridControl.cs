// Decompiled with JetBrains decompiler
// Type: AddInSpy.AddInGridControl
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AddInSpy
{
  public class AddInGridControl : UserControl, IAddInGridControl
  {
    private IContainer components = (IContainer) null;
    private DataGridView addInGrid;
    private DataGridViewTextBoxColumn Item;
    private DataGridViewTextBoxColumn Host;
    private DataGridViewCheckBoxColumn Running;
    private DataGridViewCheckBoxColumn Loaded;
    private DataGridViewTextBoxColumn Type;
    private DataGridViewTextBoxColumn FriendlyName;
    private DataGridViewTextBoxColumn ProgID;
    private DataGridViewTextBoxColumn CLSID;
    private DataGridViewTextBoxColumn Manifest;
    private DataGridViewTextBoxColumn DllPath;
    private DataGridViewTextBoxColumn LoadBehavior;
    private DataGridViewTextBoxColumn RegHive;
    private DataGridViewCheckBoxColumn Wow6432;
    private DataGridViewTextBoxColumn AssemblyName;
    private DataGridViewTextBoxColumn CLR_version;
    private DataGridViewCheckBoxColumn Exposed;
    private DataGridViewTextBoxColumn Interfaces;
    private DataGridViewTextBoxColumn FormRegions;
    private DataGridViewTextBoxColumn VSTOR;
    private DataGridViewTextBoxColumn Installed;
    private DataGridViewTextBoxColumn PubVer;
    private DataGridViewImageColumn Status2;
    private DataGridViewCheckBoxColumn Status;
    private DataGridViewTextBoxColumn StatusDescription;

    public DataGridView AddInGrid
    {
      get
      {
        return this.addInGrid;
      }
    }

    public AddInGridControl()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AddInGridControl));
      this.addInGrid = new DataGridView();
      this.Item = new DataGridViewTextBoxColumn();
      this.Host = new DataGridViewTextBoxColumn();
      this.Running = new DataGridViewCheckBoxColumn();
      this.Loaded = new DataGridViewCheckBoxColumn();
      this.Type = new DataGridViewTextBoxColumn();
      this.FriendlyName = new DataGridViewTextBoxColumn();
      this.ProgID = new DataGridViewTextBoxColumn();
      this.CLSID = new DataGridViewTextBoxColumn();
      this.Manifest = new DataGridViewTextBoxColumn();
      this.DllPath = new DataGridViewTextBoxColumn();
      this.LoadBehavior = new DataGridViewTextBoxColumn();
      this.RegHive = new DataGridViewTextBoxColumn();
      this.Wow6432 = new DataGridViewCheckBoxColumn();
      this.AssemblyName = new DataGridViewTextBoxColumn();
      this.CLR_version = new DataGridViewTextBoxColumn();
      this.Exposed = new DataGridViewCheckBoxColumn();
      this.Interfaces = new DataGridViewTextBoxColumn();
      this.FormRegions = new DataGridViewTextBoxColumn();
      this.VSTOR = new DataGridViewTextBoxColumn();
      this.Installed = new DataGridViewTextBoxColumn();
      this.PubVer = new DataGridViewTextBoxColumn();
      this.Status2 = new DataGridViewImageColumn();
      this.Status = new DataGridViewCheckBoxColumn();
      this.StatusDescription = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.addInGrid).BeginInit();
      this.SuspendLayout();
      this.addInGrid.AllowUserToAddRows = false;
      this.addInGrid.AllowUserToDeleteRows = false;
      this.addInGrid.AllowUserToOrderColumns = true;
      gridViewCellStyle1.BackColor = Color.Lavender;
      gridViewCellStyle1.SelectionBackColor = Color.Thistle;
      gridViewCellStyle1.SelectionForeColor = Color.Black;
      this.addInGrid.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      this.addInGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.addInGrid.Columns.AddRange((DataGridViewColumn) this.Item, (DataGridViewColumn) this.Host, (DataGridViewColumn) this.Running, (DataGridViewColumn) this.Loaded, (DataGridViewColumn) this.Type, (DataGridViewColumn) this.FriendlyName, (DataGridViewColumn) this.ProgID, (DataGridViewColumn) this.CLSID, (DataGridViewColumn) this.Manifest, (DataGridViewColumn) this.DllPath, (DataGridViewColumn) this.LoadBehavior, (DataGridViewColumn) this.RegHive, (DataGridViewColumn) this.Wow6432, (DataGridViewColumn) this.AssemblyName, (DataGridViewColumn) this.CLR_version, (DataGridViewColumn) this.Exposed, (DataGridViewColumn) this.Interfaces, (DataGridViewColumn) this.FormRegions, (DataGridViewColumn) this.VSTOR, (DataGridViewColumn) this.Installed, (DataGridViewColumn) this.PubVer, (DataGridViewColumn) this.Status2, (DataGridViewColumn) this.Status, (DataGridViewColumn) this.StatusDescription);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = Color.Thistle;
      gridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.addInGrid.DefaultCellStyle = gridViewCellStyle2;
      componentResourceManager.ApplyResources((object) this.addInGrid, "addInGrid");
      this.addInGrid.Name = "addInGrid";
      gridViewCellStyle3.SelectionBackColor = Color.Thistle;
      gridViewCellStyle3.SelectionForeColor = Color.Black;
      this.addInGrid.RowsDefaultCellStyle = gridViewCellStyle3;
      this.Item.DataPropertyName = "Item";
      componentResourceManager.ApplyResources((object) this.Item, "Item");
      this.Item.Name = "Item";
      this.Host.DataPropertyName = "Host";
      componentResourceManager.ApplyResources((object) this.Host, "Host");
      this.Host.Name = "Host";
      this.Running.DataPropertyName = "Running";
      componentResourceManager.ApplyResources((object) this.Running, "Running");
      this.Running.Name = "Running";
      this.Loaded.DataPropertyName = "Loaded";
      componentResourceManager.ApplyResources((object) this.Loaded, "Loaded");
      this.Loaded.Name = "Loaded";
      this.Type.DataPropertyName = "Type";
      componentResourceManager.ApplyResources((object) this.Type, "Type");
      this.Type.Name = "Type";
      this.FriendlyName.DataPropertyName = "FriendlyName";
      componentResourceManager.ApplyResources((object) this.FriendlyName, "FriendlyName");
      this.FriendlyName.Name = "FriendlyName";
      this.ProgID.DataPropertyName = "ProgID";
      componentResourceManager.ApplyResources((object) this.ProgID, "ProgID");
      this.ProgID.Name = "ProgID";
      this.CLSID.DataPropertyName = "CLSID";
      componentResourceManager.ApplyResources((object) this.CLSID, "CLSID");
      this.CLSID.Name = "CLSID";
      this.Manifest.DataPropertyName = "Manifest";
      componentResourceManager.ApplyResources((object) this.Manifest, "Manifest");
      this.Manifest.Name = "Manifest";
      this.DllPath.DataPropertyName = "DllPath";
      componentResourceManager.ApplyResources((object) this.DllPath, "DllPath");
      this.DllPath.Name = "DllPath";
      this.LoadBehavior.DataPropertyName = "LoadBehavior";
      componentResourceManager.ApplyResources((object) this.LoadBehavior, "LoadBehavior");
      this.LoadBehavior.Name = "LoadBehavior";
      this.RegHive.DataPropertyName = "RegHive";
      componentResourceManager.ApplyResources((object) this.RegHive, "RegHive");
      this.RegHive.Name = "RegHive";
      this.Wow6432.DataPropertyName = "Wow6432";
      componentResourceManager.ApplyResources((object)this.Wow6432, "Wow6432");
      this.Wow6432.Name = "Wow6432";
      this.AssemblyName.DataPropertyName = "AssemblyName";
      componentResourceManager.ApplyResources((object) this.AssemblyName, "AssemblyName");
      this.AssemblyName.Name = "AssemblyName";
      this.CLR_version.DataPropertyName = "CLR_version";
      componentResourceManager.ApplyResources((object) this.CLR_version, "CLR_version");
      this.CLR_version.Name = "CLR_version";
      this.Exposed.DataPropertyName = "Exposed";
      componentResourceManager.ApplyResources((object) this.Exposed, "Exposed");
      this.Exposed.Name = "Exposed";
      this.Interfaces.DataPropertyName = "Interfaces";
      componentResourceManager.ApplyResources((object) this.Interfaces, "Interfaces");
      this.Interfaces.Name = "Interfaces";
      this.FormRegions.DataPropertyName = "FormRegions";
      componentResourceManager.ApplyResources((object) this.FormRegions, "FormRegions");
      this.FormRegions.Name = "FormRegions";
      this.VSTOR.DataPropertyName = "VSTOR";
      componentResourceManager.ApplyResources((object) this.VSTOR, "VSTOR");
      this.VSTOR.Name = "VSTOR";
      this.Installed.DataPropertyName = "Installed";
      componentResourceManager.ApplyResources((object) this.Installed, "Installed");
      this.Installed.Name = "Installed";
      this.PubVer.DataPropertyName = "PubVer";
      componentResourceManager.ApplyResources((object) this.PubVer, "PubVer");
      this.PubVer.Name = "PubVer";
      this.Status2.DataPropertyName = "Status2";
      componentResourceManager.ApplyResources((object) this.Status2, "Status2");
      this.Status2.Name = "Status2";
      this.Status.DataPropertyName = "Status";
      componentResourceManager.ApplyResources((object) this.Status, "Status");
      this.Status.Name = "Status";
      this.StatusDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.StatusDescription.DataPropertyName = "StatusDescription";
      componentResourceManager.ApplyResources((object) this.StatusDescription, "StatusDescription");
      this.StatusDescription.Name = "StatusDescription";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.addInGrid);
      this.Name = "AddInGridControl";
      ((ISupportInitialize) this.addInGrid).EndInit();
      this.ResumeLayout(false);
    }
  }
}
