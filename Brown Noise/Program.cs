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
            //"BrownNoise.Properties.Resources.resources"
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            AppContext context = new AppContext();
            Application.Run(context);

        }

        public static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //shamelessly plagiarised from http://stackoverflow.com/questions/189549/embedding-dlls-in-a-compiled-executable/20306095#20306095
            string dllName = args.Name.Contains(",") ?
                                args.Name.Substring(0, args.Name.IndexOf(',')) :
                                args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");
            
            if (dllName.EndsWith("_resources"))
            {
                return null;
            }

            string baseName = typeof(Program).Namespace + ".Properties.Resources";
            ResourceManager rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
    }

    public class AppContext : ApplicationContext
    {
        public AppContext()
        {
            Form1 form = new Form1();
            form.Closing += new CancelEventHandler(OnFormClosing);
            form.Show();
            form.Hide();
        }

        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
