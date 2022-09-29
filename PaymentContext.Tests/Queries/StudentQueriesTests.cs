using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Queries;
[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        _students = new List<Student>();
        for (var i = 0; i <= 10; i++)
        {
            _students.Add(new Student(
                new Name("Aluno", i.ToString()),
                new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                new Email(i.ToString() + "@Jokerson.com.br"),
                new Address("Caja", "12", "Cajacity", "Salvador", "BA", "BR","12345678")
            ));
        }
    }

    [TestMethod]
    public void RetorneVazioSeoDocumentoNaoExistir()
    {
        var exp = StudentQueries.GetStudentInfo("12345678911");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, studn);
    }

    [TestMethod]
    public void RetorneOEstudanteSeoDocumentoExistir()
    {
        var exp = StudentQueries.GetStudentInfo("11111111111");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null, studn);
    }
}
