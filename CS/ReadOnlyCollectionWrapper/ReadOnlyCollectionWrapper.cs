using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

namespace DXSample {
    class ReadOnlyCollectionWrapper :Component, IBindingList, ITypedList {
        static readonly object fListChanged = new object();

        public ReadOnlyCollectionWrapper(IBindingList dataSource) {
            fDataSource = dataSource;
        }

        public ReadOnlyCollectionWrapper() { }

        IBindingList fDataSource;
        [AttributeProvider(typeof(IListSource))]
        public IBindingList DataSource {
            get { return fDataSource; }
            set {
                if (fDataSource == value) return;
                if (fDataSource != null)
                    fDataSource.ListChanged -= OnDataSourceListChanged;
                fDataSource = value;
                if (fDataSource != null)
                    fDataSource.ListChanged += OnDataSourceListChanged;
                RaiseListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        void RaiseListChanged(ListChangedEventArgs args) {
            ListChangedEventHandler handler = Events[fListChanged] as ListChangedEventHandler;
            if (handler != null)
                handler(this, args);
        }

        void OnDataSourceListChanged(object sender, ListChangedEventArgs e) {
            RaiseListChanged(e);
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                if (fDataSource != null) {
                    fDataSource.ListChanged -= OnDataSourceListChanged;
                    fDataSource = null;
                }
            base.Dispose(disposing);
        }

        #region IBindingList Members

        void IBindingList.AddIndex(PropertyDescriptor property) {
            fDataSource.AddIndex(property);
        }

        object IBindingList.AddNew() {
            throw new NotSupportedException();
        }

        bool IBindingList.AllowEdit {
            get { return true; }
        }

        bool IBindingList.AllowNew {
            get { return false; }
        }

        bool IBindingList.AllowRemove {
            get { return false; }
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) {
            fDataSource.ApplySort(property, direction);
        }

        int IBindingList.Find(PropertyDescriptor property, object key) {
            return fDataSource.Find(property, key);
        }

        bool IBindingList.IsSorted {
            get { return fDataSource.IsSorted; }
        }

        event ListChangedEventHandler IBindingList.ListChanged {
            add { Events.AddHandler(fListChanged, value); }
            remove { Events.RemoveHandler(fListChanged, value); }
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property) {
            fDataSource.RemoveIndex(property);
        }

        void IBindingList.RemoveSort() {
            fDataSource.RemoveSort();
        }

        ListSortDirection IBindingList.SortDirection {
            get { return fDataSource.SortDirection; }
        }

        PropertyDescriptor IBindingList.SortProperty {
            get { return fDataSource.SortProperty; }
        }

        bool IBindingList.SupportsChangeNotification {
            get { return fDataSource.SupportsChangeNotification; }
        }

        bool IBindingList.SupportsSearching {
            get { return fDataSource.SupportsSearching; }
        }

        bool IBindingList.SupportsSorting {
            get { return fDataSource.SupportsSorting; }
        }

        #endregion

        #region IList Members

        int IList.Add(object value) {
            return fDataSource.Add(value);
        }

        void IList.Clear() {
            fDataSource.Clear();
        }

        bool IList.Contains(object value) {
            return fDataSource.Contains(value);
        }

        int IList.IndexOf(object value) {
            return fDataSource.IndexOf(value);
        }

        void IList.Insert(int index, object value) {
            fDataSource.Insert(index, value);
        }

        bool IList.IsFixedSize {
            get { return fDataSource.IsFixedSize; }
        }

        bool IList.IsReadOnly {
            get { return false; }
        }

        void IList.Remove(object value) {
            fDataSource.Remove(value);
        }

        void IList.RemoveAt(int index) {
            fDataSource.RemoveAt(index);
        }

        object IList.this[int index] {
            get { return fDataSource[index]; }
            set { fDataSource[index] = value; }
        }

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index) {
            fDataSource.CopyTo(array, index);
        }

        int ICollection.Count {
            get { return fDataSource.Count; }
        }

        bool ICollection.IsSynchronized {
            get { return fDataSource.IsSynchronized; }
        }

        object ICollection.SyncRoot {
            get { return fDataSource.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
            return fDataSource.GetEnumerator();
        }

        #endregion

        #region ITypedList Members

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors) {
            ITypedList tList = fDataSource as ITypedList;
            PropertyDescriptorCollection properties;
            if (tList == null)
                if (fDataSource.Count == 0 || listAccessors != null) properties = new PropertyDescriptorCollection(new PropertyDescriptor[0]);
                else properties = TypeDescriptor.GetProperties(fDataSource[0]);
            else
                properties = ((ITypedList)fDataSource).GetItemProperties(listAccessors);
            List<PropertyDescriptor> result = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor property in properties)
                result.Add(new ReadOnlyPropertyDescriptor(property));
            return new PropertyDescriptorCollection(result.ToArray());
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors) {
            ITypedList tList = fDataSource as ITypedList;
            if (tList == null)
                if (fDataSource.Count == 0 || listAccessors != null) return string.Empty;
                else return fDataSource[0].GetType().Name;
            return ((ITypedList)fDataSource).GetListName(listAccessors);
        }

        #endregion
    }

    public class ReadOnlyPropertyDescriptor :PropertyDescriptor {
        private PropertyDescriptor fDescriptor;

        public ReadOnlyPropertyDescriptor(PropertyDescriptor descr) : base(descr) {
            fDescriptor = descr;
        }

        public override bool CanResetValue(object component) {
            return false;
        }

        public override Type ComponentType {
            get { return fDescriptor.ComponentType; }
        }

        public override object GetValue(object component) {
            return fDescriptor.GetValue(component);
        }

        public override bool IsReadOnly {
            get { return true; }
        }

        public override Type PropertyType {
            get { return fDescriptor.PropertyType; }
        }

        public override void ResetValue(object component) {
            throw new NotSupportedException();
        }

        public override void SetValue(object component, object value) {
            throw new NotSupportedException();
        }

        public override bool ShouldSerializeValue(object component) {
            return fDescriptor.ShouldSerializeValue(component);
        }
    }
}
