
using BigSorting;

var input = new string[]
{
    "000123",
    "00012322",
    "123983987390",
    "9872983712098371902837192087390",
    "998",
    "090982098012983092830",
    "121092831092831029830981209",
    "23",
    "09182309182309283",
    "09284759028473",
    "19092",
    "999876",
    "111190111222222222222244525342534534",
     "1", "3", "10", "3", "5"
};

static string[] BigSorting(string[] unsorted) 
{
    return unsorted.OrderBy(x => x,
        new BigIntegerStringComparer())
        .ToArray();
}

var result = BigSorting(input);

Console.WriteLine(string.Join(", ", input));
Console.WriteLine("==========================================");
Console.WriteLine("ORDERED");
Console.WriteLine("==========================================");
Console.WriteLine(string.Join("\n", result));
