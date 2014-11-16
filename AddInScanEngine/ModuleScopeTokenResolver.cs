// Decompiled with JetBrains decompiler
// Type: AddInSpy.ModuleScopeTokenResolver
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System;
using System.Reflection;

namespace AddInSpy
{
  internal class ModuleScopeTokenResolver
  {
    private Module module;
    private Type[] methodContext;
    private Type[] typeContext;

    public ModuleScopeTokenResolver(MethodBase method)
    {
      this.module = method.Module;
      this.methodContext = method is ConstructorInfo ? (Type[]) null : method.GetGenericArguments();
      this.typeContext = method.DeclaringType == null ? (Type[]) null : method.DeclaringType.GetGenericArguments();
    }

    public MethodBase ResolveTokenAsMethod(int token)
    {
      MethodBase methodBase = (MethodBase) null;
      try
      {
        methodBase = this.module.ResolveMethod(token, this.typeContext, this.methodContext);
      }
      catch (Exception ex)
      {
      }
      return methodBase;
    }
  }
}
