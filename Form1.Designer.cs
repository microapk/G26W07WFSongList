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
            txtTitle = new TextBox();
            txtArtist = new TextBox();
            txtRating = new TextBox();
            txtSelected = new TextBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // ListSong
            // 
            ListSong.FormattingEnabled = true;
            ListSong.Location = new Point(12, 12);
            ListSong.Name = "ListSong";
            ListSong.Size = new Size(380, 384);
            ListSong.TabIndex = 0;
            ListSong.SelectedIndexChanged += OnChanged;
            ListSong.DoubleClick += OnYoutube;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 402);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "제목";
            txtTitle.Size = new Size(192, 27);
            txtTitle.TabIndex = 1;
            // 
            // txtArtist
            // 
            txtArtist.Location = new Point(210, 402);
            txtArtist.Name = "txtArtist";
            txtArtist.PlaceholderText = "가수";
            txtArtist.Size = new Size(86, 27);
            txtArtist.TabIndex = 2;
            // 
            // txtRating
            // 
            txtRating.Location = new Point(302, 402);
            txtRating.Name = "txtRating";
            txtRating.PlaceholderText = "평점";
            txtRating.Size = new Size(90, 27);
            txtRating.TabIndex = 3;
            // 
            // txtSelected
            // 
            txtSelected.Enabled = false;
            txtSelected.Location = new Point(12, 441);
            txtSelected.Name = "txtSelected";
            txtSelected.PlaceholderText = "삭제를 위해 선택된 노래";
            txtSelected.ReadOnly = true;
            txtSelected.Size = new Size(380, 27);
            txtSelected.TabIndex = 4;
            txtSelected.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(398, 439);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "button1";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += OnDelete;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 480);
            Controls.Add(btnDelete);
            Controls.Add(txtSelected);
            Controls.Add(txtRating);
            Controls.Add(txtArtist);
            Controls.Add(txtTitle);
            Controls.Add(ListSong);
            Name = "Form1";
            Text = "애창곡";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListSong;
        private TextBox txtTitle;
        private TextBox txtArtist;
        private TextBox txtRating;
        private TextBox txtSelected;
        private Button btnDelete;
    }
}
