using ReflectionSample;
using System;
using System.Reflection;

Console.Title = "Learning Reflection";

// HowToGetTheTypeInstance()
// TypeTesting();
//AssemblyPresentation();
//AssemblyPresentation("System.Text.Json");
//PersonTypePresentation();

static void HowToGetTheTypeInstance()
{
    object name = "Camilo";

    // Gets the System.Type of the current instance.
    // (The exact runtime Type of the current instance)
    // It's useful when you have an instance
    Type stringType = name.GetType();
    Console.WriteLine(stringType);
    Console.WriteLine(stringType.FullName); // ToString() implementation
    Console.ReadLine();

    // Gets the System.Type of the provided type
    // It's useful when you do not have an instance
    Type stringType2 = typeof(string);
    Console.WriteLine(stringType);
    Console.WriteLine(stringType.FullName); // ToString() implementation
    Console.ReadLine();
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
static void TypeTesting()
{
    object ex = new Exception();

    Console.WriteLine(
        $"{nameof(ex)} object's type is {ex.GetType().Name}: {ex is Exception}");

    Console.WriteLine(
        $"{nameof(ex)} object's type is {typeof(SystemException).Name}: {ex is SystemException}");

    object systemEx = new SystemException();

    Console.WriteLine(
        $"{nameof(systemEx)} object's type is {nameof(Exception)}: {ex is Exception}");

    Console.WriteLine(
        $"{nameof(systemEx)} object's type is {nameof(SystemException)}: {ex is SystemException}");
}

static void AssemblyPresentation(string? assemblyName = null)
{
    Assembly assembly;

    if (assemblyName == null)
        assembly = Assembly.GetExecutingAssembly();
    else
        assembly = Assembly.Load(assemblyName);

    Console.WriteLine($"Hello, from your host: " +
        $"{assembly}");

    Console.WriteLine("The modules from this assembly are: ");
    Module[] modulesFromAssembly = assembly.GetModules();
    foreach (var module in modulesFromAssembly)
    {
        Console.WriteLine(module);
    }
    Console.WriteLine();

    Module firstModule = modulesFromAssembly[0];
    Console.WriteLine($"The modules from the first module: {firstModule} are: ");
    Type[] typesFromFirstModule = firstModule.GetTypes();
    foreach (var module in typesFromFirstModule)
    {
        Console.WriteLine(module);
    }
    Console.WriteLine();

    Type[] typesFromCurrentAssembyly = assembly.GetTypes();

    Console.WriteLine("The types from the assembly are: ");
    foreach (var type in typesFromCurrentAssembyly)
    {
        Console.WriteLine(type);
    }
    Console.WriteLine();
}

static void PersonTypePresentation()
{
    Type personType = typeof(Person);
    Console.WriteLine("My public constructors are:");
    foreach (ConstructorInfo constructor in personType.GetConstructors())
    {
        Console.WriteLine(constructor);
        //var personTypeAgain = constructor.DeclaringType;
        //Console.WriteLine(personTypeAgain);
    }
    Console.WriteLine();
    // Once you specified a binding flag you'll have to
    // Specified all

    Console.WriteLine("My instance methods (included non public) are: ");
    foreach (MethodInfo method in personType.GetMethods(
        BindingFlags.Instance |
        BindingFlags.Public |
        BindingFlags.NonPublic))
    {
        Console.WriteLine($"{method}, public: {method.IsPublic}");
    }
    Console.WriteLine();

    Console.WriteLine("My private instance fields are: ");
    foreach (FieldInfo field in personType.GetFields(
        BindingFlags.Instance |
        BindingFlags.NonPublic))
    {
        Console.WriteLine($"{field}, public: {field.IsPublic}");
    }
    Console.WriteLine();
}