using PaymentContext.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string fistName, string lastName)
    {
        FistName = fistName;
        LastName = lastName;
    }

    public string FistName { get; private set; }
    public string LastName { get; private set; }
}
