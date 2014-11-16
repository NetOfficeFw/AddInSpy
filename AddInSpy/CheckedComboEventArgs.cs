// Decompiled with JetBrains decompiler
// Type: AddInSpy.CheckedComboEventArgs
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System;

namespace AddInSpy
{
  public class CheckedComboEventArgs : EventArgs
  {
    public string[] Names;

    public CheckedComboEventArgs(string[] names)
    {
      this.Names = names;
    }
  }
}
