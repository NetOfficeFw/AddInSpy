// Decompiled with JetBrains decompiler
// Type: AddInSpy.ILReader
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace AddInSpy
{
  internal class ILReader : IEnumerable<MethodInstruction>, IEnumerable
  {
    private static OpCode[] OneByteOpCodes = new OpCode[256];
    private static OpCode[] TwoByteOpCodes = new OpCode[256];
    private int position;
    private ModuleScopeTokenResolver resolver;
    private byte[] byteArray;
    private MethodBase methodBase;

    static ILReader()
    {
      foreach (FieldInfo fieldInfo in typeof (OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
      {
        OpCode opCode = (OpCode) fieldInfo.GetValue((object) null);
        ushort num = (ushort) opCode.Value;
        if ((int) num < 256)
          ILReader.OneByteOpCodes[(int) num] = opCode;
        else if (((int) num & 65280) == 65024)
          ILReader.TwoByteOpCodes[(int) num & (int) byte.MaxValue] = opCode;
      }
    }

    public ILReader(MethodBase method)
    {
      if (method == null)
        throw new ArgumentNullException("method == null");
      this.methodBase = method;
      this.resolver = new ModuleScopeTokenResolver(method);
      MethodBody methodBody = this.methodBase.GetMethodBody();
      this.byteArray = methodBody == null ? new byte[0] : methodBody.GetILAsByteArray();
      this.position = 0;
    }

    public IEnumerator<MethodInstruction> GetEnumerator()
    {
      while (this.position < this.byteArray.Length)
        yield return this.Next();
      this.position = 0;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    private MethodInstruction Next()
    {
      int offset = this.position;
      OpCode opCode1 = OpCodes.Nop;
      byte num1 = this.byteArray[this.position++];
      OpCode opCode2;
      if ((int) num1 != 254)
      {
        opCode2 = ILReader.OneByteOpCodes[(int) num1];
      }
      else
      {
        byte num2 = this.byteArray[this.position++];
        opCode2 = ILReader.TwoByteOpCodes[(int) num2];
      }
      if (opCode2.OperandType != OperandType.InlineMethod)
        return (MethodInstruction) null;
      int startIndex = this.position;
      this.position += 4;
      int token = BitConverter.ToInt32(this.byteArray, startIndex);
      return new MethodInstruction(offset, opCode2, token, this.resolver);
    }
  }
}
