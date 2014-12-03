using System.IO;

namespace ItzWarty.IO {
   public class FileInfoWrapper : FileSystemInfoWrapper, IFileInfo {
      private readonly FileSystemProxy fileSystemProxy;
      private readonly FileInfo fileInfo;

      public FileInfoWrapper(FileSystemProxy fileSystemProxy, FileInfo fileInfo)
         : base(fileSystemProxy, fileInfo) {
         this.fileSystemProxy = fileSystemProxy;
         this.fileInfo = fileInfo;
      }

      public override IDirectoryInfo Parent { get { return fileSystemProxy.WrapDirectoryInfo(fileInfo.Directory); } }

      public IFileStream Create() {
         return fileSystemProxy.CreateFile(fileInfo.FullName);
      }

      public IFileStream Open(FileMode fileMode) {
         return fileSystemProxy.OpenFile(fileInfo.FullName, fileMode);
      }

      public IFileStream Open(FileMode fileMode, FileAccess fileAccess) {
         return fileSystemProxy.OpenFile(fileInfo.FullName, fileMode, fileAccess);
      }

      public IFileStream Open(FileMode fileMode, FileAccess fileAccess, FileShare fileShare) {
         return fileSystemProxy.OpenFile(fileInfo.FullName, fileMode, fileAccess, fileShare);
      }
   }
}