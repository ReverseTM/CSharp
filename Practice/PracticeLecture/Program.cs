using PracticeDomain;

namespace PracticeLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //var obj = new OOPeDemo(10);
            //obj.MyField = 20;
            //Console.WriteLine(obj.MyField);

            //var obj1 = new Class1(16, "ь");
            //var obj2 = new Class1(213, "dick");
            //Console.WriteLine(obj1.Equals(obj2));

            //Class1 obj = new Class1(13, string.Empty);
            //Class1 obj1 = new Class1(14, string.Empty);
            
            //Console.WriteLine(obj.Equals((object)obj1));
            //Console.WriteLine(obj.Equals(obj1 as object));
            //Console.WriteLine(((IEquatable<object>)obj).Equals(obj1));

            //Dictionary<Class1, string> hashTable = new Dictionary<Class1, string>();
            //var key = new Class1(13, "123");
            //hashTable.Add(key, "1234");
            //Console.WriteLine(key);


            //TestClass objRef = new TestClassDerived(12, "1234");
            ////Console.WriteLine(objRef.Foo());
            //Console.WriteLine(objRef.Foo());

            //int valueByRef = 10;
            //RefInOutParamsDemo.NoRefValueDemo(valueByRef);
            //Console.WriteLine(valueByRef);
            //
            //RefInOutParamsDemo.RefValueDemo(ref valueByRef);
            //Console.WriteLine(valueByRef);
//
            //int valueByOut;
            //RefInOutParamsDemo.OutValueDemo(out valueByOut);
            //Console.WriteLine(valueByOut);

            //string refByRef = null;
            //RefInOutParamsDemo.NoRefStringDemo(refByRef);
            //Console.WriteLine(refByRef);
            //
            //RefInOutParamsDemo.RefStringDemo(ref refByRef);
            //Console.WriteLine(refByRef);
//
            //string refByOut;
            //RefInOutParamsDemo.OutStringDemo(out refByOut);
            //Console.WriteLine(refByOut);

            //try
            //{
            //    //RefInOutParamsDemo.Average(null);
            //    Console.WriteLine(RefInOutParamsDemo.Average(1, 2, 3, 4, 5, 6));
            //    Console.WriteLine(RefInOutParamsDemo.Average(new int[] { 1, 2, 3, 4, 5, 6 }));
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            
            //var ownArray = new OwnArray();
            //foreach (var item in ownArray)
            //{
            //    Console.WriteLine(item);
            //}



            var obj1 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);
            Console.WriteLine(obj1.SurnameValue);
            Console.WriteLine(obj1.NameValue);
            Console.WriteLine(obj1.PatronymicValue);
            Console.WriteLine(obj1.StudyGroupValue);
            Console.WriteLine(obj1.ChosenCourseValue);
            Console.WriteLine(obj1.CourseNumberValue);
            Console.WriteLine(obj1);

            var obj2 = new Student("Khasano", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);

            Dictionary<Student, string> hashTable = new Dictionary<Student, string>();
            hashTable.Add(obj1, "1234");
            Console.WriteLine(hashTable.Remove(obj1));

        }
    }
}
