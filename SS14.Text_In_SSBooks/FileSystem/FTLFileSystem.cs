using SS14.Text_In_SSBooks.Interface;
using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SS14.Text_In_SSBooks.FileSystem
{
    public class FTLFileSystem : IWriteFTLFile
    {
        readonly private string pathFTL;

        public FTLFileSystem(string pathFTL)
        {
            this.pathFTL = pathFTL;
        }

        public string  PathFTL
        {
            get 
            { 
                return pathFTL; 
            }
        }

        public async Task<bool> WriteFTLFile(string? idcontent, string? content)
        {
            using (StreamWriter writer = new StreamWriter(pathFTL+"CustomBooks"+".ftl", false, Encoding.UTF8))
            {
                await writer.WriteLineAsync(idcontent+": "+content+"\n");
            }
            return true;
        }

        public async Task<bool> WriteFTLFiles(IDictionary<string, ContentFile?>? content)
        {
            using (StreamWriter writer = new StreamWriter(pathFTL + "CustomBooks" + ".ftl", false, Encoding.UTF8))
            {
                foreach (var contenItem in content)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(contenItem.Key + " = " + contenItem.Value.Content.Replace("\r\n", "\r\n        "));
                    await writer.WriteLineAsync(sb.ToString());
                }
            }
            return true;
        }
    }
}
