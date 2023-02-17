using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CompressWithNet40
{
    /// <summary>
    /// Source: How to compress/decompress directories using GZipStream by Andrew Novik
    ///         http://www.codeproject.com/Tips/319438/How-to-Compress-Decompress-directories
    /// </summary>
    /// <remarks>This is for .NET 4. For .NET 4.5, use System.IO.Compression.ZipArchive instead.</remarks>
    public static class GZipHelper
    {
        public static void CompressDirectory(string sInDir, string sOutFile, Action<string> progressHandler)
        {
            string[] sFiles = Directory.GetFiles(sInDir, "*.*", SearchOption.AllDirectories);
            int iDirLen = sInDir[sInDir.Length - 1] == Path.DirectorySeparatorChar ? sInDir.Length : sInDir.Length + 1;

            using (FileStream outFile = new FileStream(sOutFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (GZipStream str = new GZipStream(outFile, CompressionMode.Compress))
                foreach (string sFilePath in sFiles)
                {
                    string sRelativePath = sFilePath.Substring(iDirLen);
                    if (progressHandler != null)
                        progressHandler(sRelativePath);
                    CompressFile(sInDir, sRelativePath, str);
                }
        }

        public static void CompressFile(string sDir, string sRelativePath, GZipStream zipStream)
        {
            //Compress file name
            char[] chars = sRelativePath.ToCharArray();
            zipStream.Write(BitConverter.GetBytes(chars.Length), 0, sizeof(int));
            foreach (char c in chars)
                zipStream.Write(BitConverter.GetBytes(c), 0, sizeof(char));

            //Compress file content
            byte[] bytes = File.ReadAllBytes(Path.Combine(sDir, sRelativePath));
            zipStream.Write(BitConverter.GetBytes(bytes.Length), 0, sizeof(int));
            zipStream.Write(bytes, 0, bytes.Length);
        }


        public static void DecompressToDirectory(string sCompressedFile, string sDir, Action<string> progressHandler)
        {
            using (FileStream inFile = new FileStream(sCompressedFile, FileMode.Open, FileAccess.Read, FileShare.None))
            using (GZipStream zipStream = new GZipStream(inFile, CompressionMode.Decompress, true))
                while (DecompressFile(sDir, zipStream, progressHandler)) ;
        }

        public static bool DecompressFile(string sDir, GZipStream zipStream, Action<string> progressHandler)
        {
            //Decompress file name
            byte[] bytes = new byte[sizeof(int)];
            int Readed = zipStream.Read(bytes, 0, sizeof(int));
            if (Readed < sizeof(int))
                return false;

            int iNameLen = BitConverter.ToInt32(bytes, 0);
            bytes = new byte[sizeof(char)];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iNameLen; i++)
            {
                zipStream.Read(bytes, 0, sizeof(char));
                char c = BitConverter.ToChar(bytes, 0);
                sb.Append(c);
            }
            string sFileName = sb.ToString();
            if (progressHandler != null)
                progressHandler(sFileName);

            //Decompress file content
            bytes = new byte[sizeof(int)];
            zipStream.Read(bytes, 0, sizeof(int));
            int iFileLen = BitConverter.ToInt32(bytes, 0);

            bytes = new byte[iFileLen];
            zipStream.Read(bytes, 0, bytes.Length);

            string sFilePath = Path.Combine(sDir, sFileName);
            string sFinalDir = Path.GetDirectoryName(sFilePath);
            if (!Directory.Exists(sFinalDir))
                Directory.CreateDirectory(sFinalDir);

            using (FileStream outFile = new FileStream(sFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                outFile.Write(bytes, 0, iFileLen);

            return true;
        }

 
    }
}
