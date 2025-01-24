using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string OpenFileDialog()
        {
            var folderPath = ShowFolderBrowserDialog();

            string[] fileArray = Directory.GetFiles(folderPath, "*.json");

            Dictionary<string, List<string>> directoryOfPeaple = [];
            List<string> listOfContact = [];

            foreach (var file in fileArray)
            {
                List<string> result = [];

                using (StreamReader reader = new StreamReader(file))
                {
                    string txt = "";

                    while ((txt = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(txt) || string.IsNullOrWhiteSpace(txt))
                            continue;

                        txt = txt.Trim();
                        if (txt.StartsWith("\"value\""))
                        {
                            txt = txt.Remove(0, 10);
                            txt = txt.Remove(txt.Length - 2, 2);
                            result.Add(txt);
                        }
                    }
                }

                result.Sort();
                directoryOfPeaple.Add(file.Split('\\').Last().Replace(".json", ""), result);
            }

            var filePath = string.Empty;

            filePath = folderPath + "\\Followers State Result.csv";

            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                StreamWriter f = File.CreateText(filePath);
                f.Close();
            }

            // Open the file to read from.
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                string txt = "";

                int len = directoryOfPeaple.Keys.Count - 2;

                txt += "User,";

                foreach (var dir in directoryOfPeaple.Keys)
                {
                    txt += $"{dir.Replace('_',' ')},";
                }

                txt = txt.Remove(txt.Length - 1, 1) + "\n";
                sr.Write(txt);

                foreach(var dir in directoryOfPeaple)
                {
                    foreach (var part in dir.Value)
                    {
                        if(!listOfContact.Contains(part))
                        {
                            listOfContact.Add(part);
                        }
                    }
                }

                listOfContact.Sort();

                foreach (var user in listOfContact)
                {
                    txt = $"{user},";

                    foreach (var dir in directoryOfPeaple)
                    {
                        txt += $"{dir.Value.Contains(user)},"; 
                    }

                    txt = txt.Remove(txt.Length - 1, 1);

                    sr.WriteLine(txt);
                }
            }

            Process.Start("explorer.exe", folderPath);

            return filePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = OpenFileDialog();
        }

        public string ShowFolderBrowserDialog()
        {
            string pathName = string.Empty;

            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathName = fbd.SelectedPath;
                }
            }

            return pathName;
        }
    }
}
