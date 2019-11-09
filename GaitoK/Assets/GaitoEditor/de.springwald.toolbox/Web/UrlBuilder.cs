// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Web.UrlBuilder
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using de.springwald.toolbox.Text;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;

namespace de.springwald.toolbox.Web
{
  public class UrlBuilder : UriBuilder
  {
    private StringDictionary _queryString = (StringDictionary) null;

    public StringDictionary QueryString
    {
      get
      {
        if (this._queryString == null)
          this._queryString = new StringDictionary();
        return this._queryString;
      }
    }

    public string PageName
    {
      get
      {
        string path = this.Path;
        return path.Substring(path.LastIndexOf("/") + 1);
      }
      set
      {
        string path = this.Path;
        this.Path = path.Substring(0, path.LastIndexOf("/")) + "/" + value;
      }
    }

    public UrlBuilder()
    {
    }

    public UrlBuilder(string uri)
      : base(uri)
    {
      this.PopulateQueryString();
    }

    public UrlBuilder(Uri uri)
      : base(uri)
    {
      this.PopulateQueryString();
    }

    public UrlBuilder(string schemeName, string hostName)
      : base(schemeName, hostName)
    {
    }

    public UrlBuilder(string scheme, string host, int portNumber)
      : base(scheme, host, portNumber)
    {
    }

    public UrlBuilder(string scheme, string host, int port, string pathValue)
      : base(scheme, host, port, pathValue)
    {
    }

    public UrlBuilder(string scheme, string host, int port, string path, string extraValue)
      : base(scheme, host, port, path, extraValue)
    {
    }

    public UrlBuilder(Page page)
      : base(page.Request.Url.AbsoluteUri)
    {
      this.PopulateQueryString();
    }

    public void SetzeParameterEncodedEin(string name, string inhalt)
    {
      if (string.IsNullOrEmpty(inhalt))
        this.QueryString.Remove(name);
      else
        this.QueryString[name] = EncodingTools.UrlISO885915Encode(inhalt);
    }

    public new string ToString()
    {
      this.GetQueryString();
      return this.Uri.AbsoluteUri;
    }

    public void Navigate()
    {
      this._Navigate(true);
    }

    public void Navigate(bool endResponse)
    {
      this._Navigate(endResponse);
    }

    private void _Navigate(bool endResponse)
    {
      HttpContext.Current.Response.Redirect(this.ToString(), endResponse);
    }

    private void PopulateQueryString()
    {
      string query = this.Query;
      if (string.IsNullOrEmpty(query))
        return;
      if (this._queryString == null)
        this._queryString = new StringDictionary();
      this._queryString.Clear();
      string str1 = query.Substring(1);
      char[] chArray1 = new char[1]{ '&' };
      foreach (string str2 in str1.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ '=' };
        string[] strArray = str2.Split(chArray2);
        this._queryString[strArray[0]] = strArray.Length > 1 ? strArray[1] : string.Empty;
      }
    }

    private void GetQueryString()
    {
      int count = this.QueryString.Count;
      if (count == 0)
      {
        this.Query = string.Empty;
      }
      else
      {
        string[] strArray1 = new string[count];
        string[] strArray2 = new string[count];
        string[] strArray3 = new string[count];
        this._queryString.Keys.CopyTo((Array) strArray1, 0);
        this._queryString.Values.CopyTo((Array) strArray2, 0);
        for (int index = 0; index < count; ++index)
          strArray3[index] = strArray1[index] + "=" + strArray2[index];
        this.Query = string.Join("&", strArray3);
      }
    }
  }
}
