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
using AppResources = AddInSpy.Properties.Resources;

namespace AddInSpy
{
  public partial class HelpWindow : Window, IComponentConnector
  {
    private string helpFilePath;

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
      this.buttonHomeText.Text = AppResources.BUTTON_HOME;
      this.buttonHome.ToolTip = (object) AppResources.BUTTON_HOME_TOOLTIP;
      this.buttonBackText.Text = AppResources.BUTTON_BACK;
      this.buttonBack.ToolTip = (object) AppResources.BUTTON_BACK_TOOLTIP;
      this.buttonForwardText.Text = AppResources.BUTTON_FORWARD;
      this.buttonForward.ToolTip = (object) AppResources.BUTTON_FORWARD_TOOLTIP;
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
  }
}
