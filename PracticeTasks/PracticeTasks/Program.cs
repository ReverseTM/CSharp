using Domain;
using Sorting;
using EnumerableExtensions;
using IntegrationMethods;
using List;

namespace PracticeTasks;

class Program
{

    private static void Task1()
    {
        try
        {
            var student1 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);

            var student2 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-311Б-20", Student.Course.CSharp);
            
            Console.WriteLine($"Student1 equal student2: {student1.Equals(student2)}");
            Console.WriteLine($"Сourse chosen by the student1 equal chosen course student2: {student1.Equals(student2.ChosenCourseValue)}");
            
            Console.WriteLine($"Student1 surname: {student1.SurnameValue}");
            Console.WriteLine($"Student1 name: {student1.NameValue}");
            Console.WriteLine($"Student1 patronymic: {student1.PatronymicValue}");
            Console.WriteLine($"Student1 study group: {student1.StudyGroupValue}");
            Console.WriteLine($"Student1 chosen course: {student1.ChosenCourseValue}");
            Console.WriteLine($"Course number: {student1.CourseNumberValue}");
            
            Console.WriteLine($"Student2: {student2}");

            var student3 = new Student("Petrov", "Petr", "Petrovich", null, Student.Course.InfrastructureActivities);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Task2()
    {
        #region Combination

        try
        {
            var resultGenCombination = new int[] { 1, 2, 3 }.GenCombination(3, ElementsEqualityComparer<int>.Instance);

            foreach (var set in resultGenCombination)
            {
                var array = set.ToArray();

                Console.Write("[");
                for (var i = 0; i < array?.Length; i++)
                {
                    if (i == array.Length - 1) Console.Write(array[i]);
                    else Console.Write($"{array[i]}, ");
                }

                Console.WriteLine("]");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        #endregion Combination

        #region Subset

        try
        {
            var resultGenSubset = new int[] { 1, 2, 3 }.GenSubset(ElementsEqualityComparer<int>.Instance);
        
            foreach (var set in resultGenSubset)
            {
                var array = set.ToArray();
        
                Console.Write("[");
                for (var i = 0; i < array?.Length; i++)
                {
                    if (i == array.Length - 1) Console.Write(array[i]);
                    else Console.Write($"{array[i]}, ");
                }
                Console.WriteLine("]");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        #endregion Subset

        #region Permutation

        try
        {
            var resultGenPermutation = new int[] { 1, 2, 3}.GenPermutation(ElementsEqualityComparer<int>.Instance);
        
            foreach (var permutation in resultGenPermutation)
            {
                var array = permutation.ToArray();
            
                Console.Write("[");
                for (var i = 0; i < array?.Length; i++)
                {
                    if (i == array.Length - 1) Console.Write(array[i]);
                    else Console.Write($"{array[i]}, ");
                }
                Console.WriteLine("]");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        #endregion Permutation
    }

    private static void Task3()
    {
        try
        {
            Comparison<IntAndString> cmp = IntAndStringComparer.Compare;

            var numbers = new[]
            {
                new IntAndString(3, "123"), new IntAndString(1, "234"), new IntAndString(2, "345"),
                new IntAndString(1, "456"), new IntAndString(-25, "123"), new IntAndString(0, "999")
            };

            
            // 1 CASE
            Console.WriteLine("InsertionSort");
            
            numbers.Sort(ASort<IntAndString>.SortingMode.Ascending, new InsertionSort<IntAndString>());
            
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);
            
            // 2 CASE
            Console.WriteLine("SelectionSort");
            
            numbers.Sort(ASort<IntAndString>.SortingMode.Descending, new SelectionSort<IntAndString>(), IntAndStringComparer.Instance);
            
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);
            
            // 3 CASE
            Console.WriteLine("HeapSort");
            
            numbers.Sort(ASort<IntAndString>.SortingMode.Ascending, new HeapSort<IntAndString>(), (IComparer<IntAndString>)IntAndStringComparer.Instance);
            
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);
            
            // 4 CASE
            Console.WriteLine("QuickSort");
            
            numbers.Sort(ASort<IntAndString>.SortingMode.Descending, new QuickSort<IntAndString>(), cmp);
            
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("MergeSort");
            
            numbers.Sort(ASort<IntAndString>.SortingMode.Descending, new MergeSort<IntAndString>());
            
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Task4()
    {
        double Function(double x) => x / (x - 1);

        var leftRectanglesMethod = new LeftRectanglesMethod();
        var rightRectanglesMethod = new RightRectanglesMethod();
        var middleRectanglesMethod = new MiddleRectanglesMethod();
        var trapezoidalMethod = new TrapezoidalMethod();
        var parabolaMethod = new ParabolaMethod();

        var iterationsCount = new Dictionary<string, int>();
        var leadTime = new Dictionary<string, long>();
        
        const double precision = 0.0000001;

        const int ticksInMilliSecond = 10000;

        try
        {
            Console.WriteLine(
                $"{leftRectanglesMethod.MethodName}: {leftRectanglesMethod.Сalculate(Function, 4, 10, precision)} ");
            iterationsCount.Add(leftRectanglesMethod.MethodName, leftRectanglesMethod.IterationsCount);
            leadTime.Add(leftRectanglesMethod.MethodName, leftRectanglesMethod.Time);

            Console.WriteLine(
                $"{rightRectanglesMethod.MethodName}: {rightRectanglesMethod.Сalculate(Function, 4, 10, precision)} ");
            iterationsCount.Add(rightRectanglesMethod.MethodName, rightRectanglesMethod.IterationsCount);
            leadTime.Add(rightRectanglesMethod.MethodName, rightRectanglesMethod.Time);

            Console.WriteLine(
                $"{middleRectanglesMethod.MethodName}: {middleRectanglesMethod.Сalculate(Function, 4, 10, precision)} ");
            iterationsCount.Add(middleRectanglesMethod.MethodName, middleRectanglesMethod.IterationsCount);
            leadTime.Add(middleRectanglesMethod.MethodName, middleRectanglesMethod.Time);

            Console.WriteLine(
                $"{trapezoidalMethod.MethodName}: {trapezoidalMethod.Сalculate(Function, 4, 10, precision)} ");
            iterationsCount.Add(trapezoidalMethod.MethodName, trapezoidalMethod.IterationsCount);
            leadTime.Add(trapezoidalMethod.MethodName, trapezoidalMethod.Time);

            Console.WriteLine($"{parabolaMethod.MethodName}: {parabolaMethod.Сalculate(Function, 4, 10, precision)} ");
            iterationsCount.Add(parabolaMethod.MethodName, parabolaMethod.IterationsCount);
            leadTime.Add(parabolaMethod.MethodName, parabolaMethod.Time);

            var sortedIterationCount = from element in iterationsCount orderby element.Value ascending select element;
            var sortedLeadTime = from element in leadTime orderby element.Value ascending select element;

            Console.WriteLine($"{Environment.NewLine}Number of method iterations");
            var index = 1;
            foreach (var item in sortedIterationCount)
            {
                Console.WriteLine($"{index}) {item.Key}: {item.Value}");
            }

            Console.WriteLine($"{Environment.NewLine}Elapsed time of methods (in ticks)");
            index = 1;
            foreach (var item in sortedLeadTime)
            {
                Console.WriteLine($"{index}) {item.Key}: {item.Value}");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Task5()
    {
        try
        {
            var list = new List.LinkedList<int>();

            list.PushBack(1).PushBack(2).PushBack(3).Reverse();
            
            //list.PushFront(1).PushFront(2).PushFront(3);

            var x = 10;

            Console.WriteLine(list.First);
            Console.WriteLine(list.Last);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    static void Main(string[] args)
    {
        //Task1();
        //Task2();
        //Task3();
        //Task4();
        
        Task5();
    }
}
