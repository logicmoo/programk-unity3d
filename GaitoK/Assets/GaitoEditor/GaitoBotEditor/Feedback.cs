// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.Feedback
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using GaitoBotEditorCore;
using MultiLang;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class Feedback : UserControl
  {
    private IContainer components = (IContainer) null;
    private frmFeedback _feedbackFormular;
    private LinkLabel FeedbackGebenLinkLabel;
    private Label labelTitelFeedback;

    public Feedback()
    {
      this.InitializeComponent();
      this.FeedbackBoxFuellen();
    }

    private void FeedbackBoxFuellen()
    {
      this.FeedbackGebenLinkLabel.Text = string.Format(ml.ml_string(47, "Teilen Sie uns Ihre Meinung, Verbesserungsvorschläge und mögliche Fehler in {0} mit."), (object) Application.ProductName);
    }

    private void FeedbackGebenLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (this._feedbackFormular != null)
      {
        if (!this._feedbackFormular.Visible)
        {
          this._feedbackFormular.Dispose();
          this._feedbackFormular = (frmFeedback) null;
        }
        else
        {
          this._feedbackFormular.Show();
          this._feedbackFormular.BringToFront();
        }
      }
      if (this._feedbackFormular != null)
        return;
      this._feedbackFormular = new frmFeedback();
      this._feedbackFormular.ZeigeFeedbackFormular(Config.GlobalConfig.FeedbackEmailAdresse, Config.GlobalConfig.FeedbackWebScriptURL);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Feedback));
      this.FeedbackGebenLinkLabel = new LinkLabel();
      this.labelTitelFeedback = new Label();
      this.SuspendLayout();
      this.FeedbackGebenLinkLabel.ActiveLinkColor = Color.Blue;
      componentResourceManager.ApplyResources((object) this.FeedbackGebenLinkLabel, "FeedbackGebenLinkLabel");
      this.FeedbackGebenLinkLabel.BackColor = Color.White;
      this.FeedbackGebenLinkLabel.LinkBehavior = LinkBehavior.NeverUnderline;
      this.FeedbackGebenLinkLabel.LinkColor = Color.Black;
      this.FeedbackGebenLinkLabel.Name = "FeedbackGebenLinkLabel";
      this.FeedbackGebenLinkLabel.TabStop = true;
      this.FeedbackGebenLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.FeedbackGebenLinkLabel_LinkClicked);
      componentResourceManager.ApplyResources((object) this.labelTitelFeedback, "labelTitelFeedback");
      this.labelTitelFeedback.BackColor = Color.WhiteSmoke;
      this.labelTitelFeedback.Name = "labelTitelFeedback";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.labelTitelFeedback);
      this.Controls.Add((Control) this.FeedbackGebenLinkLabel);
      this.Name = nameof (Feedback);
      this.ResumeLayout(false);
    }
  }
}
