namespace Filters
{
	partial class FilterForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
			this.buttonFilter = new System.Windows.Forms.Button();
			this.dataGridViewPhases = new System.Windows.Forms.DataGridView();
			this.listBoxName = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhases)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonFilter
			// 
			this.buttonFilter.Location = new System.Drawing.Point(555, 15);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(98, 38);
			this.buttonFilter.TabIndex = 0;
			this.buttonFilter.Text = "Filter";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
			// 
			// dataGridViewPhases
			// 
			this.dataGridViewPhases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridViewPhases.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewPhases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPhases.GridColor = System.Drawing.SystemColors.Menu;
			this.dataGridViewPhases.Location = new System.Drawing.Point(12, 90);
			this.dataGridViewPhases.Name = "dataGridViewPhases";
			this.dataGridViewPhases.RowHeadersVisible = false;
			this.dataGridViewPhases.RowTemplate.Height = 24;
			this.dataGridViewPhases.Size = new System.Drawing.Size(440, 260);
			this.dataGridViewPhases.TabIndex = 1;
			// 
			// listBoxName
			// 
			this.listBoxName.FormattingEnabled = true;
			this.listBoxName.ItemHeight = 16;
			this.listBoxName.Location = new System.Drawing.Point(458, 90);
			this.listBoxName.Name = "listBoxName";
			this.listBoxName.Size = new System.Drawing.Size(195, 260);
			this.listBoxName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Phases";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(455, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Names";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Filters.Properties.Resources.Logo;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 41);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// FilterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 364);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxName);
			this.Controls.Add(this.dataGridViewPhases);
			this.Controls.Add(this.buttonFilter);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FilterForm";
			this.Text = "Filters Example";
			this.Load += new System.EventHandler(this.FilterForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhases)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonFilter;
		private System.Windows.Forms.DataGridView dataGridViewPhases;
		private System.Windows.Forms.ListBox listBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

