// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.content.ContentManager
// Assembly: de.springwald.gaitobot.content, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6ABB4B8A-B628-46F2-B20D-382FD07DEF81
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.content.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.springwald.gaitobot.content
{
  public class ContentManager
  {
    private ContentElementInfo[] _infos;

    public ContentElementInfo[] EnthalteneContentElementInfos
    {
      get
      {
        if (this._infos == null)
        {
          string str1 = "de.springwald.gaitobot.content.content.";
          string str2 = ".info";
          List<ContentElementInfo> source = new List<ContentElementInfo>();
          Assembly executingAssembly = Assembly.GetExecutingAssembly();
          foreach (string manifestResourceName in executingAssembly.GetManifestResourceNames())
          {
            if (manifestResourceName.StartsWith(str1) && manifestResourceName.EndsWith(str2))
            {
              StreamReader streamReader = new StreamReader(executingAssembly.GetManifestResourceStream(manifestResourceName), Encoding.GetEncoding("ISO-8859-15"));
              ContentElementInfo contentElementInfo = ContentElementInfo.ReadFromXmlString(streamReader.ReadToEnd());
              streamReader.Close();
              source.Add(contentElementInfo);
            }
          }
          this._infos = source.OrderBy<ContentElementInfo, string>((Func<ContentElementInfo, string>) (b => b.SortKey)).ToArray<ContentElementInfo>();
        }
        return this._infos;
      }
    }

    public List<ContentDokument> GetDokumente(string uniqueId)
    {
      List<ContentDokument> contentDokumentList = new List<ContentDokument>();
      ContentElementInfo contentElementInfo = ((IEnumerable<ContentElementInfo>) this.EnthalteneContentElementInfos).Where<ContentElementInfo>((Func<ContentElementInfo, bool>) (i => i.UniqueKey == uniqueId)).FirstOrDefault<ContentElementInfo>();
      if (contentElementInfo == null)
        throw new ApplicationException(string.Format("Contentdokument mit unique-ID '{0}' nicht vorhanden!", (object) uniqueId));
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      foreach (string manifestResourceName in executingAssembly.GetManifestResourceNames())
      {
        if (!manifestResourceName.EndsWith(".info"))
        {
          string[] strArray1 = manifestResourceName.Split(new char[1]
          {
            '.'
          }, StringSplitOptions.RemoveEmptyEntries);
          string str1 = strArray1[strArray1.Length - 2];
          string str2 = strArray1[strArray1.Length - 1];
          bool flag;
          if (contentElementInfo.DateiPattern.EndsWith("*"))
          {
            string lower = contentElementInfo.DateiPattern.Substring(0, contentElementInfo.DateiPattern.Length - 1).ToLower();
            flag = manifestResourceName.ToLower().StartsWith(lower) && manifestResourceName.Length > lower.Length;
          }
          else
            flag = manifestResourceName.ToLower() == contentElementInfo.DateiPattern.ToLower();
          if (flag)
          {
            StreamReader streamReader = new StreamReader(executingAssembly.GetManifestResourceStream(manifestResourceName), Encoding.GetEncoding("ISO-8859-15"));
            string end = streamReader.ReadToEnd();
            string[] strArray2 = new string[1]
            {
              contentElementInfo.Name
            };
            contentDokumentList.Add(new ContentDokument()
            {
              Inhalt = end,
              Titel = str1,
              Unterverzeichnise = strArray2,
              DateiExtension = str2,
              ZusatzContentUniqueId = uniqueId
            });
            streamReader.Close();
          }
        }
      }
      if (contentDokumentList.Count == 0)
        throw new ApplicationException(string.Format("Keine Dokumente für Content UniqueID '{0}' gefunden!", (object) uniqueId));
      return contentDokumentList;
    }
  }
}
