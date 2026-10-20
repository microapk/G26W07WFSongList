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
            ListCar = new ListBox();
            txtTitle = new TextBox();
            txtArtist = new TextBox();
            txtRating = new TextBox();
            txtSelected = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            txtFilter = new TextBox();
            SuspendLayout();
            // 
            // ListCar
            // 
            ListCar.FormattingEnabled = true;
            ListCar.Location = new Point(12, 52);
            ListCar.Name = "ListCar";
            ListCar.Size = new Size(480, 344);
            ListCar.TabIndex = 0;
            ListCar.SelectedIndexChanged += OnChanged;
            ListCar.DoubleClick += OnYoutube;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 402);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "이름";
            txtTitle.Size = new Size(192, 27);
            txtTitle.TabIndex = 1;
            // 
            // txtArtist
            // 
            txtArtist.Location = new Point(210, 402);
            txtArtist.Name = "txtArtist";
            txtArtist.PlaceholderText = "제조사";
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
            txtSelected.PlaceholderText = "선택된 자동차";
            txtSelected.ReadOnly = true;
            txtSelected.Size = new Size(380, 27);
            txtSelected.TabIndex = 4;
            txtSelected.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(398, 402);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "추가";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += OnAdd;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(398, 437);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "제거";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += OnDelete;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(12, 12);
            txtFilter.Name = "txtFilter";
            txtFilter.PlaceholderText = "이름 또는 제조사 검색";
            txtFilter.Size = new Size(480, 27);
            txtFilter.TabIndex = 7;
            txtFilter.TextChanged += OnFilterChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 480);
            Controls.Add(txtFilter);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtSelected);
            Controls.Add(txtRating);
            Controls.Add(txtArtist);
            Controls.Add(txtTitle);
            Controls.Add(ListCar);
            Name = "Form1";
            Text = "자동차 리스트";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListCar;
        private TextBox txtTitle;
        private TextBox txtArtist;
        private TextBox txtRating;
        private TextBox txtSelected;
        private Button btnAdd;
        private Button btnDelete;
        private TextBox txtFilter;
    }
}
