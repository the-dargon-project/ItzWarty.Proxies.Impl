using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   public class BinaryWriterWrapper : IBinaryWriter {
      private readonly IStream stream;
      private readonly System.IO.BinaryWriter writer;

      public BinaryWriterWrapper(IStream stream) : this(stream, Encoding.UTF8) { }
      public BinaryWriterWrapper(IStream stream, Encoding encoding) : this(stream, encoding, false) { }
      public BinaryWriterWrapper(IStream stream, Encoding encoding, bool leaveOpen) {
         this.stream = stream;
         this.writer = new System.IO.BinaryWriter(stream.__Stream, encoding, leaveOpen);
      }

      public System.IO.BinaryWriter __Writer { get { return writer; } }

      public void Write(bool value) {
         writer.Write(value);
      }

      public void Write(byte value) {
         writer.Write(value);
      }

      public void Write(sbyte value) {
         writer.Write(value);
      }

      public void Write(char ch) {
         writer.Write(ch);
      }

      public void Write(short value) {
         writer.Write(value);
      }

      public void Write(ushort value) {
         writer.Write(value);
      }

      public void Write(int value) {
         writer.Write(value);
      }

      public void Write(uint value) {
         writer.Write(value);
      }

      public void Write(long value) {
         writer.Write(value);
      }

      public void Write(ulong value) {
         writer.Write(value);
      }

      public void Write(float value) {
         writer.Write(value);
      }

      public void Write(double value) {
         writer.Write(value);
      }

      public void Write(decimal value) {
         writer.Write(value);
      }

      public void Write(string value) {
         writer.Write(value);
      }

      public void WriteNullTerminatedString(string value) {
         writer.WriteNullTerminatedString(value);
      }

      public void WriteTinyText(string value) {
         writer.WriteTinyText(value);
      }

      public void WriteText(string value) {
         writer.WriteText(value);
      }

      public void WriteLongText(string value) {
         writer.WriteLongText(value);
      }

      public long Seek(int offset, SeekOrigin origin) {
         return writer.Seek(offset, origin);
      }

      public void Write(byte[] buffer) {
         writer.Write(buffer);
      }

      public void Write(byte[] buffer, int index, int count) {
         writer.Write(buffer, index, count);
      }

      public void Write(char[] chars) {
         writer.Write(chars);
      }

      public void Write(char[] chars, int index, int count) {
         writer.Write(chars, index, count);
      }

      public void Close() {
         writer.Close();
      }

      public void Flush() {
         writer.Flush();
      }

      public IStream BaseStream { get { return stream; } }

      public void Dispose() {
         writer.Dispose();
      }
   }
}
