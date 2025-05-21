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
        return FirstName.GetHashCode() ^ LastName.GetHashCode();
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    public int CompareTo(ContactData other)
    {
        if (object.ReferenceEquals(other, null))
        {
            return 1;
        }

        return firstName.CompareTo(other.FirstName) ^ lastName.CompareTo(other.FirstName);
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