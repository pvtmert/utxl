namespace UTXL
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.darkModeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // darkModeListBox
            // 
            this.darkModeListBox.FormattingEnabled = true;
            this.darkModeListBox.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.darkModeListBox.Location = new System.Drawing.Point(240, 91);
            this.darkModeListBox.Name = "darkModeListBox";
            this.darkModeListBox.Size = new System.Drawing.Size(120, 17);
            this.darkModeListBox.TabIndex = 0;
            this.darkModeListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 364);
            this.Controls.Add(this.darkModeListBox);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox darkModeListBox;
    }
}