using System.Collections.Generic;
using System.IO;
using ImpromptuInterface;

namespace ItzWarty.IO {
   public class FileSystemProxy : IFileSystemProxy, InternalFileSystemProxy {
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

      public bool Exists(string path) {
         return File.Exists(path);
      }

      public IFileInfo GetFileInfo(string path) {
         return WrapFileInfo(new FileInfo(path));
      }

      public IDirectoryInfo GetDirectoryInfo(string path) {
         return WrapDirectoryInfo(new DirectoryInfo(path));
      }

      public IFileSystemInfo GetFileSystemInfo(string path) {
         var info = GetFileInfo(path);
         if (info.Attributes.HasFlag(FileAttributes.Directory)) {
            return GetDirectoryInfo(path);
         } else {
            return info;
         }
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

      public void DeleteFile(string path) {
         File.Delete(path);
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

      public void MoveFile(string source, string destination) {
         File.Move(source, destination);
      }

      public void MoveDirectory(string source, string destination) {
         Directory.Move(source, destination);
      }

      public IFileInfo WrapFileInfo(FileInfo fileInfo) {
         return new FileInfoWrapper(this, fileInfo);
      }

      public IDirectoryInfo WrapDirectoryInfo(DirectoryInfo directoryInfo) {
         return new DirectoryInfoWrapper(this, directoryInfo);
      }

      public IFileSystemInfo WrapFileSystemInfo(FileSystemInfo fileSystemInfo) {
         return new FileSystemInfoWrapper(this, fileSystemInfo);
      }
   }
}