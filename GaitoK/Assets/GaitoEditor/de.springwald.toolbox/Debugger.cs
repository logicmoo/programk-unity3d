// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Debugger
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace de.springwald.toolbox
{
   
  public class Debugger
  {
        static public bool WORKAROUND = true;
        private const string _linie = "---------------------------------------------------------";
    private string _protokollDateiname;
    private StreamWriter _protokollWriter;
    private static Debugger _globalDebugger;

    public event DebuggerNeueZeileEventHandler NeueProtokollZeileEvent;

    protected virtual void NeueProtokollZeile(DebuggerNeueZeileEventArgs e)
    {
      if (this.NeueProtokollZeileEvent == null)
        return;
      this.NeueProtokollZeileEvent((object) this, e);
    }

    public void SetzeProtokollDateiname(string dateiname, bool fehlerAnzeigen)
    {
      if (this._protokollDateiname != null)
      {
        if (!fehlerAnzeigen)
          return;
        this.FehlerZeigen(string.Format("Es wurde bereits die Protokolldateiname '{0}' zugewiesen", (object) this._protokollDateiname), (object) nameof (Debugger), "set ProtokollDateiname");
      }
      else
      {
        this._protokollDateiname = dateiname;
        if (File.Exists(this._protokollDateiname))
        {
          try
          {
            File.Delete(this._protokollDateiname);
          }
          catch (Exception ex)
          {
            if (fehlerAnzeigen)
              this.FehlerZeigen(string.Format("Konnte Protokolldatei '{0}' nicht löschen: \n\n{1}", (object) this._protokollDateiname, (object) ex), (object) nameof (Debugger), "set ProtokollDateiname");
          }
        }
        try
        {
          this._protokollWriter = new StreamWriter(this._protokollDateiname, false, Encoding.GetEncoding("ISO-8859-15"));
          this._protokollWriter.AutoFlush = true;
        }
        catch (Exception ex)
        {
          if (!fehlerAnzeigen)
            return;
          this.FehlerZeigen(string.Format("Konnte Protokolldatei '{0}' nicht anlegen: \n\n{1}", (object) this._protokollDateiname, (object) ex), (object) nameof (Debugger), "set ProtokollDateiname");
          this._protokollDateiname = (string) null;
          this._protokollWriter = (StreamWriter) null;
          return;
        }
        this.SchreibeZeile("---------------------------------------------------------");
        this.SchreibeZeile(string.Format("Protokollstart: {0}", (object) DateTime.Now));
        this.SchreibeZeile("---------------------------------------------------------");
      }
    }

    public string ProtokollDateiname
    {
      get
      {
        return this._protokollDateiname;
      }
    }

    public void Protokolliere(string Meldung)
    {
      this.Protokolliere(Meldung, Debugger.ProtokollTypen.TechnischerVorgang);
    }

    public void Protokolliere(string meldung, Debugger.ProtokollTypen meldungsTyp)
    {
      switch (meldungsTyp)
      {
        case Debugger.ProtokollTypen.BenutzerHandlung:
          this.SchreibeZeile(string.Format("USER> {0}", (object) meldung));
          break;
        case Debugger.ProtokollTypen.TechnischerVorgang:
          this.SchreibeZeile(string.Format("   ... {0}", (object) meldung));
          break;
        case Debugger.ProtokollTypen.TechnischerMilestone:
          this.SchreibeZeile(string.Format(">>> {0}", (object) meldung));
          break;
        case Debugger.ProtokollTypen.Fehlermeldung:
          this.SchreibeZeile("---------------------------------------------------------");
          this.SchreibeZeile(string.Format("ERROR: {0}", (object) meldung));
          this.SchreibeZeile("---------------------------------------------------------");
          break;
        default:
          this.SchreibeZeile(string.Format("? ... {0}", (object) meldung));
          break;
      }
    }

    public void FehlerZeigen(
      string fehlermeldung,
      object woAufgetretenObjekt,
      string woAufgetretenKontext)
    {
      this.Protokolliere(string.Format("{0}\n({1}->{2})", (object) fehlermeldung, woAufgetretenObjekt, (object) woAufgetretenKontext), Debugger.ProtokollTypen.Fehlermeldung);
      int num = (int) MessageBox.Show(fehlermeldung, woAufgetretenObjekt.ToString() + "->" + woAufgetretenKontext);
    }

    public void ProtokollDateiSchliessen()
    {
      if (this._protokollWriter == null)
        return;
      this._protokollWriter.Close();
    }

    public static Debugger GlobalDebugger
    {
      get
      {
        if (Debugger._globalDebugger == null)
          Debugger._globalDebugger = new Debugger();
        return Debugger._globalDebugger;
      }
    }

        private void SchreibeZeile(string inhalt)
        {
            if (this._protokollWriter != null)
            {
                try
                {
                    this._protokollWriter.WriteLine(inhalt);
                    this._protokollWriter.Flush();
                }
                catch (Exception e)
                {
                    string s = e.StackTrace;
                        }
            
            }
            // try
            {
                this.NeueProtokollZeile(new DebuggerNeueZeileEventArgs(inhalt));
            }
            // catch (Exception) { }
        }

    public enum ProtokollTypen
    {
      BenutzerHandlung = 1,
      TechnischerVorgang = 2,
      TechnischerMilestone = 3,
      Fehlermeldung = 4,
    }
  }
}
