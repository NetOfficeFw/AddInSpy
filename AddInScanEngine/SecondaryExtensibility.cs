// Decompiled with JetBrains decompiler
// Type: AddInSpy.SecondaryExtensibility
// Assembly: AddInScanEngine, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F92CC3BC-B994-4216-9D73-6B4F2C71BD20
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInScanEngine.dll

using System;
using System.Collections.Generic;

namespace AddInSpy
{
  internal class SecondaryExtensibility
  {
    private IDictionary<string, Guid> addInInterfaces;

    internal IDictionary<string, Guid> AddInInterfaces
    {
      get
      {
        return this.addInInterfaces;
      }
    }

    public SecondaryExtensibility(string hostName)
    {
      this.addInInterfaces = (IDictionary<string, Guid>) new Dictionary<string, Guid>();
      switch (hostName)
      {
        case "Access":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IRibbonExtensibility", new Guid("{000C0396-0000-0000-C000-000000000046}")));
          break;
        case "Excel":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IRibbonExtensibility", new Guid("{000C0396-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("EncryptionProvider", new Guid("{000CD809-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("SignatureProvider", new Guid("{000CD6A3-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IDocumentInspector", new Guid("{000C0393-0000-0000-C000-000000000046}")));
          break;
        case "InfoPath":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          break;
        case "Outlook":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IRibbonExtensibility", new Guid("{000C0396-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("FormRegionStartup", new Guid("{00063059-0000-0000-C000-000000000046}")));
          break;
        case "PowerPoint":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IRibbonExtensibility", new Guid("{000C0396-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("EncryptionProvider", new Guid("{000CD809-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("SignatureProvider", new Guid("{000CD6A3-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IDocumentInspector", new Guid("{000C0393-0000-0000-C000-000000000046}")));
          break;
        case "Word":
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("ICustomTaskPaneConsumer", new Guid("{000C033E-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IRibbonExtensibility", new Guid("{000C0396-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("EncryptionProvider", new Guid("{000CD809-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("SignatureProvider", new Guid("{000CD6A3-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IDocumentInspector", new Guid("{000C0393-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IBlogExtensibility", new Guid("{000C03C4-0000-0000-C000-000000000046}")));
          this.addInInterfaces.Add(new KeyValuePair<string, Guid>("IBlogPictureExtensibility", new Guid("{000C03C5-0000-0000-C000-000000000046}")));
          break;
      }
    }
  }
}
