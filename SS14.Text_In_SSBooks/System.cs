using SS14.Text_In_SSBooks.Interface;
using SS14.Text_In_SSBooks.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SS14.Text_In_SSBooks.Model;

namespace SS14.Text_In_SSBooks
{
    public class System
    {
        private readonly Config config;
        private readonly IReadFiles readFiles;
        private readonly IWriteFTLFile writeFTLFile;
        private readonly IWriteYMLFile writeYMLFile;


        private System()
        {
            this.config = new Config();
            this.readFiles = new TextFileSystem(config.PathTxt);
            this.writeFTLFile = new FTLFileSystem(config.PathFTL);
            this.writeYMLFile = new YMLFileSystem(config.PathYML);
        }

        private static System _instance = null;

        public static System Instance { 
            get
            {
                if (_instance == null)
                {
                    _instance = new System();
                }
                return _instance;
            }
        }

        public async void Start()
        {
            config.CreateDictionary();
            readFiles.ReadFiles(out var text);
            ThreadWrite(text);
        }   
        public void ThreadWrite(IDictionary<string, ContentFile?>? pairs)
        {
            writeFTLFile.WriteFTLFiles(pairs);
            writeYMLFile.WriteYMLFiles(pairs);
        }
    }
}
