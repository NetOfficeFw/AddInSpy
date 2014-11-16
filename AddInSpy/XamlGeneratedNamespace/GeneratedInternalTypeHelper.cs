// Decompiled with JetBrains decompiler
// Type: XamlGeneratedNamespace.GeneratedInternalTypeHelper
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;

namespace XamlGeneratedNamespace
{
  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public sealed class GeneratedInternalTypeHelper : InternalTypeHelper
  {
    protected override object CreateInstance(Type type, CultureInfo culture)
    {
      return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, (Binder) null, (object[]) null, culture);
    }

    protected override object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
    {
      return propertyInfo.GetValue(target, BindingFlags.Default, (Binder) null, (object[]) null, culture);
    }

    protected override void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
    {
      propertyInfo.SetValue(target, value, BindingFlags.Default, (Binder) null, (object[]) null, culture);
    }

    protected override Delegate CreateDelegate(Type delegateType, object target, string handler)
    {
      return (Delegate) target.GetType().InvokeMember("_CreateDelegate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, (Binder) null, target, new object[2]
      {
        (object) delegateType,
        (object) handler
      }, (CultureInfo) null);
    }

    protected override void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
    {
      eventInfo.AddEventHandler(target, handler);
    }
  }
}
