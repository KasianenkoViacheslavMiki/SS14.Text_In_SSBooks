using SS14.Text_In_SSBooks.Interface;
using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SS14.Text_In_SSBooks.FileSystem
{
    public class TextFileSystem : IReadFiles
    {
        private string pathTxt;

        public TextFileSystem(string pathTxt)
        {
            this.pathTxt = pathTxt;
        }

        public string PathTxt
        {
            get
            {
                return pathTxt;
            }
        }

        public bool ReadFile(string fileName, out ContentFile? content)
        {
            if (fileName == null)
            {
                content = null;
                return false;
            }
            content = new ContentFile();

            if (File.Exists(pathTxt + fileName))
            {
                using (StreamReader fs = new StreamReader(fileName, Encoding.UTF8))
                {
                    if ("name:" == fs.ReadLine()) 
                    {
                        content.Name = fs.ReadLine();
                    }
                    if ("description:" == fs.ReadLine())
                    {
                        content.Description = fs.ReadLine();
                    }
                    if ("content:" == fs.ReadLine())
                    {
                        content.Content = fs.ReadToEnd();
                    }
                }
            }
            return true;
        }

        public bool ReadFiles(out IDictionary<string, ContentFile?>? text)
        {
            text = new Dictionary<string, ContentFile?>();
            byte[] b = new byte[1024];

            if (Directory.Exists(pathTxt))
            {
                foreach (var name in Directory.GetFiles(pathTxt))
                {
                    ContentFile content = new ContentFile();
                    UTF8Encoding uniencoding = new UTF8Encoding();

                    using (FileStream fs = File.OpenRead(name))
                    {
                        int readLen;
                        var stringText = "";
                        while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                        {
                            stringText += uniencoding.GetString(b, 0, readLen);
                        }
                        content.Name = stringText.Split("|").First().Replace("\r\n","");
                        content.Description = stringText.Split("|").Last().Split("&").First().Replace("\r\n", ""); ;
                        content.Content = stringText.Split("&").Last();

                        text.Add(name.Split("\\").Last().Split(".")[0], content);
                    }
                }
            }

            return true;
        }
    }
}
