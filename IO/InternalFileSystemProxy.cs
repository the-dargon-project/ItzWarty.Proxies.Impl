using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   internal interface InternalFileSystemProxy : IFileSystemProxy {
      IFileInfo WrapFileInfo(FileInfo fileInfo);
      IDirectoryInfo WrapDirectoryInfo(DirectoryInfo directoryInfo);
      IFileSystemInfo WrapFileSystemInfo(FileSystemInfo fileSystemInfo);
   }
}
