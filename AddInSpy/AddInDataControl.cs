// Decompiled with JetBrains decompiler
// Type: AddInSpy.AddInDataControl
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AddInSpy
{
  public class AddInDataControl : UserControl
  {
    private IContainer components = (IContainer) null;
    internal DataGridView dataGrid;
    private DataGridViewTextBoxColumn Item;
    private DataGridViewTextBoxColumn Value;

    public AddInDataControl()
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AddInDataControl));
      this.dataGrid = new DataGridView();
      this.Item = new DataGridViewTextBoxColumn();
      this.Value = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dataGrid).BeginInit();
      this.SuspendLayout();
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      gridViewCellStyle.BackColor = Color.Lavender;
      gridViewCellStyle.SelectionBackColor = Color.Thistle;
      gridViewCellStyle.SelectionForeColor = Color.Black;
      this.dataGrid.AlternatingRowsDefaultCellStyle = gridViewCellStyle;
      this.dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Columns.AddRange((DataGridViewColumn) this.Item, (DataGridViewColumn) this.Value);
      componentResourceManager.ApplyResources((object) this.dataGrid, "dataGrid");
      this.dataGrid.Name = "dataGrid";
      this.Item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.Item.DataPropertyName = "Item";
      this.Item.FillWeight = 121.8274f;
      componentResourceManager.ApplyResources((object) this.Item, "Item");
      this.Item.Name = "Item";
      this.Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.Value.DataPropertyName = "Value";
      this.Value.FillWeight = 78.17259f;
      componentResourceManager.ApplyResources((object) this.Value, "Value");
      this.Value.Name = "Value";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGrid);
      this.Name = "AddInDataControl";
      ((ISupportInitialize) this.dataGrid).EndInit();
      this.ResumeLayout(false);
    }
  }
}
