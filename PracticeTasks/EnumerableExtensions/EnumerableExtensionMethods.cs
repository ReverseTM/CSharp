namespace EnumerableExtensions;

public static class EnumerableExtensionMethods
{

    private static IEnumerable<IEnumerable<T>> GetAllCombination<T>(this IEnumerable<T> collection, int k)
    {
        return k == 0 ? new[] { Array.Empty<T>() } :
            collection.SelectMany((e, i) =>
                collection.Skip(i).GetAllCombination(k - 1).Select(c => (new[] {e}).Concat(c)));
    }

    public static IEnumerable<IEnumerable<T>> GenCombination<T>(this IEnumerable<T> collection, int k, IEqualityComparer<T>? comparer)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        
        ThrowIfNotDistinct(collection, comparer);

        foreach (var item in GetAllCombination(collection, k))
        {
            yield return item;
        }
    }
    
    public static IEnumerable<IEnumerable<T>> GenSubset<T>(this IEnumerable<T>? collection, IEqualityComparer<T>? comparer)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        
        ThrowIfNotDistinct(collection, comparer);

        var enumerable = collection.ToArray();

        var result = Enumerable
            .Range(0, 1 << enumerable.Length)
            .Select(index => enumerable.Where((type, element) => (index & (1 << element)) != 0).ToArray());

        foreach (var item in result)
        {
            yield return item;
        }
    }

    private static IEnumerable<IEnumerable<T>> GetAllPermutation<T>(this IEnumerable<T> collection)
    {
        if (collection.Count() == 1)
            return new[] { collection };            
 
        return collection.SelectMany(v => GetAllPermutation(collection.Where(x => !x.Equals(v))), (v, p) => p.Prepend(v));
    }
    
    public static IEnumerable<IEnumerable<T>> GenPermutation<T>(this IEnumerable<T>? collection, IEqualityComparer<T>? comparer)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        
        ThrowIfNotDistinct(collection, comparer);

        foreach (var item in GetAllPermutation(collection))
        {
            yield return item;
        }
    }

    private static void ThrowIfNotDistinct<T>(
        this IEnumerable<T> values,
        IEqualityComparer<T> equalityComparer)
    {
        if (values.Distinct(equalityComparer).Count() != values.Count())
            throw new ArgumentException("Values are repeated", nameof(values));
    }
}