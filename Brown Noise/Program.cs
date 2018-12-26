using System;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace BrownNoise
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            Application.Run(context);
        }
    }

    public class AppContext : ApplicationContext
    {
        public AppContext()
        {
            Form1 form = new Form1();
            form.Closing += new CancelEventHandler(OnFormClosing);
            form.Show();
#if !DEBUG
            form.Hide();
#endif
        }

        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
