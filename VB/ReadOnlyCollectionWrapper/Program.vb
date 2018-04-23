Imports Microsoft.VisualBasic
Imports System
Imports DXSample
Imports System.Data
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Windows.Forms

Namespace ReadOnlyCollectionWrapper
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			XpoDefault.DataLayer = New SimpleDataLayer(New InMemoryDataStore(New DataSet(), AutoCreateOption.DatabaseAndSchema))
			CreateData()
			Application.Run(New Form1())
		End Sub

		Private Shared Sub CreateData()
			Using uow As New UnitOfWork()
				Dim person As New Person(uow)
				person.Name = "John"
				person = New Person(uow)
				person.Name = "Bob"
				uow.CommitChanges()
			End Using
		End Sub
	End Class
End Namespace