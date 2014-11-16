// Decompiled with JetBrains decompiler
// Type: AddInSpy.CheckedComboControl
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using AddInSpy.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using AppResources = AddInSpy.Properties.Resources;

namespace AddInSpy
{
  public partial class CheckedComboControl : UserControl, IComponentConnector
  {
    public string[] CheckedItems
    {
      get
      {
        List<string> list = new List<string>();
        foreach (object obj in (IEnumerable) this.Combo.Items)
        {
          int num;
          if (obj is CheckBox)
          {
            bool? isChecked = ((ToggleButton) obj).IsChecked;
            if (isChecked.HasValue)
            {
              isChecked = ((ToggleButton) obj).IsChecked;
              num = !isChecked.Value ? 1 : 0;
              goto label_6;
            }
          }
          num = 1;
label_6:
          if (num == 0)
            list.Add(((ContentControl) obj).Content.ToString());
        }
        return list.ToArray();
      }
    }

    public event CheckedComboClick CheckedComboClickEvent;

    public CheckedComboControl()
    {
      this.InitializeComponent();
    }

    internal void CheckBox_Click(object sender, RoutedEventArgs e)
    {
      List<string> list = new List<string>();
      string str = string.Empty;
      CheckBox checkBox1 = (CheckBox) sender;
      if (checkBox1.Name == "checkAll")
      {
        for (int index = 1; index < this.Combo.Items.Count; ++index)
          ((ToggleButton) this.Combo.Items[index]).IsChecked = checkBox1.IsChecked;
      }
      for (int index = 1; index < this.Combo.Items.Count; ++index)
      {
        CheckBox checkBox2 = (CheckBox) this.Combo.Items[index];
        bool? isChecked = checkBox2.IsChecked;
        int num;
        if (isChecked.HasValue)
        {
          isChecked = checkBox2.IsChecked;
          num = !isChecked.Value ? 1 : 0;
        }
        else
          num = 1;
        if (num == 0)
        {
          str = checkBox2.Content.ToString();
          list.Add(str);
        }
      }
      if (list.Count == 0)
        this.Combo.Text = AppResources.OPTION_NONE;
      else if (list.Count == 1)
        this.Combo.Text = str;
      else if (list.Count == this.Combo.Items.Count - 1)
        this.Combo.Text = AppResources.OPTION_ALL;
      else if (list.Count > 1)
        this.Combo.Text = AppResources.OPTION_MULTIPLE;
      CheckedComboEventArgs e1 = new CheckedComboEventArgs(list.ToArray());
      if (this.CheckedComboClickEvent == null)
        return;
      this.CheckedComboClickEvent((object) this, e1);
    }
  }
}
