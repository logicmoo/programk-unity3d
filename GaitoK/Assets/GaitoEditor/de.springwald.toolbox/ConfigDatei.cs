// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ConfigDatei
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.toolbox
{
  public abstract class ConfigDatei
  {
    private string _dateiname;
    private XmlDocument _xml;
    private XmlNode _werteRoot;
    private XmlNode _appRoot;

    public ConfigDatei(string dateiname)
    {
      this._dateiname = dateiname;
      this.Laden();
    }

    protected string VerzeichnisNameAufbereitet(string rohVerzeichnisName)
    {
      StringBuilder stringBuilder = new StringBuilder(rohVerzeichnisName);
      stringBuilder.Replace("[MyDocuments]", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
      stringBuilder.Replace("[DesktopDirectory]", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
      stringBuilder.Replace("[LocalApplicationData]", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
      stringBuilder.Replace("[MyComputer]", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
      stringBuilder.Replace("[ProgramFiles]", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
      stringBuilder.Replace("[Programs]", Environment.GetFolderPath(Environment.SpecialFolder.Programs));
      stringBuilder.Replace("[Templates]", Environment.GetFolderPath(Environment.SpecialFolder.Templates));
      stringBuilder.Replace("[StartupPath]", Application.StartupPath);
      return stringBuilder.ToString();
    }

    protected string getWert(string name)
    {
      return this._werteRoot.SelectSingleNode(name)?.InnerText;
    }

    protected string getWert(string name, string defaultWert)
    {
      XmlNode xmlNode = this._werteRoot.SelectSingleNode(name);
      if (xmlNode != null)
        return xmlNode.InnerText;
      this.setWert(name, defaultWert);
      return defaultWert;
    }

    protected bool getWert(string name, bool defaultWert)
    {
      XmlNode xmlNode = this._werteRoot.SelectSingleNode(name);
      if (xmlNode != null)
        return xmlNode.InnerText == "true";
      this.setWert(name, defaultWert);
      return defaultWert;
    }

    protected string getAppWert(string name)
    {
      return this._appRoot.SelectSingleNode(name)?.InnerText;
    }

    protected void setWert(string name, string wert)
    {
      XmlNode newChild = this._werteRoot.SelectSingleNode(name);
      if (newChild == null)
      {
        newChild = (XmlNode) this._xml.CreateElement(name);
        this._werteRoot.AppendChild(newChild);
      }
      newChild.InnerText = wert;
      this.Speichern();
    }

    protected void setWert(string name, bool wert)
    {
      XmlNode newChild = this._werteRoot.SelectSingleNode(name);
      if (newChild == null)
      {
        newChild = (XmlNode) this._xml.CreateElement(name);
        this._werteRoot.AppendChild(newChild);
      }
      newChild.InnerText = !wert ? "false" : "true";
      this.Speichern();
    }

    private void setAppWert(string name, string wert)
    {
      XmlNode newChild = this._appRoot.SelectSingleNode(name);
      if (newChild == null)
      {
        newChild = (XmlNode) this._xml.CreateElement(name);
        this._appRoot.AppendChild(newChild);
      }
      newChild.InnerText = wert;
    }

    private void Laden()
    {
      this._xml = new XmlDocument();
      if (File.Exists(this._dateiname))
      {
        this._xml.Load(this._dateiname);
        this._werteRoot = this._xml.DocumentElement.SelectSingleNode("content");
        this._appRoot = this._xml.DocumentElement.SelectSingleNode("file");
      }
      else
      {
        XmlNode element = (XmlNode) this._xml.CreateElement("config");
        this._xml.AppendChild(element);
        this._appRoot = (XmlNode) this._xml.CreateElement("file");
        element.AppendChild(this._appRoot);
        this._werteRoot = (XmlNode) this._xml.CreateElement("content");
        element.AppendChild(this._werteRoot);
      }
    }

    private void Speichern()
    {
      this.setAppWert("app_name", Application.ProductName);
      this.setAppWert("app_version", Application.ProductVersion.ToString());
      this.setAppWert("app_major", new Version(Application.ProductVersion).Major.ToString());
      this.setAppWert("app_minor", new Version(Application.ProductVersion).Minor.ToString());
      this.setAppWert("app_revision", new Version(Application.ProductVersion).Revision.ToString());
      this.setAppWert("app_build", new Version(Application.ProductVersion).Build.ToString());
      DateTime now;
      if (this.getAppWert("file_created") == null)
      {
        now = DateTime.Now;
        this.setAppWert("file_created", now.ToString());
      }
      now = DateTime.Now;
      this.setAppWert("file_lastsaved", now.ToString());
      this.setAppWert("system_os", Environment.OSVersion.VersionString);
      this.setAppWert("system_user", Environment.UserName);
      this._xml.Save(this._dateiname);
    }
  }
}
