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

			_inspectorTypeDropDown.Items.AddRange(_igz._vtableNameList.ToArray());

			offsetObjList = _igz._offsetObjectList.ToArray();

			HighlightRuntime(_igz._runtimeFields._vtables,   0xFFFF00);
			HighlightRuntime(_igz._runtimeFields._offsets,   0x00FFFF);
			HighlightRuntime(_igz._runtimeFields._stringRefs,   0xFF00FF);
			HighlightRuntime(_igz._runtimeFields._stringTables, 0xFF00FF);
			//HighlightRuntime(_igz._runtimePID, 0x00FF00);

			PopulateObjectTree();
		}

		private void HighlightRuntime(List<ulong> runtime, uint colour)
		{
			int length = igCore.GetSizeOfPointer(_igz._platform);

			System.Windows.Media.SolidColorBrush brush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(colour >> 16), (byte)(colour >> 8), (byte)colour));

			for(int i = 0; i < runtime.Count; i++)
			{
				_hexEditor.CustomBackgroundBlockItems.Add(new WpfHexaEditor.Core.CustomBackgroundBlock((long)runtime[i], length, brush));
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

		private void HexEditorCursorMoved(object sender, EventArgs e)
		{
			if(_igz._runtimeFields._vtables.Any(x => x == (ulong)_hexEditor.SelectionStart))
			{
				ulong vtableOffset = _igz._runtimeFields._vtables.First(x => x == (ulong)_hexEditor.SelectionStart);
				int vtableIndex = (int)_igz._stream.ReadUInt32((uint)vtableOffset);
				Console.WriteLine($"Selected object of type {_igz._vtableNameList[vtableIndex]} at {vtableOffset.ToString("X08")}");
				_inspectorTypeDropDown.SelectedIndex = vtableIndex;
			}
			if(_igz._runtimeFields._stringRefs.Any(x => x == (ulong)_hexEditor.SelectionStart))
			{
				ulong stringRefOffset = _igz._runtimeFields._stringRefs.First(x => x == (ulong)_hexEditor.SelectionStart);
				ulong stringOffset = _igz.DeserializeOffset(_igz._stream.ReadUInt32((uint)stringRefOffset));
				_inspectorStringTextBox.Text = _igz._stream.ReadString((uint)stringOffset);
			}
		}

		private void OnResize(object sender, EventArgs e)
		{
			_objectTree.Location = new Point(12, 40);
			_objectTree.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height / 2 - 30);
			_hexPanel.Location = new Point(ClientSize.Width / 2 + 6, _objectTree.Location.Y);
			_hexPanel.Size = new Size(ClientSize.Width / 2 - 18, ClientSize.Height - 52);
			_inspectorPanel.Location = new Point(12, ClientSize.Height / 2 + 20);
			_inspectorPanel.Size = _objectTree.Size;
		}
	}
}