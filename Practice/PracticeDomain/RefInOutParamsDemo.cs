using System.ComponentModel.DataAnnotations;

namespace PracticeDomain;

public static class RefInOutParamsDemo
{
    // простая передача параметра не изменяет сам парамтр, а меняет его копию
    // ref принимает проинициализированный параметр и может изменить его
    // out может принимать непроинициализированный параметр и должен его проинициализировать
    
    public static void NoRefValueDemo(
        int value)
    {
        value = 20; //не меняет
    }
    
    public static void RefValueDemo(
        ref int value)
    {
        value = 20; //меняет
    }
    
    public static void OutValueDemo(
        out int value)
    {
        value = 20; //инициализирует
    }

    public static void NoRefStringDemo(
        string value)
    {
        value = nameof(NoRefStringDemo);
    }

    public static void RefStringDemo(
        ref string value)
    {
        value = nameof(RefStringDemo);
    }

    public static void OutStringDemo(
        out string value)
    {
        value = nameof(OutStringDemo);
    }
    
    /// <summary>
    /// Вычислить среднее арифметическое элементов.
    /// </summary>
    /// <param name="values"></param>
    /// <returns>Среднее арифметическое элементов</returns>
    /// <exception cref="ArgumentNullException">Ссылка на массив == null.</exception>
    /// <exception cref="ArgumentException">Массив имеет длину 0.</exception>
    public static double Average(
        params int[] values)
    {
        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        int lenght = values.Length;
        
        if (lenght == 0)
        {
            throw new ArgumentException(nameof(values));
        }

        int sum = 0;
        for (int i = 0; i < lenght; i++)
        {
            sum += values[i];
        }

        return (double)sum / lenght;
    }
}