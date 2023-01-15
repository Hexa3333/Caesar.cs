using System.Text;

namespace Caesar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    
    // TODO:
    // + Work:
    //        + Read
    //        + Write


    class Caesar
    {
        public static void RunE(string sourcePath, string outputPath, decimal shift) 
        {
            String source = Read(sourcePath);
            if (source == String.Empty)
            {
                return; // Don't bother with writing
            }

            String Res = Process(source, outputPath, shift);
            File.WriteAllText(outputPath, Res);
        }

        public static void RunD(string sourcePath, string outputPath, decimal shift) 
        {
            String source = Read(sourcePath);
            if (source == String.Empty)
            {
                return;
            }

            String Res = Process(source, outputPath, -shift);
            File.WriteAllText(outputPath, Res);
        }


        private static String Read(string readPath) 
        {
            string str;
            if (!File.Exists(readPath)) 
            {
                MessageBox.Show($"Unreadable: {readPath}", 
                    "File Does Not Exist Or Could Not be Read", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }

            using (TextReader reader = File.OpenText(readPath))
            {
                str = reader.ReadToEnd();
            }
            
            return str;
        }
        private static String Process(string read, string writePath, decimal shift) 
        {
            StringBuilder sb = new();

            foreach (char c in read)
            {
                if (c == '\n') {
                    sb.Append("\n");
                }
                else {
                    sb.Append((char)(c + shift));
                }
            }

            return sb.ToString();
        }
    }

}
