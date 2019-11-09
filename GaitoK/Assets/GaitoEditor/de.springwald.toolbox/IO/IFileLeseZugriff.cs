// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.IO.IFileLeseZugriff
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Collections.Generic;
using System.IO;

namespace de.springwald.toolbox.IO
{
  public interface IFileLeseZugriff
  {
    bool FileExists(string filepathRelative);

    Stream GetFile(string filepathRelative);

    FileInfoRelative GetFileInfo(string filepathRelative);

    string GetFileContentAsString(string filepathRelative);

    bool TryGetFile(string filepathRelative, out Stream filestream);

    bool DirectoryExist(string directoryPathRelative);

    IEnumerable<string> GetFiles(string directoryPathRelative, string searchPattern);

    IEnumerable<string> GetFiles(string directoryPathRelative);

    IEnumerable<FileInfoRelative> GetFileInfos(
      string directoryPathRelative,
      string searchPattern);

    IEnumerable<FileInfoRelative> GetFileInfos(
      string directoryPathRelative);
  }
}
