// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.Publizieren
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using de.springwald.gaitobot.publizierung.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren
{
  [GeneratedCode("System.Web.Services", "4.0.30319.33440")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [WebServiceBinding(Name = "PublizierenSoap", Namespace = "de.gaitobot_de.webservices")]
  public class Publizieren : SoapHttpClientProtocol
  {
    private SendOrPostCallback UebertrageAIMLDateiOperationCompleted;
    private SendOrPostCallback ReseteGaitoBotOperationCompleted;
    private SendOrPostCallback ExistsGaitoBotIDOperationCompleted;
    private SendOrPostCallback MaxKBWissenOperationCompleted;
    private SendOrPostCallback AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public Publizieren()
    {
      this.Url = Settings.Default.de_springwald_gaitobot_publizierung_Gaitobot_de_publizieren_Publizieren;
      if (this.IsLocalFileSystemWebService(this.Url))
      {
        this.UseDefaultCredentials = true;
        this.useDefaultCredentialsSetExplicitly = false;
      }
      else
        this.useDefaultCredentialsSetExplicitly = true;
    }

    public new string Url
    {
      get
      {
        return base.Url;
      }
      set
      {
        if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
          base.UseDefaultCredentials = false;
        base.Url = value;
      }
    }

    public new bool UseDefaultCredentials
    {
      get
      {
        return base.UseDefaultCredentials;
      }
      set
      {
        base.UseDefaultCredentials = value;
        this.useDefaultCredentialsSetExplicitly = true;
      }
    }

    public event UebertrageAIMLDateiCompletedEventHandler UebertrageAIMLDateiCompleted;

    public event ReseteGaitoBotCompletedEventHandler ReseteGaitoBotCompleted;

    public event ExistsGaitoBotIDCompletedEventHandler ExistsGaitoBotIDCompleted;

    public event MaxKBWissenCompletedEventHandler MaxKBWissenCompleted;

    public event AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenCompletedEventHandler AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenCompleted;

    [SoapDocumentMethod("de.gaitobot_de.webservices/UebertrageAIMLDatei", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "de.gaitobot_de.webservices", ResponseNamespace = "de.gaitobot_de.webservices", Use = SoapBindingUse.Literal)]
    public void UebertrageAIMLDatei(string gaitoBotEditorID, AIMLDateiUebertragung aimlDateiInhalt)
    {
      this.Invoke(nameof (UebertrageAIMLDatei), new object[2]
      {
        (object) gaitoBotEditorID,
        (object) aimlDateiInhalt
      });
    }

    public void UebertrageAIMLDateiAsync(
      string gaitoBotEditorID,
      AIMLDateiUebertragung aimlDateiInhalt)
    {
      this.UebertrageAIMLDateiAsync(gaitoBotEditorID, aimlDateiInhalt, (object) null);
    }

    public void UebertrageAIMLDateiAsync(
      string gaitoBotEditorID,
      AIMLDateiUebertragung aimlDateiInhalt,
      object userState)
    {
      if (this.UebertrageAIMLDateiOperationCompleted == null)
        this.UebertrageAIMLDateiOperationCompleted = new SendOrPostCallback(this.OnUebertrageAIMLDateiOperationCompleted);
      this.InvokeAsync("UebertrageAIMLDatei", new object[2]
      {
        (object) gaitoBotEditorID,
        (object) aimlDateiInhalt
      }, this.UebertrageAIMLDateiOperationCompleted, userState);
    }

    private void OnUebertrageAIMLDateiOperationCompleted(object arg)
    {
      if (this.UebertrageAIMLDateiCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UebertrageAIMLDateiCompleted((object) this, new AsyncCompletedEventArgs(completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("de.gaitobot_de.webservices/ReseteGaitoBot", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "de.gaitobot_de.webservices", ResponseNamespace = "de.gaitobot_de.webservices", Use = SoapBindingUse.Literal)]
    public void ReseteGaitoBot(string gaitoBotEditorID)
    {
      this.Invoke(nameof (ReseteGaitoBot), new object[1]
      {
        (object) gaitoBotEditorID
      });
    }

    public void ReseteGaitoBotAsync(string gaitoBotEditorID)
    {
      this.ReseteGaitoBotAsync(gaitoBotEditorID, (object) null);
    }

    public void ReseteGaitoBotAsync(string gaitoBotEditorID, object userState)
    {
      if (this.ReseteGaitoBotOperationCompleted == null)
        this.ReseteGaitoBotOperationCompleted = new SendOrPostCallback(this.OnReseteGaitoBotOperationCompleted);
      this.InvokeAsync("ReseteGaitoBot", new object[1]
      {
        (object) gaitoBotEditorID
      }, this.ReseteGaitoBotOperationCompleted, userState);
    }

    private void OnReseteGaitoBotOperationCompleted(object arg)
    {
      if (this.ReseteGaitoBotCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.ReseteGaitoBotCompleted((object) this, new AsyncCompletedEventArgs(completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("de.gaitobot_de.webservices/ExistsGaitoBotID", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "de.gaitobot_de.webservices", ResponseNamespace = "de.gaitobot_de.webservices", Use = SoapBindingUse.Literal)]
    public bool ExistsGaitoBotID(string gaitoBotEditorID)
    {
      return (bool) this.Invoke(nameof (ExistsGaitoBotID), new object[1]
      {
        (object) gaitoBotEditorID
      })[0];
    }

    public void ExistsGaitoBotIDAsync(string gaitoBotEditorID)
    {
      this.ExistsGaitoBotIDAsync(gaitoBotEditorID, (object) null);
    }

    public void ExistsGaitoBotIDAsync(string gaitoBotEditorID, object userState)
    {
      if (this.ExistsGaitoBotIDOperationCompleted == null)
        this.ExistsGaitoBotIDOperationCompleted = new SendOrPostCallback(this.OnExistsGaitoBotIDOperationCompleted);
      this.InvokeAsync("ExistsGaitoBotID", new object[1]
      {
        (object) gaitoBotEditorID
      }, this.ExistsGaitoBotIDOperationCompleted, userState);
    }

    private void OnExistsGaitoBotIDOperationCompleted(object arg)
    {
      if (this.ExistsGaitoBotIDCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.ExistsGaitoBotIDCompleted((object) this, new ExistsGaitoBotIDCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("de.gaitobot_de.webservices/MaxKBWissen", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "de.gaitobot_de.webservices", ResponseNamespace = "de.gaitobot_de.webservices", Use = SoapBindingUse.Literal)]
    public long MaxKBWissen(string gaitoBotEditorID)
    {
      return (long) this.Invoke(nameof (MaxKBWissen), new object[1]
      {
        (object) gaitoBotEditorID
      })[0];
    }

    public void MaxKBWissenAsync(string gaitoBotEditorID)
    {
      this.MaxKBWissenAsync(gaitoBotEditorID, (object) null);
    }

    public void MaxKBWissenAsync(string gaitoBotEditorID, object userState)
    {
      if (this.MaxKBWissenOperationCompleted == null)
        this.MaxKBWissenOperationCompleted = new SendOrPostCallback(this.OnMaxKBWissenOperationCompleted);
      this.InvokeAsync("MaxKBWissen", new object[1]
      {
        (object) gaitoBotEditorID
      }, this.MaxKBWissenOperationCompleted, userState);
    }

    private void OnMaxKBWissenOperationCompleted(object arg)
    {
      if (this.MaxKBWissenCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.MaxKBWissenCompleted((object) this, new MaxKBWissenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("de.gaitobot_de.webservices/AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "de.gaitobot_de.webservices", ResponseNamespace = "de.gaitobot_de.webservices", Use = SoapBindingUse.Literal)]
    public string[] AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben(
      string gaitoBotEditorID,
      DateiPublizierungsInfos[] dateien)
    {
      return (string[]) this.Invoke(nameof (AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben), new object[2]
      {
        (object) gaitoBotEditorID,
        (object) dateien
      })[0];
    }

    public void AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenAsync(
      string gaitoBotEditorID,
      DateiPublizierungsInfos[] dateien)
    {
      this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenAsync(gaitoBotEditorID, dateien, (object) null);
    }

    public void AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenAsync(
      string gaitoBotEditorID,
      DateiPublizierungsInfos[] dateien,
      object userState)
    {
      if (this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted == null)
        this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted = new SendOrPostCallback(this.OnAlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted);
      this.InvokeAsync("AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben", new object[2]
      {
        (object) gaitoBotEditorID,
        (object) dateien
      }, this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted, userState);
    }

    private void OnAlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenOperationCompleted(
      object arg)
    {
      if (this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenCompleted((object) this, new AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGebenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    public new void CancelAsync(object userState)
    {
      base.CancelAsync(userState);
    }

    private bool IsLocalFileSystemWebService(string url)
    {
      if (url == null || url == string.Empty)
        return false;
      Uri uri = new Uri(url);
      return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
    }
  }
}
