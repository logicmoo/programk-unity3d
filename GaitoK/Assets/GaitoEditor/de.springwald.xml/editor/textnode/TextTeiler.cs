// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.textnode.TextTeiler
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace de.springwald.xml.editor.textnode
{
  public class TextTeiler
  {
    private List<TextTeil> _textTeile;

    private char[] _zeichenZumUmbrechen { get; set; }

    public List<TextTeil> TextTeile
    {
      get
      {
        return this._textTeile;
      }
    }

    public TextTeiler(
      string text,
      int invertiertStart,
      int invertiertLaenge,
      int maxLaengeProZeile,
      int bereitsLaengeDerZeile,
      char[] zeichenZumUmbrechen)
    {
      this._zeichenZumUmbrechen = zeichenZumUmbrechen;
      this._textTeile = this.TextTeileGgfInvertieren(this.TextUmbrechenUndAufTeileVerteilen(text, bereitsLaengeDerZeile, maxLaengeProZeile), invertiertStart, invertiertLaenge);
    }

    private List<TextTeil> TextTeileGgfInvertieren(
      List<TextTeil> rohTeile,
      int invertiertStart,
      int invertiertLaenge)
    {
      if (invertiertLaenge == 0)
        return rohTeile;
      List<TextTeil> textTeilList = new List<TextTeil>();
      int num1 = 0;
      foreach (TextTeil textTeil1 in rohTeile)
      {
        bool flag1 = textTeil1.IstNeueZeile;
        if (invertiertStart > num1 + textTeil1.Text.Length)
        {
          textTeil1.Invertiert = false;
          textTeilList.Add(textTeil1);
        }
        else if (invertiertStart + invertiertLaenge < num1)
        {
          textTeilList.Add(textTeil1);
        }
        else
        {
          int num2 = Math.Max(Math.Min(invertiertLaenge + invertiertStart - num1, textTeil1.Text.Length), 0);
          int num3 = 0;
          if (invertiertStart > num1)
          {
            TextTeil textTeil2 = new TextTeil();
            textTeil2.Invertiert = false;
            num3 = invertiertStart - num1;
            textTeil2.Text = textTeil1.Text.Substring(0, num3);
            textTeil2.IstNeueZeile = flag1;
            flag1 = false;
            textTeilList.Add(textTeil2);
            num2 -= num3;
          }
          int length1 = num2;
          TextTeil textTeil3 = new TextTeil();
          textTeil3.Invertiert = true;
          textTeil3.Text = textTeil1.Text.Substring(num3, length1);
          textTeil3.IstNeueZeile = flag1;
          bool flag2 = false;
          textTeilList.Add(textTeil3);
          int length2 = textTeil1.Text.Length - (num3 + length1);
          if (length2 > 0)
            textTeilList.Add(new TextTeil()
            {
              Invertiert = false,
              Text = textTeil1.Text.Substring(textTeil1.Text.Length - length2, length2),
              IstNeueZeile = flag2
            });
        }
        num1 += textTeil1.Text.Length;
      }
      return textTeilList;
    }

    private List<TextTeil> TextUmbrechenUndAufTeileVerteilen(
      string text,
      int laengeAktZeile,
      int maxLaengeProZeile)
    {
      if (this._zeichenZumUmbrechen == null)
        return this.TextAufTextTeileVerteilen(text, laengeAktZeile, maxLaengeProZeile);
      char ch1 = '·';
      foreach (char ch2 in this._zeichenZumUmbrechen)
        text = text.Replace(ch2.ToString(), string.Format("{0}{1}", (object) ch2, (object) ch1));
      bool flag = true;
      List<TextTeil> textTeilList1 = new List<TextTeil>();
      string str = text;
      char[] separator = new char[1]{ ch1 };
      foreach (string text1 in str.Split(separator, StringSplitOptions.RemoveEmptyEntries))
      {
        List<TextTeil> textTeilList2 = this.TextAufTextTeileVerteilen(text1, laengeAktZeile, maxLaengeProZeile);
        TextTeil textTeil1 = (TextTeil) null;
        foreach (TextTeil textTeil2 in textTeilList2)
        {
          textTeil1 = textTeil2;
          textTeilList1.Add(textTeil2);
        }
        if (textTeil1 != null)
        {
          if (flag)
            flag = false;
          else
            textTeil1.IstNeueZeile = true;
        }
      }
      return textTeilList1;
    }

    private List<TextTeil> TextAufTextTeileVerteilen(
      string text,
      int laengeAktZeile,
      int maxLaengeProZeile)
    {
      List<TextTeil> textTeilList = new List<TextTeil>();
      StringBuilder stringBuilder = new StringBuilder();
      bool flag = false;
      int startIndex = 0;
      int num1 = text.IndexOf(' ', 0);
      while (startIndex < text.Length)
      {
        if (num1 == -1)
        {
          string str = text.Substring(startIndex, text.Length - startIndex);
          stringBuilder.Append(str);
          laengeAktZeile += str.Length;
          startIndex = text.Length;
        }
        else
        {
          int num2 = num1 + 1;
          string str = text.Substring(startIndex, num2 - startIndex);
          if (maxLaengeProZeile - laengeAktZeile <= str.Length)
          {
            if (startIndex == 0)
            {
              stringBuilder.Append(str);
              textTeilList.Add(new TextTeil()
              {
                Text = stringBuilder.ToString(),
                IstNeueZeile = flag,
                Invertiert = false
              });
              stringBuilder = new StringBuilder();
              flag = true;
              laengeAktZeile = 0;
            }
            else
            {
              textTeilList.Add(new TextTeil()
              {
                Text = stringBuilder.ToString(),
                IstNeueZeile = flag,
                Invertiert = false
              });
              stringBuilder = new StringBuilder();
              stringBuilder.Append(str);
              flag = true;
              laengeAktZeile = str.Length;
            }
          }
          else
          {
            stringBuilder.Append(str);
            laengeAktZeile += str.Length;
          }
          startIndex = num2;
          num1 = text.IndexOf(' ', startIndex);
        }
      }
      if ((uint) stringBuilder.Length > 0U)
        textTeilList.Add(new TextTeil()
        {
          Text = stringBuilder.ToString(),
          IstNeueZeile = flag,
          Invertiert = false
        });
      return textTeilList;
    }
  }
}
