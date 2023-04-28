using SS14.Text_In_SSBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS14.Text_In_SSBooks.Interface
{
    public interface IReadFiles
    {
        public bool ReadFile(string fileName,out ContentFile? contentFile);
        public bool ReadFiles(out IDictionary<string, ContentFile?>? text);
    }
}
