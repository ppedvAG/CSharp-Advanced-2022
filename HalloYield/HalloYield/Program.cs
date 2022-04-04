// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");





foreach (var item in GetStrings())
{
    Console.WriteLine(item);
}

await foreach (var item in GetStringsAsync())
{
    Console.WriteLine(item);
}

IEnumerable<string> GetStrings()
{
    yield return "Hallo";
    yield return "World!";
    yield return "What's";
    yield return "up?";
}

async IAsyncEnumerable<string> GetStringsAsync()
{
    yield return "Hallo";
    await Task.Delay(1000);
    yield return "World!";
    await Task.Delay(1000);
    yield return "What's";
    await Task.Delay(1000);
    yield return "up?";
}


class Person
{
    public int Age { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? First { get; set; }

    public IEnumerable<string> Texts { get; set; } = new List<string>();
}
