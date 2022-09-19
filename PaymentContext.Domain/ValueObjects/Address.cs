using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract()
        .Requires()
        .HasMinLen(Street, 3, "Address.Street", " rua deve conter pelo menos 3 Caracteres")
        .HasMinLen(Number, 1, "Address.Number", "O numero deve conter pelo menos 1 Caracteres")
        .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "O Bairro deve conter pelo menos 3 Caracteres")
        .HasMinLen(City, 3, "Address.City", "A cidade deve conter pelo menos 3 Caracteres")
        .HasMinLen(State, 3, "Address.State", "O estado deve conter pelo menos 3 Caracteres")
        .HasMinLen(Country, 3, "Address.Country", "Cidade deve conter pelo menos 3 Caracteres")
        .HasMinLen(ZipCode, 8, "Address.ZipCode", "CEP deve conter pelo menos 8 Caracteres")
);
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}
