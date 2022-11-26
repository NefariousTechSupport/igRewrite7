using igLibrary.Core;

namespace igCauldron
{
	public partial class IGZForm : Form
	{
		private igIGZ _igz;
		public IGZForm(Stream igz)
		{
			InitializeComponent();

			igObjectDirectory dir = new igObjectDirectory();
			dir.ReadFile(false);
		}

		private void SelectedFileNode(object sender, TreeViewEventArgs e)
		{
		}

		private void OnResize(object sender, EventArgs e)
		{
			_objectTree.Location = new Point(12, 40);
			_objectTree.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height - 52);
		}
	}
}