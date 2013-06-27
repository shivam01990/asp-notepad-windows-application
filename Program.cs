using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NotepadPlus
{
    static class Program
    {
        public static ParentForm pf;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            pf = new ParentForm();
            Application.Run(pf);
        }
    }
}
