using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void PassandoEmailExistente()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Jokerson";
        command.LastName = "Santos";
        command.Document = "99999999998";
        command.Email = "Jokerson@Jokerson.com.br";
        command.BarCode = "123456789";
        command.BoletoNumber = "1234654987";
        command.PaymentNumber = "123121";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Jokerson Student";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "Jokerson@Tests.com";
        command.Street = "Caja";
        command.Number = "12";
        command.Neighborhood = "Cajacity";
        command.City = "Salvador";
        command.State = "BA";
        command.Country = "BR";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.Valid);
    }

    public void PassandoDocumentoExistente()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Jokerson";
        command.LastName = "Santos";
        command.Document = "99999999999";
        command.Email = "Jokerson2@Jokerson.com.br";
        command.BarCode = "123456789";
        command.BoletoNumber = "1234654987";
        command.PaymentNumber = "123121";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Jokerson Student";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "Jokerson@Tests.com";
        command.Street = "Caja";
        command.Number = "12";
        command.Neighborhood = "Cajacity";
        command.City = "Salvador";
        command.State = "BA";
        command.Country = "BR";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.Valid);
    }
    public void RetorneSucessoSeNomeEEmailForNovo()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Jokerson";
        command.LastName = "Santos";
        command.Document = "99999999988";
        command.Email = "Jokerson2022@Jokerson.com.br";
        command.BarCode = "123456789";
        command.BoletoNumber = "1234654987";
        command.PaymentNumber = "123121";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Jokerson Student";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "Jokerson@Tests.com";
        command.Street = "Caja";
        command.Number = "12";
        command.Neighborhood = "Cajacity";
        command.City = "Salvador";
        command.State = "BA";
        command.Country = "BR";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(true, handler.Valid);
    }

}
