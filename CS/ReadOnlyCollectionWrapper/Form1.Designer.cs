namespace ReadOnlyCollectionWrapper {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.source = new DevExpress.Xpo.XPView();
            this.session1 = new DevExpress.Xpo.Session();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.readOnlyCollectionWrapper1 = new DXSample.ReadOnlyCollectionWrapper();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.DataSource = this.readOnlyCollectionWrapper1;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(399, 268);
            this.grid.TabIndex = 0;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // source
            // 
            this.source.ObjectType = typeof(DXSample.Person);
            this.source.Properties.AddRange(new DevExpress.Xpo.ViewProperty[] {
            new DevExpress.Xpo.ViewProperty("Name", DevExpress.Xpo.SortDirection.None, "[Name]", false, true)});
            this.source.Session = this.session1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.gridColumn1});
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Description";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // readOnlyCollectionWrapper1
            // 
            this.readOnlyCollectionWrapper1.DataSource = this.source;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 268);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Xpo.XPView source;
        private DevExpress.Xpo.Session session1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DXSample.ReadOnlyCollectionWrapper readOnlyCollectionWrapper1;
    }
}

