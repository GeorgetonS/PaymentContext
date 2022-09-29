using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Commands;
[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void RetorneErroSeONomeForInvalido()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Af";
        command.LastName = "Bo";

        command.Validate();
        Assert.AreEqual(false, command.Valid);
    }

    [TestMethod]
    public void RetorneSucessoSeONomeForValido()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Jokerson";
        command.LastName = "Santos";

        command.Validate();
        Assert.AreEqual(true, command.Valid);
    }
}
