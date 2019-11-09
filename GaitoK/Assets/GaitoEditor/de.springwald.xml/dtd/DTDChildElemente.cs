// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDChildElemente
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Collections;
using System.Text;

namespace de.springwald.xml.dtd
{
    public class DTDChildElemente
    {
        private DTDChildElemente.DTDChildElementArten _art;
        private DTDChildElemente.DTDChildElementAnzahl _defAnzahl;
        private DTDChildElemente.DTDChildElementOperatoren _operator;
        private ArrayList _children;
        private string _elementName;
        private DTD _dtd;
        private string _quellcode;
        private AlleMoeglichenElementeEinesChildblocks _alleMoeglichenElemente;
        private string _regExAusdruck;

        public string RegExAusdruck
        {
            get
            {
                if (this._regExAusdruck == null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("(");
                    switch (this._art)
                    {
                        case DTDChildElemente.DTDChildElementArten.Leer:
                            switch (this._defAnzahl)
                            {
                                case DTDChildElemente.DTDChildElementAnzahl.NullUndMehr:
                                    stringBuilder.Append("*");
                                    goto case DTDChildElemente.DTDChildElementAnzahl.GenauEinmal;
                                case DTDChildElemente.DTDChildElementAnzahl.GenauEinmal:
                                    stringBuilder.Append(")");
                                    this._regExAusdruck = stringBuilder.ToString();
                                    break;
                                case DTDChildElemente.DTDChildElementAnzahl.NullOderEinmal:
                                    stringBuilder.Append("?");
                                    goto case DTDChildElemente.DTDChildElementAnzahl.GenauEinmal;
                                case DTDChildElemente.DTDChildElementAnzahl.EinsUndMehr:
                                    stringBuilder.Append("+");
                                    goto case DTDChildElemente.DTDChildElementAnzahl.GenauEinmal;
                                default:
                                    throw new ApplicationException("Unhandled DTDChildElementAnzahl '" + (object)this._defAnzahl + "'");
                            }
                            return this._regExAusdruck;
                        case DTDChildElemente.DTDChildElementArten.EinzelChild:
                            {
                                if (this._elementName != "#COMMENT")
                                {
                                    stringBuilder.AppendFormat("((-#COMMENT)*-{0}(-#COMMENT)*)", (object)this._elementName);
                                    //fallthru 
                                    goto case DTDChildElemente.DTDChildElementArten.Leer;
                                }
                                else
                                {
                                    stringBuilder.AppendFormat("(-{0})", (object)this._elementName);
                                    goto case DTDChildElemente.DTDChildElementArten.Leer;
                                    //fallthru
                                }
                                goto case DTDChildElemente.DTDChildElementArten.Leer;
                            }
                        case DTDChildElemente.DTDChildElementArten.ChildListe:
                            stringBuilder.Append("(");
                            for (int index = 0; index < this._children.Count; ++index)
                            {
                                if ((uint)index > 0U)
                                {
                                    switch (this._operator)
                                    {
                                        case DTDChildElemente.DTDChildElementOperatoren.Oder:
                                            stringBuilder.Append("|");
                                            goto case DTDChildElemente.DTDChildElementOperatoren.GefolgtVon;
                                        case DTDChildElemente.DTDChildElementOperatoren.GefolgtVon:
                                            break;
                                        default:
                                            throw new ApplicationException("Unhandled DTDChildElementOperatoren '" + (object)this._operator + "'");
                                    }
                                }
                                stringBuilder.Append(((DTDChildElemente)this._children[index]).RegExAusdruck);
                            }
                            stringBuilder.Append(")");
                            goto case DTDChildElemente.DTDChildElementArten.Leer;
                        default:
                            throw new ApplicationException("Unhandled DTDChildElementArt '" + (object)this._art + "'");
                    }
                }
                return this._regExAusdruck;
            }
        }

        public AlleMoeglichenElementeEinesChildblocks AlleMoeglichenElemente
        {
            get
            {
                if (this._alleMoeglichenElemente == null)
                    this._alleMoeglichenElemente = new AlleMoeglichenElementeEinesChildblocks(this);
                return this._alleMoeglichenElemente;
            }
        }

        public string Quellcode
        {
            get
            {
                return this._quellcode;
            }
        }

        public DTDChildElemente.DTDChildElementArten Art
        {
            get
            {
                return this._art;
            }
        }

        public DTDChildElemente.DTDChildElementAnzahl DefAnzahl
        {
            get
            {
                return this._defAnzahl;
            }
        }

        public DTDChildElemente.DTDChildElementOperatoren Operator
        {
            get
            {
                return this._operator;
            }
        }

        public int AnzahlChildren
        {
            get
            {
                return this._children.Count;
            }
        }

        public string ElementName
        {
            get
            {
                return this._elementName;
            }
        }

        public DTDChildElemente(string childrenQuellcode)
        {
            this._art = DTDChildElemente.DTDChildElementArten.Leer;
            this._children = new ArrayList();
            this._defAnzahl = DTDChildElemente.DTDChildElementAnzahl.GenauEinmal;
            this._elementName = "";
            this._operator = DTDChildElemente.DTDChildElementOperatoren.Oder;
            this._quellcode = childrenQuellcode;
            this._quellcode = this._quellcode.Replace("\t", " ");
            this._quellcode = this._quellcode.Replace("\r\n", " ");
            this._quellcode = this._quellcode.Trim();
            if (this._quellcode.Length == 0)
                this._art = DTDChildElemente.DTDChildElementArten.Leer;
            else
                this.CodeAuslesen();
        }

        protected DTDChildElemente()
        {
        }

        public DTDChildElemente Clone()
        {
            return new DTDChildElemente() { _alleMoeglichenElemente = (AlleMoeglichenElementeEinesChildblocks)null, _art = this._art, _operator = this._operator, _defAnzahl = this._defAnzahl, _children = (ArrayList)this._children.Clone(), _dtd = this._dtd, _elementName = this._elementName, _quellcode = this._quellcode + "(geklont)" };
        }

        public void DTDZuweisen(DTD dtd)
        {
            foreach (DTDChildElemente child in this._children)
                child.DTDZuweisen(dtd);
            this._dtd = dtd;
        }

        public bool AnzahlZulaessig(int anzahl)
        {
            switch (this._defAnzahl)
            {
                case DTDChildElemente.DTDChildElementAnzahl.NullUndMehr:
                    return anzahl >= 0;
                case DTDChildElemente.DTDChildElementAnzahl.GenauEinmal:
                    return anzahl == 1;
                case DTDChildElemente.DTDChildElementAnzahl.NullOderEinmal:
                    return anzahl == 0 || anzahl == 1;
                case DTDChildElemente.DTDChildElementAnzahl.EinsUndMehr:
                    return anzahl >= 1;
                default:
                    throw new ApplicationException(string.Format(ResReader.Reader.GetString("UnbekannteDTDChildElementAnzahl"), (object)this._art));
            }
        }

        public DTDChildElemente Child(int index)
        {
            return (DTDChildElemente)this._children[index];
        }

        private void CodeAuslesen()
        {
            string str1 = this._quellcode;
            string str2 = str1.Substring(str1.Length - 1, 1);
            if (!(str2 == "+"))
            {
                if (!(str2 == "*"))
                {
                    if (str2 == "?")
                    {
                        this._defAnzahl = DTDChildElemente.DTDChildElementAnzahl.NullOderEinmal;
                        str1 = str1.Remove(str1.Length - 1, 1);
                    }
                    else
                        this._defAnzahl = DTDChildElemente.DTDChildElementAnzahl.GenauEinmal;
                }
                else
                {
                    this._defAnzahl = DTDChildElemente.DTDChildElementAnzahl.NullUndMehr;
                    str1 = str1.Remove(str1.Length - 1, 1);
                }
            }
            else
            {
                this._defAnzahl = DTDChildElemente.DTDChildElementAnzahl.EinsUndMehr;
                str1 = str1.Remove(str1.Length - 1, 1);
            }
            string str3 = str1.Trim();
            if (str3.Substring(0, 1) == "(" && str3.Substring(str3.Length - 1, 1) == ")")
            {
                this.ChildrenAuslesen(str3.Substring(1, str3.Length - 2));
            }
            else
            {
                this._art = DTDChildElemente.DTDChildElementArten.EinzelChild;
                this._elementName = str3;
            }
        }

        private void ChildrenAuslesen(string code)
        {
            string str1 = code;
            this._art = DTDChildElemente.DTDChildElementArten.ChildListe;
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            while (code.Length > 0)
            {
                string code1 = code.Substring(0, 1);
                code = code.Remove(0, 1);
                string str2 = code1;
                if (!(str2 == "("))
                {
                    if (str2 == ")")
                        --num;
                }
                else
                    ++num;
                if (this.IstOperator(code1))
                {
                    if (num == 0)
                    {
                        this._operator = this.GetOperatorFromChar(code1);
                        string code2 = stringBuilder.ToString().Trim();
                        if (code2.Length == 0)
                            throw new ApplicationException("Leerer ChildCode gefunden in '" + str1 + "'");
                        this.SpeichereChildElement(code2);
                        stringBuilder = new StringBuilder();
                    }
                    else
                        stringBuilder.Append(code1);
                }
                else
                    stringBuilder.Append(code1);
            }
            if (stringBuilder.Length <= 0)
                return;
            this.SpeichereChildElement(stringBuilder.ToString());
        }

        private void SpeichereChildElement(string code)
        {
            code = code.Trim();
            this._children.Add((object)new DTDChildElemente(code));
        }

        private bool IstOperator(string code)
        {
            string str = code;
            return str == "|" || str == ",";
        }

        private DTDChildElemente.DTDChildElementOperatoren GetOperatorFromChar(
          string code)
        {
            string str = code;
            if (str == "|")
                return DTDChildElemente.DTDChildElementOperatoren.Oder;
            if (str == ",")
                return DTDChildElemente.DTDChildElementOperatoren.GefolgtVon;
            throw new ApplicationException(string.Format(ResReader.Reader.GetString("StringIstKeinOperator"), (object)code));
        }

        public enum DTDChildElementArten
        {
            EinzelChild = -1, // 0xFFFFFFFF
            Leer = 0,
            ChildListe = 2,
        }

        public enum DTDChildElementAnzahl
        {
            NullUndMehr = -1, // 0xFFFFFFFF
            GenauEinmal = 0,
            NullOderEinmal = 2,
            EinsUndMehr = 3,
        }

        public enum DTDChildElementOperatoren
        {
            Oder = -1, // 0xFFFFFFFF
            GefolgtVon = 0,
        }
    }
}
