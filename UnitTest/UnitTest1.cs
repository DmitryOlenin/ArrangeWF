//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrangeWF;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTest
{

    [TestFixture]
    public class NUnitDemo
    {
        [Test]
        public void CitySortingTest()
        {
            // arrange

            var frm = new Form1();
            var card1 = new Form1.Card { CityFrom = "Мельбурн", CityTo = "Кельн" };
            var card2 = new Form1.Card { CityFrom = "Москва", CityTo = "Париж" };
            var card3 = new Form1.Card { CityFrom = "Кельн", CityTo = "Москва" };
            var cards = new List<Form1.Card> { card1, card2, card3 };
            var cardsGood = new List<Form1.Card> { card1, card3, card2 };

            // act

            var cardsSorted = frm.arrange(cards);

            // assert

            //Assert.AreEqual(cardsGood, cardsSorted, @"Неверный алгоритм сортировки");
            CollectionAssert.AreEqual(cardsGood, cardsSorted, @"Неверный алгоритм сортировки");
        }
    }

    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void CitySortingTest()
    //    {
    //        // arrange

    //        var frm = new Form1();
    //        var card1 = new Form1.Card { CityFrom = "Мельбурн", CityTo = "Кельн" };
    //        var card2 = new Form1.Card { CityFrom = "Москва", CityTo = "Париж" };
    //        var card3 = new Form1.Card { CityFrom = "Кельн", CityTo = "Москва" };
    //        var cards = new List<Form1.Card> { card1, card2, card3 };
    //        var cardsGood = new List<Form1.Card> { card1, card3, card2 };

    //        // act

    //        var cardsSorted = frm.arrange(cards);

    //        // assert

    //        //Assert.AreEqual(cardsGood, cardsSorted, @"Неверный алгоритм сортировки");
    //        CollectionAssert.AreEqual(cardsGood, cardsSorted, @"Неверный алгоритм сортировки");

    //    }
    //}
}
