using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Windows.Forms;

namespace proj_casa_dos_dados
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
    }
}