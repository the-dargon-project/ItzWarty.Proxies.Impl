using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NMockito;
using Xunit;
using static NMockito.NMockitoStatic;

namespace ItzWarty.IO {
   public class DirectoryInfoWrapperTests {
      [Mock] private readonly InternalFileSystemProxy internalFileSystemProxy = null;
      private readonly DirectoryInfo directoryInfo;
      private readonly DirectoryInfoWrapper testObj;

      [Mock] 
      public DirectoryInfoWrapperTests() {
         ReinitializeMocks(this);
         directoryInfo = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
         testObj = new DirectoryInfoWrapper(internalFileSystemProxy, directoryInfo);
      }

      [Fact]
      public void ParentTest() {
         var parentCaptor = new ArgumentCaptor<DirectoryInfo>();
         var parentDirectoryInfo = CreateMock<IDirectoryInfo>();
         When(internalFileSystemProxy.WrapDirectoryInfo(parentCaptor.GetParameter())).ThenReturn(parentDirectoryInfo);
         var actualParentDirectoryInfo = testObj.Parent;
         AssertEquals(parentDirectoryInfo, actualParentDirectoryInfo);
         AssertEquals(directoryInfo.Parent.FullName, parentCaptor.Value.FullName);
      }
   }
}
