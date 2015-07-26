using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ItzWarty.IO {
   public class DirectoryInfoWrapper : FileSystemInfoWrapper, IDirectoryInfo {
      private readonly InternalFileSystemProxy fileSystemProxy;
      private readonly DirectoryInfo directoryInfo;

      [Obsolete]
      public DirectoryInfoWrapper(
         FileSystemProxy fileSystemProxy, 
         DirectoryInfo directoryInfo
      ) : this(
         (InternalFileSystemProxy)fileSystemProxy, 
         directoryInfo
      ) { }

      internal DirectoryInfoWrapper(InternalFileSystemProxy fileSystemProxy, DirectoryInfo directoryInfo)
         : base(fileSystemProxy, directoryInfo) {
         this.fileSystemProxy = fileSystemProxy;
         this.directoryInfo = directoryInfo;
      }

      public override IDirectoryInfo Parent => fileSystemProxy.WrapDirectoryInfo(directoryInfo.Parent);

      public void Create() {
         fileSystemProxy.PrepareDirectory(directoryInfo.FullName);
      }

      public void Delete() {
         fileSystemProxy.DeleteDirectory(directoryInfo.FullName, false);
      }

      public void Delete(bool recursive) {
         fileSystemProxy.DeleteDirectory(directoryInfo.FullName, recursive);
      }

      public IEnumerable<IDirectoryInfo> EnumerateDirectories() {
         return directoryInfo.EnumerateDirectories().Select(fileSystemProxy.WrapDirectoryInfo);
      }

      public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern) {
         return directoryInfo.EnumerateDirectories(searchPattern).Select(fileSystemProxy.WrapDirectoryInfo);
      }

      public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption) {
         return directoryInfo.EnumerateDirectories(searchPattern, searchOption).Select(fileSystemProxy.WrapDirectoryInfo);
      }

      public IEnumerable<IFileInfo> EnumerateFiles() {
         return directoryInfo.EnumerateFiles().Select(fileSystemProxy.WrapFileInfo);
      }

      public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern) {
         return directoryInfo.EnumerateFiles(searchPattern).Select(fileSystemProxy.WrapFileInfo);
      }

      public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption) {
         return directoryInfo.EnumerateFiles(searchPattern, searchOption).Select(fileSystemProxy.WrapFileInfo);
      }

      public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos() {
         return directoryInfo.EnumerateFileSystemInfos().Select(fileSystemProxy.WrapFileSystemInfo);
      }

      public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern) {
         return directoryInfo.EnumerateFileSystemInfos(searchPattern).Select(fileSystemProxy.WrapFileSystemInfo);
      }

      public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
         return directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption).Select(fileSystemProxy.WrapFileSystemInfo);
      }

      public IDirectoryInfo Root { get { return fileSystemProxy.WrapDirectoryInfo(directoryInfo.Root); } }
   }
}