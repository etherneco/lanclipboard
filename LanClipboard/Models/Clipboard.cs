using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Models
{
    public class Clipboard
    {
        public string clipboardData = "";
        private string fileName;

        public string[] ClipData
        {
            get { return clipboardData.Split('\n'); }
        }



        public Clipboard(string file)
        {
            fileName = file;
            if (System.IO.File.Exists(fileName))
            {
                clipboardData = System.IO.File.ReadAllText(fileName);
            }
        }

        public bool Add(string position)
        {
            clipboardData += position + '\n';
            System.IO.File.WriteAllText(fileName, clipboardData);
            return true;
        }

        public bool Delete(int id)
        {
            string[] list = clipboardData.Split('\n');
            int j = 0;
            string tmp = "";
            for(int i=0;i<list.Length;i++)
            {

                if (i != id)
                    tmp += list[i]+'\n';
            }
            clipboardData = tmp;
            System.IO.File.WriteAllText(fileName, clipboardData);
            return true;
        }

    }
}