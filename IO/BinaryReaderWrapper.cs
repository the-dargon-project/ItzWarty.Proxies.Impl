using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItzWarty.IO {
   public class BinaryReaderWrapper : IBinaryReader {
      private readonly IStream stream;
      private System.IO.BinaryReader reader;

      public BinaryReaderWrapper(IStream input) : this(input, Encoding.UTF8) { }
      public BinaryReaderWrapper(IStream input, Encoding encoding) : this(input, encoding, false) { }
      public BinaryReaderWrapper(IStream input, Encoding encoding, bool leaveOpen){
         stream = input;
         reader = new System.IO.BinaryReader(stream.__Stream, encoding, leaveOpen);
      }

      public System.IO.BinaryReader __Reader { get { return reader; } }

      public int PeekChar() {
         return reader.PeekChar();
      }

      public int Read() {
         return reader.Read();
      }

      public bool ReadBoolean() {
         return reader.ReadBoolean();
      }

      public byte ReadByte() {
         return reader.ReadByte();
      }

      public sbyte ReadSByte() {
         return reader.ReadSByte();
      }

      public char ReadChar() {
         return reader.ReadChar();
      }

      public short ReadInt16() {
         return reader.ReadInt16();
      }

      public ushort ReadUInt16() {
         return reader.ReadUInt16();
      }

      public int ReadInt32() {
         return reader.ReadInt32();
      }

      public uint ReadUInt32() {
         return reader.ReadUInt32();
      }

      public long ReadInt64() {
         return reader.ReadInt64();
      }

      public ulong ReadUInt64() {
         return reader.ReadUInt64();
      }

      public float ReadSingle() {
         return reader.ReadSingle();
      }

      public double ReadDouble() {
         return reader.ReadDouble();
      }

      public decimal ReadDecimal() {
         return reader.ReadDecimal();
      }

      public string ReadString() {
         return reader.ReadString();
      }

      public string ReadStringOfLength(int length) {
         return reader.ReadStringOfLength(length);
      }

      public string ReadNullTerminatedString() {
         return reader.ReadNullTerminatedString();
      }

      public string ReadTinyText() {
         return reader.ReadTinyText();
      }

      public string ReadText() {
         return reader.ReadText();
      }

      public string ReadLongText() {
         return reader.ReadLongText();
      }

      public int Read(char[] buffer, int index, int count) {
         return reader.Read(buffer, index, count);
      }

      public char[] ReadChars(int count) {
         return reader.ReadChars(count);
      }

      public int Read(byte[] buffer, int index, int count) {
         return reader.Read(buffer, index, count);
      }

      public byte[] ReadBytes(int count) {
         return reader.ReadBytes(count);
      }

      public byte[] ReadAllBytes() {
         return reader.ReadAllBytes();
      }

      public void Close() {
         reader.Close();
      }

      public IStream BaseStream { get { return stream; } }

      public void Dispose() {
         reader.Dispose();
      }
   }
}
