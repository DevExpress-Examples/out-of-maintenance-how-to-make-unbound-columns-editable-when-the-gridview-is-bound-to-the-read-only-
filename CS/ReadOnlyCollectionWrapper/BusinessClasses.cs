using DevExpress.Xpo;

namespace DXSample {
    public class Person :XPObject {
        public Person(Session session) : base(session) { }

        private string fName;
        public string Name {
            get {
                return fName;
            }
            set {
                SetPropertyValue("Name", ref fName, value);
            }
        }
    }
}