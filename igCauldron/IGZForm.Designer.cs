namespace igCauldron
{
	partial class IGZForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._menuStrip = new System.Windows.Forms.MenuStrip();
			this._objectTree = new System.Windows.Forms.TreeView();
			this._replaceFileButton = new System.Windows.Forms.Button();
			this._hexPanel = new System.Windows.Forms.Panel();
			this._elementHost = new System.Windows.Forms.Integration.ElementHost();
			this._hexEditor = new WpfHexaEditor.HexEditor();
			this._inspectorTypeDropDown = new System.Windows.Forms.ComboBox();
			this._inspectorStringTextBox = new System.Windows.Forms.TextBox();
			this._inspectorPanel = new System.Windows.Forms.Panel();
			this._menuStrip.SuspendLayout();
			this.SuspendLayout();

			// 
			// _menuStrip
			// 
			this._menuStrip.Location = new System.Drawing.Point(0, 0);
			this._menuStrip.Name = "_menuStrip";
			this._menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this._menuStrip.Size = new System.Drawing.Size(788, 24);
			this._menuStrip.TabIndex = 17;
			this._menuStrip.Text = "_menuStrip";
			//
			// _objectTree
			//
			this._objectTree.Name = "_objectTree";
			this._objectTree.Size = new System.Drawing.Size(300, 300);
			this._objectTree.Location = new System.Drawing.Point(12, 40);
			this._objectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectedObjectNode);
			//
			// _replaceFileButton
			//
			this._replaceFileButton.Name = "_replaceFileButton";
			this._replaceFileButton.Size = new System.Drawing.Size(72, 23);
			this._replaceFileButton.Text = "Replace";
			//
			// _hexEditor
			//
			this._hexEditor.SelectionStartChanged += new System.EventHandler(this.HexEditorCursorMoved);
            // 
            // _elementHost
            // 
            this._elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this._elementHost.Location = new System.Drawing.Point(400, 40);
            this._elementHost.Name = "_elementHost";
            this._elementHost.Size = new System.Drawing.Size(400, 400);
            this._elementHost.Text = "_elementHost";
            this._elementHost.Child = this._hexEditor;
            // 
            // _hexPanel
            // 
            this._hexPanel.Dock = System.Windows.Forms.DockStyle.None;
            this._hexPanel.Location = new System.Drawing.Point(400, 40);
            this._hexPanel.Name = "_hexPanel";
            this._hexPanel.Size = new System.Drawing.Size(400, 400);
            this._hexPanel.Text = "_hexPanel";
            this._hexPanel.Controls.Add(_elementHost);
			//
			// _inspectorTypeDropDown
			//
			this._inspectorTypeDropDown.Location = new System.Drawing.Point(200, 12);
			this._inspectorTypeDropDown.Size = new System.Drawing.Size(300, 23);
			this._inspectorTypeDropDown.Name = "_inspectorTypeDropDown";
			//
			// _inspectorStringTextBox
			//
			this._inspectorStringTextBox.Location = new System.Drawing.Point(200, 47);
			this._inspectorStringTextBox.Size = new System.Drawing.Size(300, 23);
			this._inspectorStringTextBox.Name = "_inspectorTypeDropDown";
            // 
            // _inspectorPanel
            // 
            this._inspectorPanel.Dock = System.Windows.Forms.DockStyle.None;
            this._inspectorPanel.Location = new System.Drawing.Point(12, 400);
            this._inspectorPanel.Name = "_inspectorPanel";
            this._inspectorPanel.Size = new System.Drawing.Size(400, 400);
            this._inspectorPanel.Text = "_inspectorPanel";
			this._inspectorPanel.Controls.Add(this._inspectorTypeDropDown);
			this._inspectorPanel.Controls.Add(this._inspectorStringTextBox);
			this._inspectorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

			this.Controls.Add(_menuStrip);
			this.Controls.Add(_objectTree);
			this.Controls.Add(_replaceFileButton);
			this.Controls.Add(_hexPanel);
			this.Controls.Add(_inspectorPanel);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Text = "igCauldron IGZ Editor";
			this.Resize += new System.EventHandler(this.OnResize);
			this.MainMenuStrip = _menuStrip;
			this._menuStrip.ResumeLayout(false);
			this._menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		public System.Windows.Forms.MenuStrip _menuStrip;
		public System.Windows.Forms.ToolStripMenuItem _fileTab;
		public System.Windows.Forms.ToolStripMenuItem _msiOpen;
		public System.Windows.Forms.ToolStripMenuItem _msiOpenIGA;
		public System.Windows.Forms.TreeView _objectTree;
		public System.Windows.Forms.Button _replaceFileButton;
		public System.Windows.Forms.Panel _hexPanel;
		public System.Windows.Forms.Integration.ElementHost _elementHost;
		public WpfHexaEditor.HexEditor _hexEditor;
		public System.Windows.Forms.ComboBox _inspectorTypeDropDown;
		public System.Windows.Forms.TextBox _inspectorStringTextBox;
		public System.Windows.Forms.Panel _inspectorPanel;
	}
}
