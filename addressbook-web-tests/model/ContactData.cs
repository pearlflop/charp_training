namespace WebAddressBookTests;

public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
{
    public ContactData(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool Equals(ContactData other)
    {
        if (object.ReferenceEquals(other, null))
        {
            return false;
        }

        if (object.ReferenceEquals(this, other))
        {
            return true;
        }

        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return (FirstName + LastName).GetHashCode();
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public int CompareTo(ContactData other)
    {
        if (other == null) return 1;

        int result = LastName.CompareTo(other.LastName);
        if (result == 0)
        {
            result = FirstName.CompareTo(other.FirstName);
        }

        return result;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Id { get; set; }
}