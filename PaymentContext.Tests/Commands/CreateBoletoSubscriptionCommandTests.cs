using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Commands;
[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void ReturneErroSeONomeForInvalido()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "";
        command.Validate();
        Assert.AreEqual(false, command.Valid);
    }
}
