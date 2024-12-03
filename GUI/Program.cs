using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // vui lòng không sửa cái này làm ơn
            Application.Run(new frm_dangNhap());
        }
    }
}
