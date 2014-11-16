// Decompiled with JetBrains decompiler
// Type: AddInSpy.App
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System;
using System.Diagnostics;
using System.Windows;

namespace AddInSpy
{
  public class App : Application
  {
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      this.StartupUri = new Uri("AddInSpyWindow.xaml", UriKind.Relative);
    }

    [DebuggerNonUserCode]
    [STAThread]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
