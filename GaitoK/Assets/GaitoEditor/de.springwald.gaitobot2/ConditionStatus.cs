// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.ConditionStatus
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Xml;

namespace de.springwald.gaitobot2
{
  internal class ConditionStatus
  {
    public string Name { get; set; }

    public string Value { get; set; }

    public string Contains { get; set; }

    public string Exists { get; set; }

    public bool KannSchonSchliessen
    {
      get
      {
        return this.Name != null && (this.Value != null || this.Exists != null || this.Contains != null);
      }
    }

    public bool Erfuellt(GaitoBotSession session)
    {
      if (!this.KannSchonSchliessen)
        return false;
      if (this.GetIsEmpty(session))
      {
        if (this.Exists != null)
          return this.Exists == "false";
        return this.Contains != null || this.Value == null ? false : false;
      }
      if (this.Exists != null)
        return this.Exists == "true";
      string inhalt = this.GetInhalt(session);
      if (this.Value != null)
        return inhalt.ToLower() == this.Value.ToLower();
      if (this.Contains != null)
        return inhalt.IndexOf(this.Contains.ToLower()) != -1;
      return false;
    }

    public void AttributeAusNodeHinzufuegen(XmlNode node)
    {
      if (node.Attributes["name"] != null)
        this.Name = node.Attributes["name"].Value;
      if (node.Attributes["value"] != null)
        this.Value = node.Attributes["value"].Value;
      if (node.Attributes["contains"] != null)
        this.Contains = node.Attributes["contains"].Value;
      if (node.Attributes["exists"] == null)
        return;
      this.Exists = node.Attributes["exists"].Value;
    }

    public ConditionStatus Clone()
    {
      return new ConditionStatus()
      {
        Name = this.Name,
        Value = this.Value,
        Contains = this.Contains,
        Exists = this.Exists
      };
    }

    private bool GetIsEmpty(GaitoBotSession session)
    {
      if (StandardGlobaleEigenschaften.GetStandardConditionContent(this.Name) == null)
        return session.UserEigenschaften.IsEmpty(this.Name);
      return false;
    }

    private string GetInhalt(GaitoBotSession session)
    {
      return StandardGlobaleEigenschaften.GetStandardConditionContent(this.Name) ?? session.UserEigenschaften.Lesen(this.Name).ToLower();
    }
  }
}
