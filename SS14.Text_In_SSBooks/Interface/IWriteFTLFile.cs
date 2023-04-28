using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS14.Text_In_SSBooks.Interface
{
    public interface IWriteFTLFile
    {
        public Task<bool> WriteFTLFile(string? idcontent, string? content);
        public Task<bool> WriteFTLFiles(IDictionary<string, ContentFile?>? content);

    }
}
