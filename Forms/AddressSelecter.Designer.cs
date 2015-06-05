namespace OutlookLyncAddIn.Forms
{
	partial class AddressSelecter
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.bt_ImSend = new System.Windows.Forms.Button();
			this.bt_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 19;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox1.Size = new System.Drawing.Size(436, 232);
			this.listBox1.TabIndex = 0;
			// 
			// bt_ImSend
			// 
			this.bt_ImSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_ImSend.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.bt_ImSend.Location = new System.Drawing.Point(454, 12);
			this.bt_ImSend.Name = "bt_ImSend";
			this.bt_ImSend.Size = new System.Drawing.Size(120, 29);
			this.bt_ImSend.TabIndex = 1;
			this.bt_ImSend.Text = "IM送信";
			this.bt_ImSend.UseVisualStyleBackColor = true;
			this.bt_ImSend.Click += new System.EventHandler(this.bt_ImSend_Click);
			// 
			// bt_Cancel
			// 
			this.bt_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_Cancel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.bt_Cancel.Location = new System.Drawing.Point(454, 47);
			this.bt_Cancel.Name = "bt_Cancel";
			this.bt_Cancel.Size = new System.Drawing.Size(120, 29);
			this.bt_Cancel.TabIndex = 2;
			this.bt_Cancel.Text = "キャンセル";
			this.bt_Cancel.UseVisualStyleBackColor = true;
			this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
			// 
			// AddressSelecter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 261);
			this.Controls.Add(this.bt_Cancel);
			this.Controls.Add(this.bt_ImSend);
			this.Controls.Add(this.listBox1);
			this.Name = "AddressSelecter";
			this.Text = "IM送信先選択";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddressSelecter_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button bt_ImSend;
		private System.Windows.Forms.Button bt_Cancel;
	}
}