using System.Text;

namespace PracticeDomain;

public abstract class TestClass :
    IEquatable<string>,
    IEquatable<int>,
    IEquatable<TestClass>,
    IEquatable<object>,
    IComparable,
    IComparable<TestClass>
{
    // const, readonly
    // ref, out, in, parans
    
    
    private const int IntValueDefault = 15;
    private const string StringValueDefault = " ";
    private static readonly object SomeObject;

    static TestClass()
    {
        //конструктор для статических полей

        SomeObject = new object();
    }
    public TestClass(int @int = IntValueDefault, string @string = StringValueDefault)
    {
        IntValue = @int;
        StringValue = @string ?? throw new ArgumentNullException(nameof(@string));
    }

    public int IntValue
    {
        get;

        //init;
    }

    public string StringValue
    {
        get;

        //init;
    }
    
    public bool Equals(string @string)
    {
        return StringValue.Equals(@string);
    }

    public bool Equals(int @int)
    {
        return IntValue.Equals(@int);
    }

    public bool Equals(TestClass mgl)
    {
        if (mgl == null)
        {
            return false;
        }

        return IntValue == mgl.IntValue && StringValue.Equals(mgl.StringValue);
    }
    
    public override bool Equals(object? obj)
    {
        Console.WriteLine("Base type");
        
        if (obj == null)
        {
            return false;
        }

        if (obj is TestClass mgl)
        {
            return Equals(mgl);
        }
        if (obj is string @string)
        {
            return StringValue.Equals(@string);
        }
        if (obj is int @int)
        {
            return IntValue.Equals(@int);
        }
        
        return false;
    }
    
    // Explicit interface implementation
    bool IEquatable<object>.Equals(object? obj)
    {
        Console.WriteLine("IEquatable<object>");

        if (obj == null)
        {
            return false;
        }

        if (obj is TestClass mgl)
        {
            return Equals(mgl);
        }
        if (obj is string @string)
        {
            return StringValue.Equals(@string);
        }
        if (obj is int @int)
        {
            return IntValue.Equals(@int);
        }
        
        return false;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if (obj is TestClass mgl)
        {
            return CompareTo(mgl);
        }

        throw new ArgumentException("Can't perform comparison operation", nameof(obj));
    }

    public int CompareTo(TestClass? obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        return IntValue.CompareTo(obj.IntValue);
    }
    
    public override int GetHashCode()
    {
        return StringValue.GetHashCode() * 23 + IntValue.GetHashCode();
    }

    public override string ToString()
    {
        // WORST
        //return "[ StringValue: " + StringValue + ", IntValue: " + IntValue + " ]";
        
        // AVG
        //return new StringBuilder("[ StringValue: ")
        //    .Append(StringValue)
        //    .Append(", IntValue: ")
        //    .Append(IntValue)
        //    .Append(" ]")
        //    .ToString();
        
        // BEST
        return $"[ StringValue: {StringValue}, IntValue: {IntValue} ]";
    }

    public virtual string Foo()
    {
        return "Foo from base class";
    }

    public abstract void SomeMethod();
}

public sealed class TestClassDerived : TestClass
{
    public TestClassDerived(int @int, string @string) : base(@int, @string)
    {
        
    }

    public static TestClassDerived operator +(
        TestClassDerived? left,
        TestClassDerived? right)
    {
        if (left is null) throw new ArgumentNullException(nameof(left));

        if (right is null) throw new ArgumentNullException(nameof(right));

        return new TestClassDerived(left.IntValue + right.IntValue, left.StringValue + right.StringValue);
    }
    
    public override string Foo()
    {
        return "Foo from derived class";
    }

    public override void SomeMethod()
    {
        throw new NotImplementedException();
    }
} 