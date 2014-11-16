// Decompiled with JetBrains decompiler
// Type: AddInSpy.MethodInstruction
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System.Reflection;
using System.Reflection.Emit;

namespace AddInSpy
{
  internal class MethodInstruction
  {
    private ModuleScopeTokenResolver resolver;
    private MethodBase method;
    private int offset;
    private OpCode opCode;
    private int token;

    public int Offset
    {
      get
      {
        return this.offset;
      }
    }

    public OpCode OpCode
    {
      get
      {
        return this.opCode;
      }
    }

    public int Token
    {
      get
      {
        return this.token;
      }
    }

    public MethodBase Method
    {
      get
      {
        if (this.method == null)
          this.method = this.resolver.ResolveTokenAsMethod(this.token);
        return this.method;
      }
    }

    internal MethodInstruction(int offset, OpCode opCode, int token, ModuleScopeTokenResolver resolver)
    {
      this.offset = offset;
      this.opCode = opCode;
      this.resolver = resolver;
      this.token = token;
    }
  }
}
