namespace Map
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.contextMenuMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьНовуюМеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgTech = new System.Windows.Forms.DataGridView();
            this.bAddPoint = new System.Windows.Forms.Button();
            this.bDeletePoint = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbVic = new System.Windows.Forms.CheckBox();
            this.cbHel = new System.Windows.Forms.CheckBox();
            this.cbBatCr = new System.Windows.Forms.CheckBox();
            this.cbMed = new System.Windows.Forms.CheckBox();
            this.cbMinWid = new System.Windows.Forms.CheckBox();
            this.cbSiTan = new System.Windows.Forms.CheckBox();
            this.cbThor = new System.Windows.Forms.CheckBox();
            this.cbHellbat = new System.Windows.Forms.CheckBox();
            this.cbCyclon = new System.Windows.Forms.CheckBox();
            this.bUpdPoint = new System.Windows.Forms.Button();
            this.contextMenuMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTech)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemory = 5;
            this.gMap.Location = new System.Drawing.Point(12, 12);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(1239, 576);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            this.gMap.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDown);
            this.gMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseUp);
            // 
            // contextMenuMap
            // 
            this.contextMenuMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьНовуюМеткуToolStripMenuItem});
            this.contextMenuMap.Name = "contextMenuStrip1";
            this.contextMenuMap.Size = new System.Drawing.Size(192, 26);
            // 
            // создатьНовуюМеткуToolStripMenuItem
            // 
            this.создатьНовуюМеткуToolStripMenuItem.Name = "создатьНовуюМеткуToolStripMenuItem";
            this.создатьНовуюМеткуToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.создатьНовуюМеткуToolStripMenuItem.Text = "Создать новую метку";
            this.создатьНовуюМеткуToolStripMenuItem.Click += new System.EventHandler(this.создатьНовуюМеткуToolStripMenuItem_Click);
            // 
            // dgTech
            // 
            this.dgTech.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTech.Location = new System.Drawing.Point(12, 594);
            this.dgTech.Name = "dgTech";
            this.dgTech.Size = new System.Drawing.Size(443, 202);
            this.dgTech.TabIndex = 1;
            // 
            // bAddPoint
            // 
            this.bAddPoint.Location = new System.Drawing.Point(461, 594);
            this.bAddPoint.Name = "bAddPoint";
            this.bAddPoint.Size = new System.Drawing.Size(114, 49);
            this.bAddPoint.TabIndex = 2;
            this.bAddPoint.Text = "Добавить метку";
            this.bAddPoint.UseVisualStyleBackColor = true;
            this.bAddPoint.Click += new System.EventHandler(this.bAddPoint_Click);
            // 
            // bDeletePoint
            // 
            this.bDeletePoint.Location = new System.Drawing.Point(461, 746);
            this.bDeletePoint.Name = "bDeletePoint";
            this.bDeletePoint.Size = new System.Drawing.Size(114, 49);
            this.bDeletePoint.TabIndex = 3;
            this.bDeletePoint.Text = "Удалить метку";
            this.bDeletePoint.UseVisualStyleBackColor = true;
            this.bDeletePoint.Click += new System.EventHandler(this.bDeletePoint_Click);
            // 
            // cbVic
            // 
            this.cbVic.AutoSize = true;
            this.cbVic.Location = new System.Drawing.Point(600, 594);
            this.cbVic.Name = "cbVic";
            this.cbVic.Size = new System.Drawing.Size(62, 17);
            this.cbVic.TabIndex = 4;
            this.cbVic.Text = "Викинг";
            this.cbVic.UseVisualStyleBackColor = true;
            this.cbVic.CheckedChanged += new System.EventHandler(this.cbVic_CheckedChanged);
            // 
            // cbHel
            // 
            this.cbHel.AutoSize = true;
            this.cbHel.Location = new System.Drawing.Point(600, 618);
            this.cbHel.Name = "cbHel";
            this.cbHel.Size = new System.Drawing.Size(68, 17);
            this.cbHel.TabIndex = 5;
            this.cbHel.Text = "Геллион";
            this.cbHel.UseVisualStyleBackColor = true;
            this.cbHel.CheckedChanged += new System.EventHandler(this.cbHel_CheckedChanged);
            // 
            // cbBatCr
            // 
            this.cbBatCr.AutoSize = true;
            this.cbBatCr.Location = new System.Drawing.Point(600, 641);
            this.cbBatCr.Name = "cbBatCr";
            this.cbBatCr.Size = new System.Drawing.Size(124, 17);
            this.cbBatCr.TabIndex = 6;
            this.cbBatCr.Text = "Линейный Крейсер";
            this.cbBatCr.UseVisualStyleBackColor = true;
            this.cbBatCr.CheckedChanged += new System.EventHandler(this.cbBatCr_CheckedChanged);
            // 
            // cbMed
            // 
            this.cbMed.AutoSize = true;
            this.cbMed.Location = new System.Drawing.Point(600, 665);
            this.cbMed.Name = "cbMed";
            this.cbMed.Size = new System.Drawing.Size(71, 17);
            this.cbMed.TabIndex = 7;
            this.cbMed.Text = "Медивак";
            this.cbMed.UseVisualStyleBackColor = true;
            this.cbMed.CheckedChanged += new System.EventHandler(this.cbMed_CheckedChanged);
            // 
            // cbMinWid
            // 
            this.cbMinWid.AutoSize = true;
            this.cbMinWid.Location = new System.Drawing.Point(600, 688);
            this.cbMinWid.Name = "cbMinWid";
            this.cbMinWid.Size = new System.Drawing.Size(87, 17);
            this.cbMinWid.TabIndex = 11;
            this.cbMinWid.Text = "Мина Вдова";
            this.cbMinWid.UseVisualStyleBackColor = true;
            this.cbMinWid.CheckedChanged += new System.EventHandler(this.cbMinWid_CheckedChanged);
            // 
            // cbSiTan
            // 
            this.cbSiTan.AutoSize = true;
            this.cbSiTan.Location = new System.Drawing.Point(600, 711);
            this.cbSiTan.Name = "cbSiTan";
            this.cbSiTan.Size = new System.Drawing.Size(100, 17);
            this.cbSiTan.TabIndex = 10;
            this.cbSiTan.Text = "Осадный Танк";
            this.cbSiTan.UseVisualStyleBackColor = true;
            this.cbSiTan.CheckedChanged += new System.EventHandler(this.cbSiTan_CheckedChanged);
            // 
            // cbThor
            // 
            this.cbThor.AutoSize = true;
            this.cbThor.Location = new System.Drawing.Point(600, 734);
            this.cbThor.Name = "cbThor";
            this.cbThor.Size = new System.Drawing.Size(45, 17);
            this.cbThor.TabIndex = 9;
            this.cbThor.Text = "Тор";
            this.cbThor.UseVisualStyleBackColor = true;
            this.cbThor.CheckedChanged += new System.EventHandler(this.cbThor_CheckedChanged);
            // 
            // cbHellbat
            // 
            this.cbHellbat.AutoSize = true;
            this.cbHellbat.Location = new System.Drawing.Point(600, 756);
            this.cbHellbat.Name = "cbHellbat";
            this.cbHellbat.Size = new System.Drawing.Size(68, 17);
            this.cbHellbat.TabIndex = 8;
            this.cbHellbat.Text = "Хеллбат";
            this.cbHellbat.UseVisualStyleBackColor = true;
            this.cbHellbat.CheckedChanged += new System.EventHandler(this.cbHellbat_CheckedChanged);
            // 
            // cbCyclon
            // 
            this.cbCyclon.AutoSize = true;
            this.cbCyclon.Location = new System.Drawing.Point(600, 778);
            this.cbCyclon.Name = "cbCyclon";
            this.cbCyclon.Size = new System.Drawing.Size(64, 17);
            this.cbCyclon.TabIndex = 12;
            this.cbCyclon.Text = "Циклон";
            this.cbCyclon.UseVisualStyleBackColor = true;
            this.cbCyclon.CheckedChanged += new System.EventHandler(this.cbCyclon_CheckedChanged);
            // 
            // bUpdPoint
            // 
            this.bUpdPoint.Location = new System.Drawing.Point(461, 671);
            this.bUpdPoint.Name = "bUpdPoint";
            this.bUpdPoint.Size = new System.Drawing.Size(114, 49);
            this.bUpdPoint.TabIndex = 13;
            this.bUpdPoint.Text = "Изменить метку";
            this.bUpdPoint.UseVisualStyleBackColor = true;
            this.bUpdPoint.Click += new System.EventHandler(this.bUpdPoint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1263, 808);
            this.Controls.Add(this.bUpdPoint);
            this.Controls.Add(this.cbCyclon);
            this.Controls.Add(this.cbMinWid);
            this.Controls.Add(this.cbSiTan);
            this.Controls.Add(this.cbThor);
            this.Controls.Add(this.cbHellbat);
            this.Controls.Add(this.cbMed);
            this.Controls.Add(this.cbBatCr);
            this.Controls.Add(this.cbHel);
            this.Controls.Add(this.cbVic);
            this.Controls.Add(this.bDeletePoint);
            this.Controls.Add(this.bAddPoint);
            this.Controls.Add(this.dgTech);
            this.Controls.Add(this.gMap);
            this.Name = "Form1";
            this.Text = "Карта";
            this.contextMenuMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTech)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.ContextMenuStrip contextMenuMap;
        private System.Windows.Forms.ToolStripMenuItem создатьНовуюМеткуToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgTech;
        private System.Windows.Forms.Button bAddPoint;
        private System.Windows.Forms.Button bDeletePoint;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbVic;
        private System.Windows.Forms.CheckBox cbHel;
        private System.Windows.Forms.CheckBox cbBatCr;
        private System.Windows.Forms.CheckBox cbMed;
        private System.Windows.Forms.CheckBox cbMinWid;
        private System.Windows.Forms.CheckBox cbSiTan;
        private System.Windows.Forms.CheckBox cbThor;
        private System.Windows.Forms.CheckBox cbHellbat;
        private System.Windows.Forms.CheckBox cbCyclon;
        private System.Windows.Forms.Button bUpdPoint;
    }
}

