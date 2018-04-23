Imports Microsoft.VisualBasic
Imports System
Namespace ReadOnlyCollectionWrapper
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.grid = New DevExpress.XtraGrid.GridControl()
			Me.source = New DevExpress.Xpo.XPView()
			Me.session1 = New DevExpress.Xpo.Session()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.readOnlyCollectionWrapper1 = New DXSample.ReadOnlyCollectionWrapper()
			CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.source, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.session1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' grid
			' 
			Me.grid.DataSource = Me.readOnlyCollectionWrapper1
			Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.grid.Location = New System.Drawing.Point(0, 0)
			Me.grid.MainView = Me.gridView1
			Me.grid.Name = "grid"
			Me.grid.Size = New System.Drawing.Size(399, 268)
			Me.grid.TabIndex = 0
			Me.grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' source
			' 
			Me.source.ObjectType = GetType(DXSample.Person)
			Me.source.Properties.AddRange(New DevExpress.Xpo.ViewProperty() { New DevExpress.Xpo.ViewProperty("Name", DevExpress.Xpo.SortDirection.None, "[Name]", False, True)})
			Me.source.Session = Me.session1
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colName, Me.gridColumn1})
			Me.gridView1.GridControl = Me.grid
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.CustomUnboundColumnData += New DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(Me.gridView1_CustomUnboundColumnData);
			' 
			' colName
			' 
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.OptionsColumn.ReadOnly = True
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 0
			' 
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "Description"
			Me.gridColumn1.FieldName = "Description"
			Me.gridColumn1.Name = "gridColumn1"
			Me.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String
			Me.gridColumn1.Visible = True
			Me.gridColumn1.VisibleIndex = 1
			' 
			' readOnlyCollectionWrapper1
			' 
			Me.readOnlyCollectionWrapper1.DataSource = Me.source
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(399, 268)
			Me.Controls.Add(Me.grid)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.source, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.session1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private grid As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private source As DevExpress.Xpo.XPView
		Private session1 As DevExpress.Xpo.Session
		Private colName As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private readOnlyCollectionWrapper1 As DXSample.ReadOnlyCollectionWrapper
	End Class
End Namespace

