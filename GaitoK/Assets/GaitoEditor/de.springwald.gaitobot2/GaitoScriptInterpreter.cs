// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.GaitoScriptInterpreter
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using Jint;
using System;

namespace de.springwald.gaitobot2
{
  public class GaitoScriptInterpreter : IDisposable
  {
    private string _fehler = (string) null;
    private JintEngine _engine;
    private GaitoBotSession _gaitoBotSession;
    private object _ausgabe;

    private static void Hu(double was)
    {
      Console.WriteLine(was);
    }

    private static void Ha(bool was)
    {
      Console.WriteLine(was);
    }

    public string Ausgabe
    {
      get
      {
        return this._ausgabe == null ? (string) null : this._ausgabe.ToString();
      }
    }

    public string Fehler
    {
      get
      {
        return this._fehler;
      }
    }

    public GaitoScriptInterpreter(GaitoBotSession gaitoBotSession)
    {
      this._gaitoBotSession = gaitoBotSession;
      this.Initialisieren();
    }

    private void Test()
    {
      this._gaitoBotSession.UserEigenschaften.Lesen("test");
      this._gaitoBotSession.UserEigenschaften.Setzen("test", "wert");
    }

    public void Execute(string scriptInhalt)
    {
      this._ausgabe = (object) null;
      try
      {
        this._ausgabe = this._engine.Run(scriptInhalt);
      }
      catch (Exception ex)
      {
        this._fehler = ex.Message;
      }
    }

    private void Initialisieren()
    {
      this._engine = new JintEngine();
      this._engine.SetMaxRecursions(10);
      this._engine.EnableSecurity();
      this._engine.AllowClr = false;
    }

    public void Dispose()
    {
      this._engine = (JintEngine) null;
    }
  }
}
