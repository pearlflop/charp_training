using System.Text.RegularExpressions;
using OpenQA.Selenium.DevTools.V135.CSS;

namespace WebAddressBookTests;

public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
{
    private string allPhones;
    private string allEmails;

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

    public string Address { get; set; }

    public string HomePhone { get; set; }

    public string MobilePhone { get; set; }

    public string WorkPhone { get; set; }

    public string Email1 { get; set; }

    public string Email2 { get; set; }

    public string Email3 { get; set; }

    public string AllPhones
    {
        get
        {
            if (allPhones != null)
            {
                return allPhones;
            }
            else
            {
                return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
            }
        }
        set { allPhones = value; }
    }

    public string AllEmails
    {
        get
        {
            if (allEmails != null)
            {
                return allEmails;
            }
            else
            {
                return (CleanUpEmail(Email1) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
            }
        }

        set { allEmails = value; }
    }


    private string CleanUpPhone(string phone)
    {
        if (phone == null || phone == "")
        {
            return "";
        }

        return Regex.Replace(phone, "[ -()]", "") + Environment.NewLine;
    }

    private string CleanUpEmail(string email)
    {
        if (email == null || email == "")
        {
            return "";
        }

        return Regex.Replace(email, "[ -()]", "") + Environment.NewLine;
    }

    public string Id { get; set; }
}