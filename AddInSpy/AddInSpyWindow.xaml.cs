// Decompiled with JetBrains decompiler
// Type: AddInSpy.AddInSpyWindow
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using AddInSpy.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace AddInSpy
{
  public partial class AddInSpyWindow : Window, IComponentConnector
  {
    private const string helpFileName = "AddInSpy.mht";
    private Controller controller;
    internal System.Windows.Controls.CheckBox checkHKCU;
    internal System.Windows.Controls.CheckBox checkHKLM;
    internal System.Windows.Controls.CheckBox checkRemote;
    internal System.Windows.Controls.CheckBox checkManagedIfs;
    internal System.Windows.Controls.CheckBox checkNativeIfs;
    internal System.Windows.Controls.CheckBox checkDisabled;
    internal System.Windows.Controls.CheckBox checkFormRegions;
    private System.Windows.Controls.CheckBox checkContext;
    private System.Windows.Controls.CheckBox checkAddIns;
    private HelpWindow helpWindow;
    internal Grid outerGrid;
    internal Grid innerGrid;
    internal System.Windows.Controls.Label labelHosts;
    internal CheckedComboControl selectedHosts;
    internal System.Windows.Controls.Label labelScans;
    internal CheckedComboControl selectedScans;
    internal System.Windows.Controls.Button buttonRefresh;
    internal TextBlock buttonRefreshText;
    internal System.Windows.Controls.CheckBox autoRefresh;
    internal System.Windows.Controls.Label labelReport;
    internal CheckedComboControl selectedReport;
    internal System.Windows.Controls.Button buttonReport;
    internal TextBlock buttonReportText;
    internal System.Windows.Controls.Button buttonHelp;
    internal TextBlock buttonHelpText;
    internal WfGridProxyControl gridControl;
    internal System.Windows.Controls.Primitives.StatusBar statusBar;
    internal TextBlock statusMachine;
    internal TextBlock statusUser;
    internal TextBlock statusOS;
    internal TextBlock statusVstoSuppressDisplayAlerts;
    internal TextBlock statusVstoLogAlerts;
    internal TextBlock statusAddInsFound;
    private bool _contentLoaded;

    public AddInSpyWindow()
    {
      this.InitializeComponent();
      this.InitializeUI();
      this.InitializeSelectedHosts();
      this.InitializeSelectedScans();
      this.InitializeSelectedReport();
      this.controller = new Controller(this.checkHKCU.IsChecked.Value, this.checkHKLM.IsChecked.Value, this.checkRemote.IsChecked.Value, this.checkManagedIfs.IsChecked.Value, this.checkNativeIfs.IsChecked.Value, this.checkDisabled.IsChecked.Value, this.checkFormRegions.IsChecked.Value);
      this.gridControl.addInGridControl.AddInGrid.DataSource = (object) this.controller.GridProxy.AddInDataTable;
      this.gridControl.addInGridControl.AddInGrid.CellContentDoubleClick += new DataGridViewCellEventHandler(this.AddInGrid_CellContentDoubleClick);
      this.InitializeStatusBar();
    }

    private void InitializeUI()
    {
      this.labelHosts.Content = (object) Resources.LABEL_HOSTS;
      this.selectedHosts.ToolTip = (object) Resources.CHECKEDCOMBO_HOSTS_TOOLTIP;
      this.labelScans.Content = (object) Resources.LABEL_SCANS;
      this.selectedScans.ToolTip = (object) Resources.CHECKEDCOMBO_SCANS_TOOLTIP;
      this.buttonRefreshText.Text = Resources.BUTTON_REFRESH;
      this.buttonRefresh.ToolTip = (object) Resources.BUTTON_REFRESH_TOOLTIP;
      this.autoRefresh.Content = (object) Resources.CHECKBOX_AUTOREFRESH;
      this.autoRefresh.ToolTip = (object) Resources.CHECKBOX_AUTOREFRESH_TOOLTIP;
      this.labelReport.Content = (object) Resources.LABEL_REPORT;
      this.selectedReport.ToolTip = (object) Resources.CHECKEDCOMBO_REPORT_TOOLTIP;
      this.buttonReportText.Text = Resources.BUTTON_REPORT;
      this.buttonReport.ToolTip = (object) Resources.BUTTON_REPORT_TOOLTIP;
      this.buttonHelpText.Text = Resources.BUTTON_HELP;
      this.buttonHelp.ToolTip = (object) Resources.BUTTON_HELP_TOOLTIP;
      this.statusMachine.Text = Resources.LABEL_MACHINE;
      this.statusUser.Text = Resources.LABEL_USER;
      this.statusOS.Text = Resources.LABEL_OS;
    }

    private void InitializeStatusBar()
    {
      this.statusMachine.Text = Resources.LABEL_MACHINE + this.controller.HostName;
      this.statusUser.Text = Resources.LABEL_USER + this.controller.DomainName + "\\" + this.controller.UserName;
      this.statusOS.Text = Resources.LABEL_OS + this.controller.OsVersion;
      this.statusVstoSuppressDisplayAlerts.Text = "VSTO_SUPPRESSDISPLAYALERTS=" + this.controller.VstoSuppressDisplayAlerts;
      this.statusVstoLogAlerts.Text = "VSTO_LOGALERTS=" + this.controller.VstoLogAlerts;
      this.statusAddInsFound.Text = string.Format("{0}{1}", (object) Resources.STATUS_ADDIN_COUNT, (object) this.controller.GridProxy.AddInCount);
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
      if (this.helpWindow == null)
        return;
      this.helpWindow.Close();
      this.helpWindow = (HelpWindow) null;
    }

    private void InitializeSelectedHosts()
    {
      this.selectedHosts.Combo.Text = Resources.OPTION_NONE;
      System.Windows.Controls.CheckBox checkBox1 = new System.Windows.Controls.CheckBox();
      checkBox1.Content = (object) Resources.OPTION_ALL;
      checkBox1.Name = "checkAll";
      checkBox1.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox1);
      System.Windows.Controls.CheckBox checkBox2 = new System.Windows.Controls.CheckBox();
      checkBox2.Content = (object) "Access";
      checkBox2.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox2);
      System.Windows.Controls.CheckBox checkBox3 = new System.Windows.Controls.CheckBox();
      checkBox3.Content = (object) "Excel";
      checkBox3.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox3);
      System.Windows.Controls.CheckBox checkBox4 = new System.Windows.Controls.CheckBox();
      checkBox4.Content = (object) "FrontPage";
      checkBox4.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox4);
      System.Windows.Controls.CheckBox checkBox5 = new System.Windows.Controls.CheckBox();
      checkBox5.Content = (object) "InfoPath";
      checkBox5.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox5);
      System.Windows.Controls.CheckBox checkBox6 = new System.Windows.Controls.CheckBox();
      checkBox6.Content = (object) "Outlook";
      checkBox6.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox6);
      System.Windows.Controls.CheckBox checkBox7 = new System.Windows.Controls.CheckBox();
      checkBox7.Content = (object) "PowerPoint";
      checkBox7.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox7);
      System.Windows.Controls.CheckBox checkBox8 = new System.Windows.Controls.CheckBox();
      checkBox8.Content = (object) "Project";
      checkBox8.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox8);
      System.Windows.Controls.CheckBox checkBox9 = new System.Windows.Controls.CheckBox();
      checkBox9.Content = (object) "Publisher";
      checkBox9.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox9);
      System.Windows.Controls.CheckBox checkBox10 = new System.Windows.Controls.CheckBox();
      checkBox10.Content = (object) "SharePoint Designer";
      checkBox10.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox10);
      System.Windows.Controls.CheckBox checkBox11 = new System.Windows.Controls.CheckBox();
      checkBox11.Content = (object) "Visio";
      checkBox11.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox11);
      System.Windows.Controls.CheckBox checkBox12 = new System.Windows.Controls.CheckBox();
      checkBox12.Content = (object) "Word";
      checkBox12.Click += new RoutedEventHandler(this.selectedHosts.CheckBox_Click);
      this.selectedHosts.Combo.Items.Add((object) checkBox12);
      this.selectedHosts.CheckedComboClickEvent += new CheckedComboClick(this.selectedHosts_CheckedComboClickEvent);
    }

    private void InitializeSelectedScans()
    {
      this.selectedScans.Combo.Text = Resources.OPTION_MULTIPLE;
      System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
      checkBox.Content = (object) Resources.OPTION_ALL;
      checkBox.Name = "checkAll";
      checkBox.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) checkBox);
      this.checkHKCU = new System.Windows.Controls.CheckBox();
      this.checkHKCU.Content = (object) Resources.SCAN_HKCU;
      this.checkHKCU.Name = "checkHKCU";
      this.checkHKCU.ToolTip = (object) Resources.SCAN_HKCU_TOOLTIP;
      this.checkHKCU.IsChecked = new bool?(true);
      this.checkHKCU.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkHKCU);
      this.checkHKLM = new System.Windows.Controls.CheckBox();
      this.checkHKLM.Content = (object) Resources.SCAN_HKLM;
      this.checkHKLM.Name = "checkHKLM";
      this.checkHKLM.ToolTip = (object) Resources.SCAN_HKLM_TOOLTIP;
      this.checkHKLM.IsChecked = new bool?(true);
      this.checkHKLM.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkHKLM);
      this.checkRemote = new System.Windows.Controls.CheckBox();
      this.checkRemote.Content = (object) Resources.SCAN_REMOTE;
      this.checkRemote.Name = "checkRemote";
      this.checkRemote.ToolTip = (object) Resources.SCAN_REMOTE_TOOLTIP;
      this.checkRemote.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkRemote);
      this.checkManagedIfs = new System.Windows.Controls.CheckBox();
      this.checkManagedIfs.Content = (object) Resources.SCAN_MANAGED_INTERFACES;
      this.checkManagedIfs.Name = "checkManagedIfs";
      this.checkManagedIfs.ToolTip = (object) Resources.SCAN_MANAGED_INTERFACES_TOOLTIP;
      this.checkManagedIfs.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkManagedIfs);
      this.checkNativeIfs = new System.Windows.Controls.CheckBox();
      this.checkNativeIfs.Content = (object) Resources.SCAN_NATIVE_INTERFACES;
      this.checkNativeIfs.Name = "checkNativeIfs";
      this.checkNativeIfs.ToolTip = (object) Resources.SCAN_NATIVE_INTERFACES_TOOLTIP;
      this.checkNativeIfs.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkNativeIfs);
      this.checkDisabled = new System.Windows.Controls.CheckBox();
      this.checkDisabled.Content = (object) Resources.SCAN_DISABLED_ITEMS;
      this.checkDisabled.Name = "checkDisabled";
      this.checkDisabled.ToolTip = (object) Resources.SCAN_DISABLED_ITEMS_TOOLTIP;
      this.checkDisabled.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkDisabled);
      this.checkFormRegions = new System.Windows.Controls.CheckBox();
      this.checkFormRegions.Content = (object) Resources.SCAN_FORMREGIONS;
      this.checkFormRegions.Name = "checkFormRegions";
      this.checkFormRegions.ToolTip = (object) Resources.SCAN_FORMREGIONS_TOOLTIP;
      this.checkFormRegions.Click += new RoutedEventHandler(this.selectedScans.CheckBox_Click);
      this.selectedScans.Combo.Items.Add((object) this.checkFormRegions);
      this.selectedScans.CheckedComboClickEvent += new CheckedComboClick(this.selectedScans_CheckedComboClickEvent);
    }

    private void InitializeSelectedReport()
    {
      this.selectedReport.Combo.Text = Resources.OPTION_ALL;
      System.Windows.Controls.CheckBox checkBox = new System.Windows.Controls.CheckBox();
      checkBox.Content = (object) Resources.OPTION_ALL;
      checkBox.Name = "checkAll";
      checkBox.IsChecked = new bool?(true);
      checkBox.Click += new RoutedEventHandler(this.selectedReport.CheckBox_Click);
      this.selectedReport.Combo.Items.Add((object) checkBox);
      this.checkContext = new System.Windows.Controls.CheckBox();
      this.checkContext.Content = (object) Resources.REPORT_CONTEXT;
      this.checkContext.Name = "reportContext";
      this.checkContext.ToolTip = (object) Resources.REPORT_CONTEXT_TOOLTIP;
      this.checkContext.IsChecked = new bool?(true);
      this.checkContext.Click += new RoutedEventHandler(this.selectedReport.CheckBox_Click);
      this.selectedReport.Combo.Items.Add((object) this.checkContext);
      this.checkAddIns = new System.Windows.Controls.CheckBox();
      this.checkAddIns.Content = (object) Resources.REPORT_ADDINS;
      this.checkAddIns.Name = "reportAddIns";
      this.checkAddIns.ToolTip = (object) Resources.REPORT_ADDINS_TOOLTIP;
      this.checkAddIns.IsChecked = new bool?(true);
      this.checkAddIns.Click += new RoutedEventHandler(this.selectedReport.CheckBox_Click);
      this.selectedReport.Combo.Items.Add((object) this.checkAddIns);
      this.selectedReport.CheckedComboClickEvent += new CheckedComboClick(this.selectedReport_CheckedComboClickEvent);
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
      base.OnRenderSizeChanged(sizeInfo);
      this.gridControl.Width = sizeInfo.NewSize.Width - 2.0 * SystemParameters.ResizeFrameVerticalBorderWidth;
      this.gridControl.Height = sizeInfo.NewSize.Height - 2.0 * SystemParameters.ResizeFrameHorizontalBorderHeight - this.innerGrid.ActualHeight;
    }

    private void selectedHosts_CheckedComboClickEvent(object sender, CheckedComboEventArgs e)
    {
      this.controller.HostNames = e.Names;
      if (!this.controller.AutoRefresh)
        return;
      this.controller.Refresh();
      this.InitializeStatusBar();
    }

    private void selectedScans_CheckedComboClickEvent(object sender, CheckedComboEventArgs e)
    {
      this.controller.ScanNames = e.Names;
      if (!this.controller.AutoRefresh)
        return;
      this.controller.Refresh();
      this.InitializeStatusBar();
    }

    private void selectedReport_CheckedComboClickEvent(object sender, CheckedComboEventArgs e)
    {
      this.controller.ReportTypes = e.Names;
      if (!this.controller.AutoRefresh)
        return;
      this.controller.Refresh();
      this.InitializeStatusBar();
    }

    private void buttonRefresh_Click(object sender, RoutedEventArgs e)
    {
      this.controller.Refresh();
      this.InitializeStatusBar();
    }

    private void buttonReport_Click(object sender, RoutedEventArgs e)
    {
      bool reportContext = this.checkContext.IsChecked.Value;
      bool reportAddIns = this.checkAddIns.IsChecked.Value;
      Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
      saveFileDialog.Filter = "XML Files|*.xml|All Files|*.* ";
      saveFileDialog.DefaultExt = "xml";
      if (!saveFileDialog.ShowDialog().Value)
        return;
      string fileName = saveFileDialog.FileName;
      this.controller.GenerateReport(reportContext, reportAddIns, fileName);
    }

    private void buttonHelp_Click(object sender, RoutedEventArgs e)
    {
      string str = Path.Combine(Environment.CurrentDirectory, "AddInSpy.mht");
      if (!File.Exists(str))
      {
        int num = (int) System.Windows.MessageBox.Show(Resources.HELPFILE_NOT_FOUND, Resources.WARNING, MessageBoxButton.OK, MessageBoxImage.Exclamation);
      }
      else
      {
        if (this.helpWindow == null)
        {
          this.helpWindow = new HelpWindow(str);
          this.helpWindow.ShowInTaskbar = false;
          this.helpWindow.Closing += new CancelEventHandler(this.helpWindow_Closing);
        }
        this.helpWindow.Show();
        this.helpWindow.Activate();
      }
    }

    private void helpWindow_Closing(object sender, CancelEventArgs e)
    {
      this.helpWindow = (HelpWindow) null;
    }

    private void autoRefresh_Click(object sender, RoutedEventArgs e)
    {
      System.Windows.Controls.CheckBox checkBox = (System.Windows.Controls.CheckBox) sender;
      if (checkBox.IsChecked.HasValue && checkBox.IsChecked.Value)
      {
        this.controller.AutoRefresh = true;
        this.controller.Refresh();
        this.InitializeStatusBar();
      }
      else
        this.controller.AutoRefresh = false;
    }

    private void AddInGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      DataRow dataRow = this.controller.GridProxy.AddInDataTable.Rows[e.RowIndex];
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(Resources.SINGLE_ROW_TABLE_ITEM_COLUMN);
      dataTable.Columns.Add(Resources.SINGLE_ROW_TABLE_VALUE_COLUMN);
      for (int index = 0; index < dataRow.ItemArray.Length; ++index)
      {
        string str1 = dataRow.Table.Columns[index].Caption;
        if (!(str1 == "Status2"))
        {
          string str2 = dataRow.ItemArray[index].ToString();
          if (str1 == "Item")
            str1 = Resources.SINGLE_ROW_TABLE_ITEM_NUMBER;
          if (str1 == "Status")
            str2 = !(str2 == "True") ? Resources.STATUS_ALERT : Resources.STATUS_OK;
          dataTable.Rows.Add((object) str1, (object) str2);
        }
      }
      new WfDataProxyWindow()
      {
        addInDataControl = {
          dataGrid = {
            DataSource = ((object) dataTable)
          }
        }
      }.ShowDialog();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      System.Windows.Application.LoadComponent((object) this, new Uri("/AddInSpy;component/addinspywindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    internal Delegate _CreateDelegate(System.Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((Window) target).Closing += new CancelEventHandler(this.Window_Closing);
          break;
        case 2:
          this.outerGrid = (Grid) target;
          break;
        case 3:
          this.innerGrid = (Grid) target;
          break;
        case 4:
          this.labelHosts = (System.Windows.Controls.Label) target;
          break;
        case 5:
          this.selectedHosts = (CheckedComboControl) target;
          break;
        case 6:
          this.labelScans = (System.Windows.Controls.Label) target;
          break;
        case 7:
          this.selectedScans = (CheckedComboControl) target;
          break;
        case 8:
          this.buttonRefresh = (System.Windows.Controls.Button) target;
          this.buttonRefresh.Click += new RoutedEventHandler(this.buttonRefresh_Click);
          break;
        case 9:
          this.buttonRefreshText = (TextBlock) target;
          break;
        case 10:
          this.autoRefresh = (System.Windows.Controls.CheckBox) target;
          this.autoRefresh.Click += new RoutedEventHandler(this.autoRefresh_Click);
          break;
        case 11:
          this.labelReport = (System.Windows.Controls.Label) target;
          break;
        case 12:
          this.selectedReport = (CheckedComboControl) target;
          break;
        case 13:
          this.buttonReport = (System.Windows.Controls.Button) target;
          this.buttonReport.Click += new RoutedEventHandler(this.buttonReport_Click);
          break;
        case 14:
          this.buttonReportText = (TextBlock) target;
          break;
        case 15:
          this.buttonHelp = (System.Windows.Controls.Button) target;
          this.buttonHelp.Click += new RoutedEventHandler(this.buttonHelp_Click);
          break;
        case 16:
          this.buttonHelpText = (TextBlock) target;
          break;
        case 17:
          this.gridControl = (WfGridProxyControl) target;
          break;
        case 18:
          this.statusBar = (System.Windows.Controls.Primitives.StatusBar) target;
          break;
        case 19:
          this.statusMachine = (TextBlock) target;
          break;
        case 20:
          this.statusUser = (TextBlock) target;
          break;
        case 21:
          this.statusOS = (TextBlock) target;
          break;
        case 22:
          this.statusVstoSuppressDisplayAlerts = (TextBlock) target;
          break;
        case 23:
          this.statusVstoLogAlerts = (TextBlock) target;
          break;
        case 24:
          this.statusAddInsFound = (TextBlock) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
