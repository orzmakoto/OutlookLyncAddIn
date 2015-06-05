using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Extensibility;
using Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

// TODO:   リボン (XML) アイテムを有効にするには、次の手順に従います。

// 1: 次のコード ブロックを ThisAddin、ThisWorkbook、ThisDocument のいずれかのクラスにコピーします。

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new LyncConnect();
//  }

// 2. ボタンのクリックなど、ユーザーの操作を処理するためのコールバック メソッドを、このクラスの
//    "リボンのコールバック" 領域に作成します。メモ: このリボンがリボン デザイナーからエクスポートされたものである場合は、
//    イベント ハンドラー内のコードをコールバック メソッドに移動し、リボン拡張機能 (RibbonX) のプログラミング モデルで
//    動作するように、コードを変更します。

// 3. リボン XML ファイルのコントロール タグに、コードで適切なコールバック メソッドを識別するための属性を割り当てます。  

// 詳細については、Visual Studio Tools for Office ヘルプにあるリボン XML のドキュメントを参照してください。


namespace OutlookLyncAddIn
{
	[ComVisible(true)]
	public class LyncConnect : Office.IRibbonExtensibility
	{
		private Office.IRibbonUI ribbon;

		public LyncConnect()
		{
		}



		public void ShowMessageClick(Office.IRibbonControl control)
		{
			var recipientList = new List<SimpleRecipient>();
			{
				var explorer = Globals.ThisAddIn.Application.ActiveExplorer();
				//explorer.

				if (explorer.Selection.Count > 0)
				{
					Object selObject = explorer.Selection[1];
					if (selObject is Microsoft.Office.Interop.Outlook.MailItem)
					{
						var mailItem = selObject as Microsoft.Office.Interop.Outlook.MailItem;
						var sendExchangeUser = mailItem.Sender.GetExchangeUser();

						var newSenderImte = new SimpleRecipient()
						{
							Name = mailItem.SenderName,
							Address = mailItem.SenderEmailAddress,
							Type = 0
						};
						if (sendExchangeUser != null)
						{
							newSenderImte.Address = sendExchangeUser.PrimarySmtpAddress;
						}
						recipientList.Add(newSenderImte);
						foreach (var recipient in mailItem.Recipients.Cast<Recipient>())
						{
							ExchangeUser exchangeUser = recipient.AddressEntry.GetExchangeUser();
							string smtpAddress = recipient.Address;
							if (exchangeUser != null)
							{
								smtpAddress = exchangeUser.PrimarySmtpAddress;
							}
							if (smtpAddress.Contains("@") == true)
							{
								var newImte = new SimpleRecipient()
								{
									Name = recipient.Name,
									Address = smtpAddress,
									Type = recipient.Type
								};
								recipientList.Add(newImte);
							}
						}
					}
				}
			}


			var selecter = new Forms.AddressSelecter(recipientList);
			selecter.ShowDialog();
			if (selecter.DialogResult == DialogResult.Cancel || selecter.SelectedRecipient.Count == 0)
			{
				return;
			}
			// Create the major API automation object.
			Automation _Automation = LyncClient.GetAutomation();
			 

			// Create a generic List object to contain a contact URI.
			// Ensure that a valid URI is added.
			List<string> inviteeList = new List<string>();
			inviteeList.AddRange(selecter.SelectedRecipient.Select(i => i.Address));

			// Create text for the first IM message.
			string firstIMText = "hello";

			// Create a generic Dictionary object to contain conversation setting objects.
			Dictionary<AutomationModalitySettings, object> _ModalitySettings = new Dictionary<AutomationModalitySettings, object>();
			AutomationModalities _ChosenMode = AutomationModalities.InstantMessage;

			_ModalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMText);
			_ModalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately, true);

			// Start the conversation.
			IAsyncResult ar = _Automation.BeginStartConversation(
				_ChosenMode
				, inviteeList
				, _ModalitySettings
				, null
				, null);

			//Block UI thread until conversation is started
			_Automation.EndStartConversation(ar);
		}

		#region IRibbonExtensibility のメンバー

		public string GetCustomUI(string ribbonID)
		{
			if (ribbonID == "Microsoft.Outlook.Explorer")
			{
				return GetResourceText("OutlookLyncAddIn.LyncConnect.xml");
			}
			return "";
		}

		#endregion

		#region リボンのコールバック
		//ここにコールバック メソッドを作成します。コールバック メソッドの追加方法の詳細については、http://go.microsoft.com/fwlink/?LinkID=271226 にアクセスしてください。

		public void Ribbon_Load(Office.IRibbonUI ribbonUI)
		{
			this.ribbon = ribbonUI;
		}

		#endregion

		#region ヘルパー

		private static string GetResourceText(string resourceName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			string[] resourceNames = asm.GetManifestResourceNames();
			for (int i = 0; i < resourceNames.Length; ++i)
			{
				if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
				{
					using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
					{
						if (resourceReader != null)
						{
							return resourceReader.ReadToEnd();
						}
					}
				}
			}
			return null;
		}

		#endregion
	}
	[Serializable]
	public class SimpleRecipient
	{
		public string Name { get; set; }
		public string Address { get; set; }

		public int Type { get; set; }

		public string Domain
		{
			get
			{
				return Address.Split('@').Last();
			}
		}
		public string User
		{
			get
			{
				return Address.Split('@').First();
			}
		}

		public override string ToString()
		{
			return string.Format("{0}({1})", Name, Address);
		}
	}
}
