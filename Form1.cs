using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.Media;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace UTXL
{
    public partial class UTXL : Form
    {
        
        string allowedFileTypes = "Text Files (.txt)|*.txt|CSS Files (.css)|*.css";
        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        InstalledFontCollection InsFonts = new InstalledFontCollection();
        
        
        string currentPath;
        bool saved = true;


        // this function will run when the form get Initialized
        public UTXL()
        {
            
            InitializeComponent();
            enableSave(false);
            initRichTextBox();
            label1.Visible = false;

            
           
            

            if (splitContainer.SplitterDistance > 0)
            {
                showFilesNavigatorToolStripMenuItem.Text = "Hide Files Navigator";
            }
            else
            {
                showFilesNavigatorToolStripMenuItem.Text = "Show Files Navigator";
            }

            richTextBox.RightMargin = richTextBox.Size.Width - 10;
            richTextBox.SelectionIndent += 10;

            // set allowed file types for open and save dialogs
            ofd.Filter = allowedFileTypes;
            sfd.Filter = allowedFileTypes;
        }


        /*************************** File ***************************/

        // this method will be called when new menu item is clicked
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        // this method will be called when open file menu item is clicked
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // check if file is selected successfully
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                // save selected file path
                this.currentPath = ofd.FileName;

                // get parent directory of the selected file
                string parentDirectory = Path.GetDirectoryName(this.currentPath);

                // add parent directory of the file to the tree view
                listDirectory(treeView, parentDirectory);

                // read text inside the selected file
                richTextBox.Text = sr.ReadToEnd();

                // enable save buttons
                enableSave(true);

                // dispose the stream reader, so we can use it in another place later
                sr.Dispose();
            }
        }

        // this method will be called when open directory menu item is clicked
        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // add selected directory to the tree view
                listDirectory(treeView, fbd.SelectedPath);
            }
        }

        // this method will be called when save menu item is clicked
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter(currentPath);
            UTF8Encoding utf8 = new UTF8Encoding();
            // Save file without byte order mark (BOM)
            // ref: http://msdn.microsoft.com/en-us/library/s064f8w2.aspx
            sr.Write(richTextBox.Text, false, utf8);
            sr.Dispose();
        }

        // this method will be called when save as menu item is clicked
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write(richTextBox.Text);
                bw.Dispose();
            }
        }

        // this method will be called when exit button is clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /*************************** Edit ***************************/
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != null && richTextBox.SelectedText.Length != 0)
            {
                Clipboard.SetText(richTextBox.SelectedText);
            }

        }
        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPath != null)
            {
                Clipboard.SetText(currentPath);
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = Clipboard.GetText();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }
        private void uPPERCASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = richTextBox.SelectedText.ToUpper();
        }
        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = richTextBox.SelectedText.ToLower();
        }


        /*************************** View ***************************/

        // this method will be called when show files navigator button is clicked
        private void showFilesNavigatorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (splitContainer.SplitterDistance > 0)
            {
                splitContainer.SplitterDistance = 0;
                showFilesNavigatorToolStripMenuItem.Text = "Show Files Navigator";
            }
            else
            {
                splitContainer.SplitterDistance = 180;
                showFilesNavigatorToolStripMenuItem.Text = "Hide Files Navigator";
            }

        }


        /*************************** Tools ***************************/
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm stg = new SettingsForm();
            stg.Show();
        }


        /*************************** Tree View ***************************/
        private void treeView_DoubleClick(object sender, EventArgs e)
        {
            string path = ((TreeView)sender).SelectedNode.ToolTipText;
            MessageBox.Show(path);
        }

        private void listDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(createDirectoryNode(rootDirectoryInfo));
        }
        private static TreeNode createDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(createDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                if (file.Extension.ToString() == ".txt")
                {
                    TreeNode node = new TreeNode(file.Name);

                    node.ToolTipText = file.FullName;
                    directoryNode.Nodes.Add(node);
                }

            return directoryNode;
        }


        /*************************** Rich Text Box ***************************/
        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());

            if (e.KeyValue == 219)
            {
                richTextBox.SelectedText += " }";
            }
        }



        /*************************** Helpers ***************************/
        public void enableSave(Boolean enable)
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // regester keys to undo/redo when space or enter keys are pressed
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                this.SuspendLayout();
                richTextBox.Undo();
                richTextBox.Redo();
                this.ResumeLayout();
            }

        }

        private void increaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.Font.Size < 100)
            {
                Font fnt = new Font(richTextBox.Font.Name, richTextBox.Font.Size + 2);
                richTextBox.Font = fnt;
            }
        }

        private void decreaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.Font.Size > 2)
            {
                Font fnt = new Font(richTextBox.Font.Name, richTextBox.Font.Size - 2);
                richTextBox.Font = fnt;
            }

        }

        private void resetFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initRichTextBox();
        }
        private void initRichTextBox()
        {

            if (Properties.Settings.Default.dark_mode)
            {
                richTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#253238");
                richTextBox.ForeColor = Color.White;

                treeView.BackColor = System.Drawing.ColorTranslator.FromHtml("#253238");
                treeView.ForeColor = Color.White;

                splitContainer.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F292E");
                splitContainer.ForeColor = Color.White;


                statusStrip.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F292E");
                statusStrip.ForeColor = Color.White;

                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F292E");
                this.ForeColor = Color.White;

                menuStrip.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F292E");
                menuStrip.ForeColor = Color.White;

                toolStrip.Renderer = new ToolStripOverride();
                toolStrip.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F292E");
                toolStrip.ForeColor = Color.White;
            }


            // set font and font size
            Font fnt = new Font(Properties.Settings.Default.font_name, Properties.Settings.Default.font_size);
            richTextBox.Font = fnt;
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write(richTextBox.Text);
                bw.Dispose();
            }


        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (richTextBox.Font.Size > 2)
            {
                Font fnt = new Font(richTextBox.Font.Name, richTextBox.Font.Size + 2);
                richTextBox.Font = fnt;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (richTextBox.Font.Size > 2)
            {
                Font fnt = new Font(richTextBox.Font.Name, richTextBox.Font.Size - 2);
                richTextBox.Font = fnt;
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            initRichTextBox();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

            richTextBox.SelectedText = richTextBox.SelectedText.ToUpper();

        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = richTextBox.SelectedText.ToLower();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = Clipboard.GetText();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != null && richTextBox.SelectedText.Length != 0)
            {
                Clipboard.SetText(richTextBox.SelectedText);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                listDirectory(treeView, fbd.SelectedPath);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog = new PrintDialog();
            PrintDocument documentToPrint = new PrintDocument();
            printDialog.Document = documentToPrint;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(richTextBox.Text);
                documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
                documentToPrint.Print();
            }
        }

        private void DocumentToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(richTextBox.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = this.richTextBox.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        // a workarround to remove the white border of toolStrip in dark mode
        public class ToolStripOverride : ToolStripProfessionalRenderer
        {
            public ToolStripOverride() { }
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        } 

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox.SelectionFont;
            fd.Color = richTextBox.SelectionColor;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fd.Font;
                richTextBox.SelectionColor = fd.Color;
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox.SelectionFont;
            fd.Color = richTextBox.SelectionColor;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fd.Font;
                richTextBox.SelectionColor = fd.Color;
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            
            Linenum.Text = richTextBox.Lines.Length.ToString();
            Characters.Text = richTextBox.Text.Length.ToString();
            int i = richTextBox.Lines.Length;
            label1.Text = "Line Number::" + richTextBox.GetLineFromCharIndex(i);
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This was done \nZAFER\nMERT\nOMAR \n V1.0.0 "+"LITTLE TEXT EDTOR");
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // check if file is selected successfully
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                // save selected file path
                this.currentPath = ofd.FileName;

                // get parent directory of the selected file
                string parentDirectory = Path.GetDirectoryName(this.currentPath);

                // add parent directory of the file to the tree view
                listDirectory(treeView, parentDirectory);

                // read text inside the selected file
                richTextBox.Text = sr.ReadToEnd();

                // enable save buttons
                enableSave(true);

                // dispose the stream reader, so we can use it in another place later
                sr.Dispose();
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = Clipboard.GetText();
        }

        private void upperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = richTextBox.SelectedText.ToUpper();
        }

        private void lowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = richTextBox.SelectedText.ToLower();

        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox.SelectionFont;
            fd.Color = richTextBox.SelectionColor;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fd.Font;
                richTextBox.SelectionColor = fd.Color;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            // check if file is selected successfully
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                // save selected file path
                this.currentPath = ofd.FileName;

                // get parent directory of the selected file
                string parentDirectory = Path.GetDirectoryName(this.currentPath);

                // add parent directory of the file to the tree view
                listDirectory(treeView, parentDirectory);

                // read text inside the selected file
                richTextBox.Text = sr.ReadToEnd();

                // enable save buttons
                enableSave(true);

                // dispose the stream reader, so we can use it in another place later
                sr.Dispose();
            }
        }

        private void selectAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.Remove();
            richTextBox.Text = "";
        }

        private void projectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/pvtmert/utxl");
        }

       
    
    }
}