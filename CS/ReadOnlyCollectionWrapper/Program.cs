using System;
using DXSample;
using System.Data;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Windows.Forms;

namespace ReadOnlyCollectionWrapper {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore(new DataSet(), AutoCreateOption.DatabaseAndSchema));
            CreateData();
            Application.Run(new Form1());
        }

        static void CreateData() {
            using (UnitOfWork uow = new UnitOfWork()) {
                Person person = new Person(uow);
                person.Name = "John";
                person = new Person(uow);
                person.Name = "Bob";
                uow.CommitChanges();
            }
        }
    }
}