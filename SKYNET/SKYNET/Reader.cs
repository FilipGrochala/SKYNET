using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    class Reader
    {
        private string url = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "/wagi.txt";

        public Reader()
        { }

        public void write(string text)
        {
            StreamWriter writer = new StreamWriter(url);
            writer.Write("");
            writer.Write(text);
            writer.Close();
        }

        public string read()
        {
            return File.ReadAllText(url);
        }
       

    }
}
