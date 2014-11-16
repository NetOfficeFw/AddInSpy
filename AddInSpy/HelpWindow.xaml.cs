// Decompiled with JetBrains decompiler
// Type: AddInSpy.HelpWindow
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using AddInSpy.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace AddInSpy
{
  public partial class HelpWindow : Window, IComponentConnector
  {
    private string helpFilePath;
    internal Grid outerGrid;
    internal Grid innerGrid;
    internal Button buttonHome;
    internal TextBlock buttonHomeText;
    internal Button buttonBack;
    internal TextBlock buttonBackText;
    internal Button buttonForward;
    internal TextBlock buttonForwardText;
    internal WebBrowser webBrowser;
    private bool _contentLoaded;

    public HelpWindow()
    {
      this.InitializeComponent();
    }

    public HelpWindow(string helpFilePath)
      : this()
    {
      this.helpFilePath = helpFilePath;
      this.InitializeUI();
      this.webBrowser.Navigate(new Uri(helpFilePath));
      this.webBrowser.Navigated += new NavigatedEventHandler(this.webBrowser_Navigated);
    }

    private void InitializeUI()
    {
      this.buttonHomeText.Text = Resources.BUTTON_HOME;
      this.buttonHome.ToolTip = (object) Resources.BUTTON_HOME_TOOLTIP;
      this.buttonBackText.Text = Resources.BUTTON_BACK;
      this.buttonBack.ToolTip = (object) Resources.BUTTON_BACK_TOOLTIP;
      this.buttonForwardText.Text = Resources.BUTTON_FORWARD;
      this.buttonForward.ToolTip = (object) Resources.BUTTON_FORWARD_TOOLTIP;
    }

    private void webBrowser_Navigated(object sender, NavigationEventArgs e)
    {
      this.buttonBack.IsEnabled = this.webBrowser.CanGoBack;
      this.buttonForward.IsEnabled = this.webBrowser.CanGoForward;
    }

    private void buttonHome_Click(object sender, RoutedEventArgs e)
    {
      this.webBrowser.Navigate(new Uri(this.helpFilePath));
    }

    private void buttonBack_Click(object sender, RoutedEventArgs e)
    {
      this.webBrowser.GoBack();
    }

    private void buttonForward_Click(object sender, RoutedEventArgs e)
    {
      this.webBrowser.GoForward();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/AddInSpy;component/helpwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.outerGrid = (Grid) target;
          break;
        case 2:
          this.innerGrid = (Grid) target;
          break;
        case 3:
          this.buttonHome = (Button) target;
          this.buttonHome.Click += new RoutedEventHandler(this.buttonHome_Click);
          break;
        case 4:
          this.buttonHomeText = (TextBlock) target;
          break;
        case 5:
          this.buttonBack = (Button) target;
          this.buttonBack.Click += new RoutedEventHandler(this.buttonBack_Click);
          break;
        case 6:
          this.buttonBackText = (TextBlock) target;
          break;
        case 7:
          this.buttonForward = (Button) target;
          this.buttonForward.Click += new RoutedEventHandler(this.buttonForward_Click);
          break;
        case 8:
          this.buttonForwardText = (TextBlock) target;
          break;
        case 9:
          this.webBrowser = (WebBrowser) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
