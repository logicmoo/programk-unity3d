// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.RewriteRuleSubtreeStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class RewriteRuleSubtreeStream : RewriteRuleElementStream
  {
    public RewriteRuleSubtreeStream(ITreeAdaptor adaptor, string elementDescription)
      : base(adaptor, elementDescription)
    {
    }

    public RewriteRuleSubtreeStream(
      ITreeAdaptor adaptor,
      string elementDescription,
      object oneElement)
      : base(adaptor, elementDescription, oneElement)
    {
    }

    public RewriteRuleSubtreeStream(
      ITreeAdaptor adaptor,
      string elementDescription,
      IList elements)
      : base(adaptor, elementDescription, elements)
    {
    }

    public virtual object NextNode()
    {
      int count = this.Count;
      if (this.dirty || this.cursor >= count && count == 1)
        return this.adaptor.DupNode(this.NextCore());
      object obj = this.NextCore();
      while (this.adaptor.IsNil(obj) && this.adaptor.GetChildCount(obj) == 1)
        obj = this.adaptor.GetChild(obj, 0);
      return this.adaptor.DupNode(obj);
    }

    protected override object Dup(object el)
    {
      return this.adaptor.DupTree(el);
    }
  }
}
