using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressWithNet40
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderToCompress = @"C:\temp";
            string targetFileName = @"C:\test.gzip";

            GZipHelper.CompressDirectory(folderToCompress, targetFileName, (fname) =>
            {
                Console.WriteLine("Compressing {0}", fname);
            });

            GZipHelper.DecompressToDirectory(targetFileName, @"C:\1", (fname) =>
            {
                Console.WriteLine("Decompressing {0}", fname);
            });
        }
    }
}
