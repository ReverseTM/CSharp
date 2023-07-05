using PracticeDomain;

namespace PracticeLecture
{
    class Program
    {
        private static IEnumerable<int> GetCollection()
        {
            yield return 1;
            yield return 2;
            yield return -13;
            yield return 48;
            yield return 11;
            yield return 27;
            foreach (var item in new[] {1, 2, 3 ,4})
            {
                yield return item;
            }
        }

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


            //try
            //{
            //    var obj1 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);
            //    Console.WriteLine(obj1.SurnameValue);
            //    Console.WriteLine(obj1.NameValue);
            //    Console.WriteLine(obj1.PatronymicValue);
            //    Console.WriteLine(obj1.StudyGroupValue);
            //    Console.WriteLine(obj1.ChosenCourseValue);
            //    Console.WriteLine(obj1.CourseNumberValue);
            //    Console.WriteLine(obj1);
//
            //    var obj2 = new Student("Hasanov", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);
//
            //    Dictionary<Student, string> hashTable = new Dictionary<Student, string>();
            //    hashTable.Add(obj1, "1234");
            //    Console.WriteLine(hashTable.Remove(obj1));
//
            //    var obj3 = new Student("Petrov", null, "Petrovich", "М8О-311Б-20", Student.Course.Yandex);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            var myArray = new OwnArray<TestClass>();
            myArray
                .Insert(new TestClassDerived(1, "123"), 0)
                .Insert(new TestClassDerived(2, "123"), 0)
                .Insert(new TestClassDerived(-3, "123"), 0)
                .Insert(new TestClassDerived(4, "123"), 0)
                .Insert(new TestClassDerived(7, "234"), 1)
                .Insert(new TestClassDerived(8, "345"), 0)
                .Insert(new TestClassDerived(3, "456"), 1)
                .Insert(new TestClassDerived(4, "567"), 3)
                .FindByIndex(3, out var foundByIndexValue);

            foreach (var item in myArray)
            {
                Console.WriteLine($"{item} ");
            }

            //myArray.Sort(TestClassComparer.Instance);
            //Console.WriteLine(myArray);

            //var dictionary = new Dictionary<TestClass, string>(TestClassEqualityComparer.Instance);
            //dictionary.Add(new TestClassDerived(25, "123"), "");
            //dictionary.Add(new TestClassDerived(24, "123"), "");

            var array = GetCollection()
                .Where(x => x % 2 == 0)
                .Select(x => x / 2)
                .ToArray();
            
            foreach (var item in array)
            {
                Console.WriteLine($"{item} ");
            }
        }
    }
}
