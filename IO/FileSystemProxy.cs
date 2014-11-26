using System.Collections.Generic;
using System.IO;
using ImpromptuInterface;

namespace ItzWarty.IO {
   public class FileSystemProxy : IFileSystemProxy {
      private readonly IStreamFactory streamFactory;

      public FileSystemProxy(IStreamFactory streamFactory) {
         this.streamFactory = streamFactory;
      }

      public IFileStream CreateFile(string path) {
         return streamFactory.CreateFileStream(path);
      }

      public IFileStream OpenFile(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.ReadWrite, FileShare share = FileShare.None) {
         return streamFactory.CreateFileStream(path, mode, access, share);
      }

      public IEnumerable<string> EnumerateDirectories(string path) {
         return Directory.EnumerateDirectories(path);
      }

      public IEnumerable<string> EnumerateDirectories(string path, string searchPattern) {
         return Directory.EnumerateDirectories(path, searchPattern);
      }

      public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption) {
         return Directory.EnumerateDirectories(path, searchPattern, searchOption);
      }

      public IDirectoryInfo GetDirectoryInfo(string path) {
         return WrapDirectoryInfo(new DirectoryInfo(path));
      }

      public string ReadAllText(string path) {
         return File.ReadAllText(path);
      }

      public void WriteAllText(string path, string contents) {
         File.WriteAllText(path, contents);
      }

      public void CopyFile(string sourceFilePath, string destinationFilePath) {
         File.Copy(sourceFilePath, destinationFilePath);
      }

      public void PrepareDirectory(string path) {
         Directory.CreateDirectory(path);
      }

      public void PrepareParentDirectory(string path) {
         Directory.CreateDirectory(path.Split('/', '\\').Pass(x => x.SubArray(0, x.Length - 1).Join("/")));
      }

      public void DeleteDirectory(string path, bool recursive = false) {
         if (!recursive) {
            Directory.Delete(path, false);
         } else {
            foreach (var dir in Directory.EnumerateDirectories(path)) {
               DeleteDirectory(dir, true);
            }
            foreach (var file in Directory.EnumerateFiles(path)) {
               File.SetAttributes(file, FileAttributes.Normal);
               File.Delete(file);
            }
            Directory.Delete(path, false);
         }
      }

      private IDirectoryInfo WrapDirectoryInfo(DirectoryInfo directoryInfo) {
         return directoryInfo.ActLike<IDirectoryInfo>();
      }
   }
}