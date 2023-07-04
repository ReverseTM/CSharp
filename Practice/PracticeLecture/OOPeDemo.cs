namespace PracticeLecture
{
    public class OOPeDemo
    {
        private int _myField;
        private string _myString;

        public OOPeDemo(
            int myField)
        {
            _myField = myField;
        }

        public void Foo()
        {
            Console.WriteLine("где лабы");
        }

        public int MyField1
        {
            get; 
            protected set;
        }

        public string Prop => _myString;

        public string PropSet
        {
            set => _myString = value;
        }
        
        public int MyField
        {
            get
            {
                return _myField;
            }

            set
            {
                _myField = value;
            }
        }
    }
}