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
            #region RefInOutParams

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

            #endregion RefInOutParams

            #region OwnArray

            //var ownArray = new OwnArray();
            //foreach (var item in ownArray)
            //{
            //    Console.WriteLine(item);
            //}

            // var myArray = new OwnArray<TestClass>();
           // myArray
           //     .Insert(new TestClassDerived(1, "123"), 0)
           //     .Insert(new TestClassDerived(2, "123"), 0)
           //     .Insert(new TestClassDerived(-3, "123"), 0)
           //     .Insert(new TestClassDerived(4, "123"), 0)
           //     .Insert(new TestClassDerived(7, "234"), 1)
           //     .Insert(new TestClassDerived(8, "345"), 0)
           //     .Insert(new TestClassDerived(3, "456"), 1)
           //     .Insert(new TestClassDerived(4, "567"), 3)
           //     .FindByIndex(3, out var foundByIndexValue);

            //foreach (var item in myArray)
            //{
            //    Console.WriteLine($"{item} ");
            //}
        
            //myArray.Sort(TestClassComparer.Instance);
            //Console.WriteLine(myArray);

            //var dictionary = new Dictionary<TestClass, string>(TestClassEqualityComparer.Instance);
            //dictionary.Add(new TestClassDerived(25, "123"), "");
            //dictionary.Add(new TestClassDerived(24, "123"), "");

            //var array = GetCollection()
            //     .Where(x => x % 2 == 0)
            //     .DivideBy2()
            //     .ToArray();
//
            //foreach (var item in array)
            //{
            //    Console.WriteLine($"{item} ");
            //}

            #endregion OwnArray

            #region Delegates

            EqComparer<string> dlg = Subscriber;
            dlg += Subscriber2;
            dlg += delegate(string? value1, string? value2)
            {
                if (ReferenceEquals(value1, null) && ReferenceEquals(value2, null)) return true;

                if (ReferenceEquals(value1, null)) return false;

                if (ReferenceEquals(value2, null)) return false;
                
                return value1.Equals(value2, StringComparison.Ordinal);
            };
            Delegates(dlg);

            #endregion Delegates

            #region Actions

            

            #endregion Actions
        }

        #region ForDelegates

        private static bool Subscriber(string? str1, string? str2)
        {
            Console.WriteLine($"{Environment.NewLine}Subscriber method work ...");

            return true;
        }
        
        private static bool Subscriber2(string? str1, string? str2)
        {
            Console.WriteLine($"Subscriber2 method work ...");

            return false;
        }
        
        private static void Delegates(EqComparer<string> dlg)
        {
            var result =  dlg?.Invoke(null, null);
            Console.WriteLine(result);
        }
        
        public delegate bool EqComparer<in T>(T? obj1, T? obj2);

        #endregion ForDelegates

        #region ForActions

        private static void DelegateVsEventDemoDemo()
        {
            var obj = new DelegateVsEventDemo();
            
            obj.Action += (@int, @string) =>
            {
                Console.WriteLine("Lambda subscriber work ...");
            };
            
            obj.Action += delegate(int @int, string @string)
            {
                Console.WriteLine("Anonymous function work ...");
            };
        }

        #endregion ForActions
    }
}
