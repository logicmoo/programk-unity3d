// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.RewriteRuleTokenStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class RewriteRuleTokenStream : RewriteRuleElementStream
  {
    public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription)
      : base(adaptor, elementDescription)
    {
    }

    public RewriteRuleTokenStream(
      ITreeAdaptor adaptor,
      string elementDescription,
      object oneElement)
      : base(adaptor, elementDescription, oneElement)
    {
    }

    public RewriteRuleTokenStream(ITreeAdaptor adaptor, string elementDescription, IList elements)
      : base(adaptor, elementDescription, elements)
    {
    }

    public virtual object NextNode()
    {
      return this.adaptor.Create((IToken) this.NextCore());
    }

    public virtual IToken NextToken()
    {
      return (IToken) this.NextCore();
    }

    protected override object ToTree(object el)
    {
      return el;
    }

    protected override object Dup(object el)
    {
      throw new NotSupportedException("dup can't be called for a token stream.");
    }
  }
}
