using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;


namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    //Red - 
    //Green - 
    //Refactor - 
    private readonly Name _name;

    private readonly Document _document;

    private readonly Address _address;

    private readonly Email _email;

    private readonly Student _student;

    public StudentTests()
    {
        _name = new Name("Jokerson", "Santos");
        _document = new Document("44645422048", EDocumentType.CPF);
        _email = new Email("Jokerson@Aluno.com");
        _address = new Address("Rua 1", "123", "Cajacity", "Salvador", "Ba", "Brasil", "41340100");
        _student = new Student(_name, _document, _email, _address);       
    }

    [TestMethod]
    public void RetornarErroAoATivarSubscription()
    {
        var subscription = new Subscription(null);
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Jokerson CORP", _document, _address, _email);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void RetornarErroAoSeNaoTiverPagamento()
    {
        var subscription = new Subscription(null);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void RetornarSucessoAoAdicionarSubscription()
    {
        var subscription = new Subscription(null);
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Jokerson CORP", _document, _address, _email);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.Valid);
    }
}
