
var customers = new List<Customer>()
{
    new Customer { Age = 3, Name="Ann"},
    new Customer { Age = 16, Name="Bill"},
    new Customer { Age = 20, Name="Rose"},
    new Customer { Age = 14, Name="Rob"},
    new Customer { Age = 28, Name="Bill"},
    new Customer { Age = 14, Name="Jhon"},
};
var intList = new List<int>(){1,4,2,7,5,9,12,3,2,1};

bool contains = intList.Contains(3);
bool containsCustomer = customers.Contains(
    new Customer{Age=14, Name="Rob"},
    new CustomerComparer());

bool exists = customers.Exists(customer => customer.Age == 28);
int min = intList.Min();
int max = intList.Max();

int youngestCustomerAge = customers.Min(customer => customer.Age);
Customer bill = customers.Find(customer => customer.Name == "Bill");
Customer lastBill = customers.FindLast(customer => customer.Name == "Bill");
Customer lastBill2 = customers.Last(customer => customer.Name == "Bill");

List<Customer> adultCustomers = customers.FindAll(customer => customer.Age > 18);
IEnumerable<Customer> whereAge = customers.Where(customer => customer.Age > 18);

int indexOf = intList.LastIndexOf(2);

//from list
bool isTrueForAll = customers.TrueForAll(customer => customer.Age > 10);

//from linq
bool isTrueForAll2 = customers.All(customer => customer.Age > 10);

bool areThereAny = customers.Any(customer => customer.Age > 3);

Console.WriteLine($"contains: {contains}");
Console.WriteLine($"containsCustomer: {containsCustomer}");
Console.WriteLine($"exists: {exists}");
Console.WriteLine($"min: {min}, max: {max}");
Console.WriteLine($"youngestCustomerAge: {youngestCustomerAge}");
Console.WriteLine($"bill: {bill?.Name}");
Console.WriteLine($"lastBill: {lastBill?.Name}");
Console.WriteLine($"lastBill2: {lastBill2?.Name}");
Console.WriteLine($"adultCustomers: {adultCustomers.Count}");
Console.WriteLine($"whereAge: {whereAge.Count()}");
Console.WriteLine($"indexOf: {indexOf}");
Console.WriteLine($"isTrueForAll: {isTrueForAll}");
Console.WriteLine($"isTrueForAll2: {isTrueForAll2}");
Console.WriteLine($"areThereAny: {areThereAny}");

static bool Exists(int[] array, int number)
{
    for(int i=0; i < array.Length; i++)
    {
        if(array[i] == number)
            return true;
    }

    return false;
}

public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
}

public class CustomerComparer : IEqualityComparer<Customer>
{
    public bool Equals(Customer? x, Customer? y)
    {
        if (ReferenceEquals(x, y))
            return true;

        if (x is null || y is null)
            return false;

        return x.Age == y.Age && x.Name == y.Name;
    }

    public int GetHashCode(Customer obj)
    => HashCode.Combine(obj.Age, obj.Name);
}