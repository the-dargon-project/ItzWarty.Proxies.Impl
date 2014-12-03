using System;
using System.IO;

namespace ItzWarty.IO {
   public class FileSystemInfoWrapper : IFileSystemInfo {
      private readonly FileSystemProxy fileSystemProxy;
      private readonly FileSystemInfo fileSystemInfo;

      public FileSystemInfoWrapper(FileSystemProxy fileSystemProxy, FileSystemInfo fileSystemInfo) {
         this.fileSystemProxy = fileSystemProxy;
         this.fileSystemInfo = fileSystemInfo;
      }

      public string Name { get { return fileSystemInfo.Name; } }
      public string FullName { get { return fileSystemInfo.FullName; } }
      public bool Exists { get { return fileSystemInfo.Exists; } }
      public FileAttributes Attributes { get { return fileSystemInfo.Attributes; } set { fileSystemInfo.Attributes = value; } }
      public DateTime CreationTime { get { return fileSystemInfo.CreationTime; } set { fileSystemInfo.CreationTime = value; } }
      public DateTime CreationTimeUtc { get { return fileSystemInfo.CreationTimeUtc; } set { fileSystemInfo.CreationTimeUtc = value; } }
      public DateTime LastWriteTime { get { return fileSystemInfo.LastWriteTime; } set { fileSystemInfo.LastWriteTime = value; } }
      public DateTime LastWriteTimeUtc { get { return fileSystemInfo.LastWriteTimeUtc; } set { fileSystemInfo.LastWriteTimeUtc = value; } }
      public virtual IDirectoryInfo Parent { get { return fileSystemProxy.GetFileInfo(fileSystemInfo.FullName).Parent; } }
   }
}