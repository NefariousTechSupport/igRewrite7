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
			this._fileTab = new System.Windows.Forms.ToolStripMenuItem();
			this._objectTree = new System.Windows.Forms.TreeView();
			this._replaceFileButton = new System.Windows.Forms.Button();
			this._menuStrip.SuspendLayout();
			this.SuspendLayout();

			// 
			// _menuStrip
			// 
			this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._fileTab});
			this._menuStrip.Location = new System.Drawing.Point(0, 0);
			this._menuStrip.Name = "_menuStrip";
			this._menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this._menuStrip.Size = new System.Drawing.Size(788, 24);
			this._menuStrip.TabIndex = 17;
			this._menuStrip.Text = "_menuStrip";
			// 
			// _fileTab
			// 
			this._fileTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this._msiOpen
			});
			this._fileTab.Name = "_fileTab";
			this._fileTab.Size = new System.Drawing.Size(37, 20);
			this._fileTab.Text = "File";
			// 
			// _msiOpen
			// 
			this._msiOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this._msiOpenIGA
			});
			this._msiOpen.Name = "_msiOpen";
			this._msiOpen.Size = new System.Drawing.Size(37, 20);
			this._msiOpen.Text = "Open";
			// 
			// _msiOpenIGA
			// 
			this._msiOpenIGA.Name = "_msiOpenIGA";
			this._msiOpenIGA.Size = new System.Drawing.Size(37, 20);
			this._msiOpenIGA.Text = "IGA";
			//
			// _objectTree
			//
			this._objectTree.Name = "_objectTree";
			this._objectTree.Size = new System.Drawing.Size(300, 300);
			this._objectTree.Location = new System.Drawing.Point(12, 40);
			this._objectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectedFileNode);
			//
			// _replaceFileButton
			//
			this._replaceFileButton.Name = "_replaceFileButton";
			this._replaceFileButton.Size = new System.Drawing.Size(72, 23);
			this._replaceFileButton.Text = "Replace";

			this.Controls.Add(_menuStrip);
			this.Controls.Add(_objectTree);
			this.Controls.Add(_replaceFileButton);
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
	}
}
