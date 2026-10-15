namespace G26W07WFSongList
{
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
            ListSong = new ListBox();
            SuspendLayout();
            // 
            // ListSong
            // 
            ListSong.FormattingEnabled = true;
            ListSong.Location = new Point(12, 12);
            ListSong.Name = "ListSong";
            ListSong.Size = new Size(380, 424);
            ListSong.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 450);
            Controls.Add(ListSong);
            Name = "Form1";
            Text = "애창곡";
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListSong;
    }
}
