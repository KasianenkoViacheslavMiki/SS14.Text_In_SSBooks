using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS14.Text_In_SSBooks.Interface
{
    public interface IWriteYMLFile
    {
        public string WriteYMLFile(string? filename, string? name, string discription="book", string idcontent = "book-error", string idsprite = "book1");
        public Task<bool> WriteYMLFiles(IDictionary<string, ContentFile?>? content);

    }
}
