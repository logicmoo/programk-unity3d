// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.programm
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using GaitoBotEditorCore;
using MultiLang;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  internal class programm
  {
    [STAThread]
    private static void Main()
    {
      if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
      {
        int num = (int) MessageBox.Show(ml.ml_string(51, "Das Programm wird bereits ausgeführt."));
      }
      else
      {
        Application.ThreadException += new ThreadExceptionEventHandler(programm.Application_ThreadException);
        if (Config.GlobalConfig.ProgrammSprache == "")
        {
          SpracheAuswaehlen spracheAuswaehlen = new SpracheAuswaehlen();
          Application.DoEvents();
          spracheAuswaehlen.Show();
          try
          {
            while (!spracheAuswaehlen.Visible)
              Application.DoEvents();
          }
          catch (Exception ex)
          {
          }
          Application.DoEvents();
          try
          {
            while (spracheAuswaehlen != null && spracheAuswaehlen.Visible)
              Application.DoEvents();
          }
          catch (Exception ex)
          {
          }
        }
        try
        {
          Application.Run((Form) new frmMain());
        }
        catch (Exception ex)
        {
          programm.ZeigeFehler(ex);
        }
      }
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      programm.ZeigeFehler(e.Exception);
      Application.Exit();
    }

    private static void ZeigeFehler(Exception e)
    {
      frmFehlerReport frmFehlerReport = new frmFehlerReport();
      frmFehlerReport.ZeigeFehler(e, "", Config.GlobalConfig.SupportEmailAdresse, Config.GlobalConfig.SupportWebScriptURL);
      Application.DoEvents();
      while (frmFehlerReport.Visible)
        Application.DoEvents();
      frmFehlerReport.Dispose();
    }
  }
}
