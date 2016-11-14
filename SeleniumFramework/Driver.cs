using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static void Initialize()
        {
            string Fullpath = Directory.GetCurrentDirectory();
            var BinFolderpath = Directory.GetParent(Fullpath).ToString();
            var path = Directory.GetParent(BinFolderpath).ToString();
            Instance = new ChromeDriver(path);
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
