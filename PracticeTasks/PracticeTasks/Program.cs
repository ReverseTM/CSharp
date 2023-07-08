using Domain;
using Sorting;

namespace PracticeTasks;

class Program
{
        static void Main(string[] args)
    {
        #region TASK1

        //try
        //{
        //    var student1 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-213Б-21", Student.Course.CSharp);
//
        //    var student2 = new Student("Khasanov", "Daniil", "Rafailovich", "М8О-311Б-20", Student.Course.CSharp);
        //    
        //    Console.WriteLine($"Student1 equal student2: {student1.Equals(student2)}");
        //    Console.WriteLine($"Сourse chosen by the student1 equal chosen course student2: {student1.Equals(student2.ChosenCourseValue)}");
        //    
        //    Console.WriteLine($"Student1 surname: {student1.SurnameValue}");
        //    Console.WriteLine($"Student1 name: {student1.NameValue}");
        //    Console.WriteLine($"Student1 patronymic: {student1.PatronymicValue}");
        //    Console.WriteLine($"Student1 study group: {student1.StudyGroupValue}");
        //    Console.WriteLine($"Student1 chosen course: {student1.ChosenCourseValue}");
        //    Console.WriteLine($"Course number: {student1.CourseNumberValue}");
        //    
        //    Console.WriteLine($"Student2: {student2}");
//
        //    var student3 = new Student("Petrov", "Petr", "Petrovich", null, Student.Course.InfrastructureActivities);
        //}
        //catch (ArgumentNullException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        #endregion TASK1

        #region TASK2

        #region Combination
        
        // try
        // {
        //     var resultGenCombination = new int[] { 1, 2, 3}.GenCombination(3 ,ElementsEqualityComparer<int>.Instance);
        //
        //     foreach (var set in resultGenCombination)
        //     { 
        //         var array = set.ToArray();
        //         
        //         Console.Write("[");
        //         
        //         for (var i = 0; i < array?.Length; i++)
        //         {
        //             if (i == array.Length - 1) Console.Write(array[i]);
        //             else Console.Write($"{array[i]}, ");
        //         }
        //         
        //         Console.WriteLine("]");
        //     }
        // }
        // catch (ArgumentException ex)
        // {
        //         Console.WriteLine(ex.Message);
        // }
        // catch (Exception ex)
        // {
        //         Console.WriteLine(ex.Message);
        // }
        
        #endregion Combination

        #region Subset

        // try
        // {
        //     var resultGenSubset = new int[] { 1, 2 }.GenSubset(ElementsEqualityComparer<int>.Instance);
        //
        //     foreach (var set in resultGenSubset)
        //     {
        //         var array = set.ToArray();
        //
        //         Console.Write("[");
        //
        //         for (var i = 0; i < array?.Length; i++)
        //         {
        //             if (i == array.Length - 1) Console.Write(array[i]);
        //             else Console.Write($"{array[i]}, ");
        //         }
        //
        //         Console.WriteLine("]");
        //     }
        // }
        // catch (ArgumentException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }

        #endregion Subset

        #region Permutation

        // try
        // {
        //     var resultGenPermutation = new int[] { 1, 2, 3}.GenPermutation(ElementsEqualityComparer<int>.Instance);
        //
        //     foreach (var permutation in resultGenPermutation)
        //     {
        //         var array = permutation.ToArray();
        //     
        //         Console.Write("[");
        //
        //         for (var i = 0; i < array?.Length; i++)
        //         {
        //             if (i == array.Length - 1) Console.Write(array[i]);
        //             else Console.Write($"{array[i]}, ");
        //         }
        //     
        //         Console.WriteLine("]");
        //     }
        // }
        // catch (ArgumentException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }

        #endregion Permutation

        #endregion TASK2

        #region TASK3

        try
        {
            Comparison<IntAndString> cmp = IntAndStringComparer.Compare;

            var numbers = new[]
            {
                new IntAndString(3, "123"), new IntAndString(1, "234"), new IntAndString(2, "345"),
                new IntAndString(1, "456")
            };

            numbers.Sort(ASort<IntAndString>.SortingMode.Ascending, new MergeSort<IntAndString>());

            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
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

        #endregion TASK3
    }
}
