using System.IO;
using igLibrary.Core;

namespace igCauldron
{
	public partial class MainForm : Form
	{
		public igArchive? _archive;
		public Dictionary<uint, TreeNode> _fileHashTable = new Dictionary<uint, TreeNode>();

		public MainForm()
		{
			InitializeComponent();
		}

		private void ClickedOpenIGA(object sender, EventArgs e) => OpenIGA();
		public void OpenIGA()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = false;
			ofd.Filter = "Archives|*.arc;*.bld;*.pak;*.iga|All Files|*.*";
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine($"Opening IGA {ofd.FileName}");
				if(_archive != null)
				{
					_archive.Close();
				}
				_archive = new igArchive(File.Open(ofd.FileName, FileMode.Open, FileAccess.Read));
				GenerateNodesFromFilePathList();
			}
		}
		private void ClickedOpenIGZ(object sender, EventArgs e) => OpenIGZ();
		public void OpenIGZ()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = false;
			ofd.Filter = "igObjectDirectory files|*.igz;*.lang;*.bld;*.pak|All Files|*.*";
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine($"Opening IGZ {ofd.FileName}");
				IGZForm igzForm = new IGZForm(ofd.OpenFile());
				igzForm.Show();
			}
		}
		public void GenerateNodesFromFilePathList()
		{
			if(_archive == null) return;

			_fileTree.Nodes.Clear();
			_fileHashTable.Clear();
			bool caseInsensitive = (_archive.flags & 1) != 0;

			for(int i = 0; i < _archive.fileHeaders.Length; i++)
			{
				TreeNodeCollection current = _fileTree.Nodes;
				string[] parts = _archive.fileHeaders[i].name.Split('/', '\\');
				for(int j = 0; j < parts.Length; j++)
				{
					string stringToFind = parts[j];
					if(caseInsensitive) stringToFind = stringToFind.ToLower();

					TreeNode[] nodes = current.Find(stringToFind, false);
					if(nodes.Length == 0)
					{
						TreeNode node = current.Add(stringToFind, stringToFind);
						current = node.Nodes;
						if(j == parts.Length - 1)
						{
							_fileHashTable.Add(_archive.fileHeaders[i].hash, node);
						}
					}
					else
					{
						current = nodes[0].Nodes;
					}
				}
			}
		}
		private void SelectedFileNode(object sender, TreeViewEventArgs e)
		{
			if(_fileTree.SelectedNode.Nodes.Count == 0)
			{
				_fileNameLabel.Text = _fileTree.SelectedNode.Text;
				_fileNameLabel.Visible = true;
				_extractFileButton.Enabled = true;
				_extractFileButton.Visible = true;
				_replaceFileButton.Visible = true;
				_replaceFileButton.Enabled = true;
			}
			else
			{
				_fileNameLabel.Visible = false;
				_extractFileButton.Enabled = false;
				_extractFileButton.Visible = false;
				_replaceFileButton.Visible = false;
				_replaceFileButton.Enabled = false;
			}
		}

		private void ClickedExtractButton(object sender, EventArgs e)
		{
			uint hash = GetSelectedFileHash();
			if(hash == 0) throw new InvalidOperationException("No file selected");

			if(_archive == null) return;

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = _fileNameLabel.Text;
			if(sfd.ShowDialog() == DialogResult.OK)
			{
				Stream s = sfd.OpenFile();
				_archive.ExtractFile(hash, s);
				s.Flush();
				s.Close();
			}
		}
		private uint GetSelectedFileHash()
		{
			KeyValuePair<uint, TreeNode>[] files = _fileHashTable.ToArray();
			int index = Array.FindIndex<KeyValuePair<uint, TreeNode>>(files, 0, files.Length, x => x.Value == _fileTree.SelectedNode);
			if(index < 0) return 0;
			return files[index].Key;
		}
		private void OnResize(object sender, EventArgs e)
		{
			_fileTree.Location = new Point(12, 40);
			_fileTree.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height - 52);

			_fileNameLabel.Location = new Point(ClientSize.Width / 2 + 6, 40);
			_extractFileButton.Location = new Point(ClientSize.Width / 2 + 6, 72);
			_replaceFileButton.Location = new Point(_extractFileButton.Location.X + _extractFileButton.Size.Width + 12, _extractFileButton.Location.Y);
		}
	}
}