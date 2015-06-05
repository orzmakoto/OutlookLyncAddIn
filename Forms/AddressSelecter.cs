using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookLyncAddIn.Forms
{
	public partial class AddressSelecter : Form
	{
		public AddressSelecter(List<SimpleRecipient> recipients)
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			Recipients = recipients;
			SelectedRecipient = new List<SimpleRecipient>();
			base.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			Init();
		}
		public List<SimpleRecipient> Recipients { get; set; }
		public List<SimpleRecipient> SelectedRecipient { get; set; }
		private void Init()
		{
			foreach (var recipient in Recipients.OrderBy(i => i.Domain).ThenBy(i=> i.User))
			{
				listBox1.Items.Add(recipient);
			}
		}
		private void bt_ImSend_Click(object sender, EventArgs e)
		{
			this.SelectedRecipient = new List<SimpleRecipient>();
			foreach (var selected in listBox1.SelectedItems.Cast<SimpleRecipient>())
			{
				this.SelectedRecipient.Add(selected);
			}
			base.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void bt_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddressSelecter_FormClosing(object sender, FormClosingEventArgs e)
		{

		}
	}
}
