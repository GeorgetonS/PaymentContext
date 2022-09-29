using Flunt.Validations;
using PaymentContext.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string fistName, string lastName)
    {
        FirstName = fistName;
        LastName = lastName;

        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirstName, 3,"Name.FirstName", "Nome deve conter pelo menos 3 Caracteres")
            .HasMinLen(LastName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 Caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
