var phone1 = new PhoneNumber { AreaCode = "011", Exchange = "4555", Number = "1234" };
var phone2 = new PhoneNumber { AreaCode = "011", Exchange = "4555", Number = "1234" };
var phone3 = new PhoneNumber { AreaCode = "011", Exchange = "4555", Number = "5678" };

Console.WriteLine($"phone1.Equals(phone2): {phone1.Equals(phone2)}");                                   // true (mismos datos)
Console.WriteLine($"phone1 != phone3: {phone1 != phone3}");                                             // true (datos distintos)
Console.WriteLine($"phone1.GetHashCode() == phone2.GetHashCode(): {phone1.GetHashCode() == phone2.GetHashCode()}"); // true (objetos "iguales" -> mismo hash)
Console.WriteLine($"phone1.GetHashCode() == phone3.GetHashCode(): {phone1.GetHashCode() == phone3.GetHashCode()}"); // false (objetos distintos -> hash distinto)

public class PhoneNumber
{
    public string AreaCode { get; set; }
    public string Exchange { get; set; }
    public string Number { get; set; }

    override public bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return string.Equals(AreaCode, ((PhoneNumber)obj).AreaCode) &&
               string.Equals(Exchange, ((PhoneNumber)obj).Exchange) &&
               string.Equals(Number, ((PhoneNumber)obj).Number);
    }

    public static bool operator != (PhoneNumber left, PhoneNumber right)
    {
        if (ReferenceEquals(left, null))
            return ReferenceEquals(right, null);

        if(ReferenceEquals(null, left))
            return false;

        return !(left.Equals(right));
    }

    override public int GetHashCode()
    {
        unchecked
        {
            const int hashingBase = (int) 2166136261;
            const int hashingMultiplier = 16777619;

            int hash = hashingBase;
            hash = (hash * hashingMultiplier) ^ (AreaCode?.GetHashCode() ?? 0);
            hash = (hash * hashingMultiplier) ^ (Exchange?.GetHashCode() ?? 0);
            hash = (hash * hashingMultiplier) ^ (Number?.GetHashCode() ?? 0);
            return hash;
        }
        
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Ssn { get; set; }
}