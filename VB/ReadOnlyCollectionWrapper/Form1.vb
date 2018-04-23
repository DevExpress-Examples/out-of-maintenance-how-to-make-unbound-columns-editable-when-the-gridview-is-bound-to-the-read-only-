Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Views.Base

Namespace ReadOnlyCollectionWrapper
	Partial Public Class Form1
		Inherits Form
		Private descriptions As List(Of String)

		Public Sub New()
			InitializeComponent()
			descriptions = New List(Of String)()
			For i As Integer = 0 To source.Count - 1
				descriptions.Add(String.Empty)
			Next i
		End Sub

		Private Sub gridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
			If descriptions Is Nothing Then
				Return
			End If
			If e.IsGetData Then
				e.Value = descriptions(e.ListSourceRowIndex)
			Else
				descriptions(e.ListSourceRowIndex) = CStr(e.Value)
			End If
		End Sub
	End Class
End Namespace