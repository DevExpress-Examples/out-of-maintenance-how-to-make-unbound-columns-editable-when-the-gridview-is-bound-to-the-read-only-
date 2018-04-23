using System;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;

namespace ReadOnlyCollectionWrapper {
    public partial class Form1 :Form {
        List<string> descriptions;

        public Form1() {
            InitializeComponent();
            descriptions = new List<string>();
            for (int i = 0; i < source.Count; i++)
                descriptions.Add(string.Empty);
        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            if (descriptions == null) return;
            if (e.IsGetData) e.Value = descriptions[e.ListSourceRowIndex];
            else descriptions[e.ListSourceRowIndex] = (string)e.Value;
        }
    }
}