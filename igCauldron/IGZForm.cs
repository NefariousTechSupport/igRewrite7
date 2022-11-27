using System.IO;
using igLibrary.Core;

namespace igCauldron
{
	public partial class IGZForm : Form
	{
		private igIGZ _igz;

		private int objIndex = 0;
		KeyValuePair<ulong, igObject>[] offsetObjList;

		public IGZForm(Stream igz)
		{
			InitializeComponent();

			igObjectDirectory dir = new igObjectDirectory();
			dir._path = "fakename.igz";

			_hexEditor.Stream = igz;
			_hexEditor.AllowAutoHighLightSelectionByte = false;
			_hexEditor.AllowAutoSelectSameByteAtDoubleClick = false;

			dir.ReadFile(igObjectDirectory.FileType.kIGZ, igz, false);
			_igz = dir._loader;
			offsetObjList = _igz._offsetObjectList.ToArray();

			HighlightRuntime(_igz._runtimeVtableList, System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0x00));

			PopulateObjectTree();
		}

		private void HighlightRuntime(List<ulong> runtime, System.Windows.Media.Color colour)
		{
			int length = igCore.GetSizeOfPointer(_igz._platform);

			_hexEditor.HighLightColor = new System.Windows.Media.SolidColorBrush(colour);

			for(int i = 0; i < runtime.Count; i++)
			{
				_hexEditor.AddHighLight((long)runtime[i], length, true);
			}
		}

		private void PopulateObjectTree()
		{
			for(int i = 0; i < _igz._dir._objectList._count; i++)
			{
				TreeNode objNode = AddObjectNode(_objectTree.Nodes, _igz._dir._objectList[i]);
				PopulateObjectNode(objNode.Nodes, _igz._dir._objectList[i]);
			}
		}

		private void PopulateObjectNode(TreeNodeCollection collection, igObject obj)
		{
			igObject[] references = obj.GetReferencedObjects();
			for(int i = 0; i < references.Length; i++)
			{
				TreeNode objNode = AddObjectNode(collection, references[i]);
				PopulateObjectNode(objNode.Nodes, references[i]);
			}
		}

		private TreeNode AddObjectNode(TreeNodeCollection collection, igObject obj)
		{
			string typeName;
			if(obj is igFakeObject fo)
			{
				typeName = fo._typeName;
			}
			else
			{
				typeName = obj.GetType().Name;
			}
			return collection.Add($"{(Array.FindIndex<KeyValuePair<ulong, igObject>>(offsetObjList, x => x.Value == obj)).ToString("X04")}: {typeName}");
		}
		private void SelectedObjectNode(object sender, TreeViewEventArgs e)
		{
			string hexIndex = _objectTree.SelectedNode.Text.Split(':')[0];
			int index = int.Parse(hexIndex, System.Globalization.NumberStyles.HexNumber);
			_hexEditor.SetPosition((long)offsetObjList[index].Key, offsetObjList[index].Value.GetSizeofSize(_igz._version, _igz._platform));
			_objectTree.Focus();
		}

		private void OnResize(object sender, EventArgs e)
		{
			_objectTree.Location = new Point(12, 40);
			_objectTree.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height / 2 - 36);
			_hexPanel.Location = new Point(ClientSize.Width / 2 + 6, _objectTree.Location.Y);
			_hexPanel.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height - 52);
			_inspectorPanel.Location = new Point(12, ClientSize.Height / 2 + 26);
			_inspectorPanel.Size = _objectTree.Size;
		}
	}
}