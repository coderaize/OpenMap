﻿namespace OpenMapDownloader
{
	partial class Downloader
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
			this.loadJsonBtn = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.TxtRemainingMapsToBeDownloaded = new System.Windows.Forms.TextBox();
			this.startDownloadingBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtMaxDegreeOfParallelism = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// loadJsonBtn
			// 
			this.loadJsonBtn.Location = new System.Drawing.Point(14, 16);
			this.loadJsonBtn.Name = "loadJsonBtn";
			this.loadJsonBtn.Size = new System.Drawing.Size(94, 29);
			this.loadJsonBtn.TabIndex = 0;
			this.loadJsonBtn.Text = "LoadJSON";
			this.loadJsonBtn.UseVisualStyleBackColor = true;
			this.loadJsonBtn.Click += new System.EventHandler(this.loadJsonBtn_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(14, 95);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(680, 650);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// TxtRemainingMapsToBeDownloaded
			// 
			this.TxtRemainingMapsToBeDownloaded.Location = new System.Drawing.Point(606, 16);
			this.TxtRemainingMapsToBeDownloaded.Name = "TxtRemainingMapsToBeDownloaded";
			this.TxtRemainingMapsToBeDownloaded.Size = new System.Drawing.Size(88, 27);
			this.TxtRemainingMapsToBeDownloaded.TabIndex = 3;
			// 
			// startDownloadingBtn
			// 
			this.startDownloadingBtn.Location = new System.Drawing.Point(114, 16);
			this.startDownloadingBtn.Name = "startDownloadingBtn";
			this.startDownloadingBtn.Size = new System.Drawing.Size(134, 29);
			this.startDownloadingBtn.TabIndex = 4;
			this.startDownloadingBtn.Text = "Start Downloading";
			this.startDownloadingBtn.UseVisualStyleBackColor = true;
			this.startDownloadingBtn.Click += new System.EventHandler(this.startDownloadingBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(14, 49);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(677, 27);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "https://tile.openstreetmap.de/{z}/{x}/{y}.png";
			// 
			// txtMaxDegreeOfParallelism
			// 
			this.txtMaxDegreeOfParallelism.Location = new System.Drawing.Point(393, 16);
			this.txtMaxDegreeOfParallelism.Name = "txtMaxDegreeOfParallelism";
			this.txtMaxDegreeOfParallelism.Size = new System.Drawing.Size(88, 27);
			this.txtMaxDegreeOfParallelism.TabIndex = 6;
			this.txtMaxDegreeOfParallelism.Text = "100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(316, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Max DOP";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(520, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Remaining";
			// 
			// Downloader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(703, 757);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMaxDegreeOfParallelism);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.startDownloadingBtn);
			this.Controls.Add(this.TxtRemainingMapsToBeDownloaded);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.loadJsonBtn);
			this.Name = "Downloader";
			this.Text = "Downloader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button loadJsonBtn;
		private RichTextBox richTextBox1;
		private TextBox TxtRemainingMapsToBeDownloaded;
		private Button startDownloadingBtn;
		private TextBox textBox1;
		private TextBox txtMaxDegreeOfParallelism;
		private Label label1;
		private Label label2;
	}
}