namespace WebAddressBookTests;

public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
{
    private string firstName;
    private string lastName;

    public ContactData(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
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
        return $"{firstName} {lastName}";
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

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
}