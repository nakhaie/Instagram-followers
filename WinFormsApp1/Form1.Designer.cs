
namespace WinFormsApp1
{
    public class AssetName
    {
        public string Number { get; set; }
        public string AssetType { get; set; }
        public string Domain { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Example { get; set; }
    }

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(262, 38);
            button1.Name = "button1";
            button1.Size = new Size(161, 35);
            button1.TabIndex = 0;
            button1.Text = "Select Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "Result Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 9);
            label2.Name = "label2";
            label2.Size = new Size(526, 15);
            label2.TabIndex = 2;
            label2.Text = "Download your instagram backup and select the path like \"/connections/followers_and_following\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 115);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Instagram Followers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
    }
}
