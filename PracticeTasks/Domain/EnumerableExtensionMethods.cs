namespace Domain;

public static class EnumerableExtensionMethods
{
    public static IEnumerable<int> GenCombination(this IEnumerable<int> collection, int k, ElementsEqualityComparer comparer)
    {
        if (collection.Distinct(comparer).Count() != collection.Count())
            throw new ArgumentException("Values are repeated", nameof(collection));

        yield return 5;
    }
    
    public static IEnumerable<IEnumerable<int>> GenSubset(this IEnumerable<int> collection, ElementsEqualityComparer comparer)
    {
        if (collection.Distinct(comparer).Count() != collection.Count())
            throw new ArgumentException("Values are repeated", nameof(collection));
        
        var enumerable = collection as int[] ?? collection.ToArray();

        for (var i = 0; i < (1 << enumerable.Length); i++)
        {
            var result = Array.Empty<int>();

            var mask = i;
            
            foreach (var element in enumerable)
            {
                if ((mask & 1) == 1)
                {
                    result = result.Concat(new[] { element }).ToArray();
                }

                mask >>= 1;
            }

            yield return result;
        }
    }

    public static IEnumerable<IEnumerable<int>> GenPermutation(this IEnumerable<int> collection, ElementsEqualityComparer comparer)
    {
        if (collection.Distinct(comparer).Count() != collection.Count())
            throw new ArgumentException("Values are repeated", nameof(collection));
        
        var size = collection.Count();
        var a = new int[size];
        var p = new int[size];

        var yieldRet = new int[size];

        var list = new List<int>(collection);

        int i, j, tmp;

        for (i = 0; i < size; i++)
        {
            a[i] = i + 1; 
            p[i] = 0; 
        }
        
        for (var x = 0; x < size; x++)
        {
            yieldRet[x] = list[ a[x] - 1 ];
        }
        
        yield return yieldRet;
        
        i = 1;
        
        while (i < size)
        {
            if (p[i] < i)
            {
                j = i % 2 * p[i]; 
                tmp = a[j];
                a[j] = a[i];
                a[i] = tmp;

                for (var x = 0; x < size; x++)
                {
                    yieldRet[x] = list[ a[x] - 1 ];
                }
                yield return yieldRet;

                p[i]++; 
                i = 1;
            }
            else
            {
                p[i] = 0; 
                i++; 
            } 
        } 
    }
}