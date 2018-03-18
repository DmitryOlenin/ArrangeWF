//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrangeWF;
using System.Collections.Generic;
using NUnit.Framework;

//https://travis-ci.org/DmitryOlenin/ArrangeWF

namespace UnitTest
{
    [TestFixture]
    public class NUnitTest
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

        [Test]
        public void CityAddTest()
        {

            // arrange

            var frm = new Form1();
            var hashFrom = new HashSet<string>();
            var hashTo = new HashSet<string>();
            var result = true;

            // act

            var randomList = frm.TestListAdd(100);
            for (int i = 0; i < randomList.Count; i++)
            {
                if (!hashFrom.Add(randomList[i].CityFrom) || !hashTo.Add(randomList[i].CityTo))
                {
                    result = false;
                    break;
                }
            }

            // assert

            Assert.IsTrue(result, @"Неверный алгоритм добавления городов");
        }

        [Test]
        public void CityRandomizeTest()
        {

            // arrange

            var frm = new Form1();

            // act

            var startList = frm.TestListAdd(100);
            var randList = new List<Form1.Card>(startList);
            var randomList = frm.TestListShuffle(randList);

            // assert

            CollectionAssert.AreNotEqual(startList, randomList, @"Неверный алгоритм рандомизации городов");
        }


    }
}
