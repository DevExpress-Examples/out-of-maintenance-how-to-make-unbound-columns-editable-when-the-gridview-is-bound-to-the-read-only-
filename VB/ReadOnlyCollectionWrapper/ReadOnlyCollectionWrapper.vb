Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace DXSample
	Friend Class ReadOnlyCollectionWrapper
		Inherits Component
		Implements IBindingList, ITypedList
		Private Shared ReadOnly fListChanged As Object = New Object()

		Public Sub New(ByVal dataSource As IBindingList)
			fDataSource = dataSource
		End Sub

		Public Sub New()
		End Sub

		Private fDataSource As IBindingList
		<AttributeProvider(GetType(IListSource))> _
		Public Property DataSource() As IBindingList
			Get
				Return fDataSource
			End Get
			Set(ByVal value As IBindingList)
				If fDataSource Is value Then
					Return
				End If
				If fDataSource IsNot Nothing Then
					RemoveHandler fDataSource.ListChanged, AddressOf OnDataSourceListChanged
				End If
				fDataSource = value
				If fDataSource IsNot Nothing Then
					AddHandler fDataSource.ListChanged, AddressOf OnDataSourceListChanged
				End If
				RaiseListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
			End Set
		End Property

		Private Sub RaiseListChanged(ByVal args As ListChangedEventArgs)
			Dim handler As ListChangedEventHandler = TryCast(Events(fListChanged), ListChangedEventHandler)
			If handler IsNot Nothing Then
				handler(Me, args)
			End If
		End Sub

		Private Sub OnDataSourceListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
			RaiseListChanged(e)
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If fDataSource IsNot Nothing Then
					RemoveHandler fDataSource.ListChanged, AddressOf OnDataSourceListChanged
					fDataSource = Nothing
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "IBindingList Members"

		Private Sub AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex
			fDataSource.AddIndex([property])
		End Sub

		Private Function AddNew() As Object Implements IBindingList.AddNew
			Throw New NotSupportedException()
		End Function

		Private ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
			Get
				Return True
			End Get
		End Property

		Private ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
			Get
				Return False
			End Get
		End Property

		Private ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
			Get
				Return False
			End Get
		End Property

		Private Sub ApplySort(ByVal [property] As PropertyDescriptor, ByVal direction As ListSortDirection) Implements IBindingList.ApplySort
			fDataSource.ApplySort([property], direction)
		End Sub

		Private Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
			Return fDataSource.Find([property], key)
		End Function

		Private ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
			Get
				Return fDataSource.IsSorted
			End Get
		End Property

		Private Custom Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged
			AddHandler(ByVal value As ListChangedEventHandler)
				Events.AddHandler(fListChanged, value)
			End AddHandler
			RemoveHandler(ByVal value As ListChangedEventHandler)
				Events.RemoveHandler(fListChanged, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
			End RaiseEvent
		End Event

		Private Sub RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex
			fDataSource.RemoveIndex([property])
		End Sub

		Private Sub RemoveSort() Implements IBindingList.RemoveSort
			fDataSource.RemoveSort()
		End Sub

		Private ReadOnly Property IBindingList_SortDirection() As ListSortDirection Implements IBindingList.SortDirection
			Get
				Return fDataSource.SortDirection
			End Get
		End Property

		Private ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
			Get
				Return fDataSource.SortProperty
			End Get
		End Property

		Private ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
			Get
				Return fDataSource.SupportsChangeNotification
			End Get
		End Property

		Private ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
			Get
				Return fDataSource.SupportsSearching
			End Get
		End Property

		Private ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
			Get
				Return fDataSource.SupportsSorting
			End Get
		End Property

		#End Region

		#Region "IList Members"

		Private Function Add(ByVal value As Object) As Integer Implements IList.Add
			Return fDataSource.Add(value)
		End Function

		Private Sub Clear() Implements IList.Clear
			fDataSource.Clear()
		End Sub

		Private Function Contains(ByVal value As Object) As Boolean Implements IList.Contains
			Return fDataSource.Contains(value)
		End Function

		Private Function IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf
			Return fDataSource.IndexOf(value)
		End Function

		Private Sub Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert
			fDataSource.Insert(index, value)
		End Sub

		Private ReadOnly Property IsFixedSize() As Boolean Implements IList.IsFixedSize
			Get
				Return fDataSource.IsFixedSize
			End Get
		End Property

		Private ReadOnly Property IsReadOnly() As Boolean Implements IList.IsReadOnly
			Get
				Return False
			End Get
		End Property

		Private Sub Remove(ByVal value As Object) Implements IList.Remove
			fDataSource.Remove(value)
		End Sub

		Private Sub RemoveAt(ByVal index As Integer) Implements IList.RemoveAt
			fDataSource.RemoveAt(index)
		End Sub

		Public Property IList_Item(ByVal index As Integer) As Object Implements IList.Item
			Get
				Return fDataSource(index)
			End Get
			Set(ByVal value As Object)
				fDataSource(index) = value
			End Set
		End Property

		#End Region

		#Region "ICollection Members"

		Private Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo
			fDataSource.CopyTo(array, index)
		End Sub

		Private ReadOnly Property Count() As Integer Implements ICollection.Count
			Get
				Return fDataSource.Count
			End Get
		End Property

		Private ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
			Get
				Return fDataSource.IsSynchronized
			End Get
		End Property

		Private ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
			Get
				Return fDataSource.SyncRoot
			End Get
		End Property

		#End Region

		#Region "IEnumerable Members"

		Private Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return fDataSource.GetEnumerator()
		End Function

		#End Region

		#Region "ITypedList Members"

		Private Function GetItemProperties(ByVal listAccessors() As PropertyDescriptor) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
			Dim tList As ITypedList = TryCast(fDataSource, ITypedList)
			Dim properties As PropertyDescriptorCollection
			If tList Is Nothing Then
				If fDataSource.Count = 0 OrElse listAccessors IsNot Nothing Then
					properties = New PropertyDescriptorCollection(New PropertyDescriptor(){})
				Else
					properties = TypeDescriptor.GetProperties(fDataSource(0))
				End If
			Else
				properties = (CType(fDataSource, ITypedList)).GetItemProperties(listAccessors)
			End If
			Dim result As New List(Of PropertyDescriptor)()
			For Each [property] As PropertyDescriptor In properties
				result.Add(New ReadOnlyPropertyDescriptor([property]))
			Next [property]
			Return New PropertyDescriptorCollection(result.ToArray())
		End Function

		Private Function GetListName(ByVal listAccessors() As PropertyDescriptor) As String Implements ITypedList.GetListName
			Dim tList As ITypedList = TryCast(fDataSource, ITypedList)
			If tList Is Nothing Then
				If fDataSource.Count = 0 OrElse listAccessors IsNot Nothing Then
					Return String.Empty
				Else
					Return fDataSource(0).GetType().Name
				End If
			End If
			Return (CType(fDataSource, ITypedList)).GetListName(listAccessors)
		End Function

		#End Region
	End Class

	Public Class ReadOnlyPropertyDescriptor
		Inherits PropertyDescriptor
		Private fDescriptor As PropertyDescriptor

		Public Sub New(ByVal descr As PropertyDescriptor)
			MyBase.New(descr)
			fDescriptor = descr
		End Sub

		Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
			Return False
		End Function

		Public Overrides ReadOnly Property ComponentType() As Type
			Get
				Return fDescriptor.ComponentType
			End Get
		End Property

		Public Overrides Function GetValue(ByVal component As Object) As Object
			Return fDescriptor.GetValue(component)
		End Function

		Public Overrides ReadOnly Property IsReadOnly() As Boolean
			Get
				Return True
			End Get
		End Property

		Public Overrides ReadOnly Property PropertyType() As Type
			Get
				Return fDescriptor.PropertyType
			End Get
		End Property

		Public Overrides Sub ResetValue(ByVal component As Object)
			Throw New NotSupportedException()
		End Sub

		Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
			Throw New NotSupportedException()
		End Sub

		Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
			Return fDescriptor.ShouldSerializeValue(component)
		End Function
	End Class
End Namespace
