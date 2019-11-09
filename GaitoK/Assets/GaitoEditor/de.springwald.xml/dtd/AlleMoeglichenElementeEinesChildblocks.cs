// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.AlleMoeglichenElementeEinesChildblocks
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Collections.Specialized;

namespace de.springwald.xml.dtd
{
  public class AlleMoeglichenElementeEinesChildblocks
  {
    private StringCollection _gefundeneElemente;

    public StringCollection GefundeneElemente
    {
      get
      {
        return this._gefundeneElemente;
      }
    }

    public AlleMoeglichenElementeEinesChildblocks(DTDChildElemente childBlock)
    {
      this._gefundeneElemente = new StringCollection();
      this.Durchsuchen(childBlock);
    }

    private void Durchsuchen(DTDChildElemente childBlock)
    {
      switch (childBlock.Art)
      {
        case DTDChildElemente.DTDChildElementArten.EinzelChild:
          this.ElementMerken(childBlock.ElementName);
          break;
        case DTDChildElemente.DTDChildElementArten.ChildListe:
          for (int index = 0; index < childBlock.AnzahlChildren; ++index)
            this.Durchsuchen(childBlock.Child(index));
          break;
      }
    }

    private void ElementMerken(string elementName)
    {
      if (this._gefundeneElemente.Contains(elementName))
        return;
      this._gefundeneElemente.Add(elementName);
    }
  }
}
