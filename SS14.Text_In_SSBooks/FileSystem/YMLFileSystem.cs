using SS14.Text_In_SSBooks.Interface;
using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS14.Text_In_SSBooks.FileSystem
{
    public class YMLFileSystem : IWriteYMLFile
    {
        byte maxIndexBook = 8;
        readonly private string pathUML;
        Random random = new Random();
        public YMLFileSystem(string pathUML)
        {
            this.pathUML = pathUML;
        }

        public async Task<bool> WriteYMLFiles(IDictionary<string, ContentFile?>? content)
        {
            using (StreamWriter writer = new StreamWriter(pathUML + "CustomBooks" + ".uml", false, Encoding.UTF8))
            {
                foreach (var contenItem in content)
                {
                    var spriteId = "book" + random.Next(0, maxIndexBook);
                    await writer.WriteLineAsync(WriteYMLFile(contenItem.Key, contenItem.Value.Name, contenItem.Value.Description, contenItem.Key, spriteId));
                }
            }
            return true;
        }

        public string WriteYMLFile(string? filename, string? name, string discription, string idcontent, string idsprite)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("- type: entity");
            sb.AppendLine("  parent: BaseItem");
            sb.AppendLine("  id: "+ filename+"id");
            sb.AppendLine("  name: "+ name);
            sb.AppendLine("  description: " + discription);
            sb.AppendLine("  components: ");
            sb.AppendLine("      - type: Sprite");
            sb.AppendLine("      sprite: Objects/Misc/books.rsi");
            sb.AppendLine("      layers:");
            sb.AppendLine("        - state: "+idsprite);
            sb.AppendLine("    - type: Paper");
            sb.AppendLine("      content: "+ idcontent);

            return sb.ToString();
        }
    }
}
