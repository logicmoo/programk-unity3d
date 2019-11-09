// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.frmInput
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.toolbox
{
  internal class frmInput : Form
  {
    private Container components = (Container) null;
    private TextBox txtResult;
    private Label lblPrompt;
    private Button btnOk;
    private Button btnCancel;

    private void InitializeComponent()
    {
      this.txtResult = new TextBox();
      this.lblPrompt = new Label();
      this.btnOk = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.txtResult.Location = new Point(16, 44);
      this.txtResult.Name = "txtResult";
      this.txtResult.Size = new Size(376, 20);
      this.txtResult.TabIndex = 0;
      this.lblPrompt.AutoSize = true;
      this.lblPrompt.FlatStyle = FlatStyle.System;
      this.lblPrompt.Location = new Point(16, 20);
      this.lblPrompt.Name = "lblPrompt";
      this.lblPrompt.Size = new Size(49, 13);
      this.lblPrompt.TabIndex = 1;
      this.lblPrompt.Text = "Eingabe:";
      this.btnOk.DialogResult = DialogResult.OK;
      this.btnOk.FlatStyle = FlatStyle.System;
      this.btnOk.Location = new Point(320, 84);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 23);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "OK";
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.FlatStyle = FlatStyle.System;
      this.btnCancel.Location = new Point(236, 84);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Abbruch";
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(413, (int) sbyte.MaxValue);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOk);
      this.Controls.Add((Control) this.lblPrompt);
      this.Controls.Add((Control) this.txtResult);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmInput";
      this.Text = "Eingabe";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public string Response
    {
      get
      {
        return this.txtResult.Text;
      }
      set
      {
        this.txtResult.Text = value;
      }
    }

    public frmInput(string prompt, string header, string defaultResponse)
    {
      this.InitializeComponent();
      this.SteuerElementeBeschriften();
      if (prompt != null)
        this.lblPrompt.Text = prompt;
      if (header != null)
        this.Text = header;
      if (defaultResponse == null)
        return;
      this.txtResult.Text = defaultResponse;
    }

    private void SteuerElementeBeschriften()
    {
      this.Text = ResReader.Reader.GetString("InputBoxText");
      this.lblPrompt.Text = ResReader.Reader.GetString("InputBoxPrompt");
      this.btnCancel.Text = ResReader.Reader.GetString("InputBoxCancel");
      this.btnOk.Text = ResReader.Reader.GetString("InputBoxOk");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }
  }
}
