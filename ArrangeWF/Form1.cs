using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ArrangeWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        interface ICard
        {
            string CityFrom { get; set; } // Город # 1
            string CityTo { get; set; } // Город # 2
        }

        public class Card : ICard, IEquatable<Card>
        {
            public string CityFrom { get; set; }
            public string CityTo { get; set; }

            public bool Equals(Card other)
            {
                if (other == null)
                    return false;

                return string.Equals(CityFrom, other.CityTo,
                           StringComparison.Ordinal);
            }
        }
       
        private void b_start_Click(object sender, EventArgs e)
        {
            var cards = new List<Card>();
            b_start.Enabled = false;

            Benchmark.Start();

            var nudCnt = nud_city.Value + 1; //Алгоритм рандомной генерации уменьшает города на 1

            if (nudCnt == 1)
            {
                var card1 = new Card { CityFrom = "Мельбурн", CityTo = "Кельн" };
                var card2 = new Card { CityFrom = "Москва", CityTo = "Париж" };
                var card3 = new Card { CityFrom = "Кельн", CityTo = "Москва" };
                cards = new List<Card> { card1, card2, card3 };
            }
            else
                cards = TestListAdd((int)nudCnt);

            var sorted = arrange(cards); //Алгоритм сортировки входящего набора карточек

            Benchmark.End();
            MessageBox.Show(@"Прошло: " + Benchmark.GetSeconds() + @" секунд.", @"Тестируем");

            if (nudCnt > 20)
                MessageBox.Show(@"Карточки отсортированы");
            else
            {
                var report = @"Данные по путешествию.";

                foreach (Card crd in sorted)
                    report += Environment.NewLine + "   " + crd.CityFrom + " -> " + crd.CityTo;

                MessageBox.Show(report);
            }

            b_start.Enabled = true;
        }

        public List<Card> arrange(List<Card> cards)
        {

            var result = new List<Card>();
            var cnt = cards.Count;
            var cardsFrom = cards.Select(x => x.CityFrom).ToList();
            var cardsTo = cards.Select(x => x.CityTo).ToList();
            //Card cardCurr = null; //FOR TEST

            //var all = string.Join(",", cards.Select(m => m.CityFrom + "," + m.CityTo)).Split(',');

            var from = "";

            var hashTo = new HashSet<string>();

            for (int i = 0; i < cnt; i++)
            {
                var cto = cards[i].CityTo;
                hashTo.Add(cto);
            }

            for (int j = 0; j < cnt; j++)
            {
                var cfrom = cards[j].CityFrom;
                if (hashTo.Add(cfrom))
                {
                    from = cfrom;
                    //cardCurr = cards[j];//FOR TEST
                    //cards.RemoveAt(j);//FOR TEST
                    //cards.Insert(0, cardCurr);//FOR TEST
                    break;
                }
            }

            //// Находим отправную точку маршрута медленно
            //var dist = all
            //    .GroupBy(v => v)
            //    .Where(g => g.Count() < 2)
            //    .Select(g => g.Key)
            //    .Where(g => cardsFrom.Contains(g))
            //    .ToList();

            //from = dist[0];

            var ind = 0;
            var dictF = new SortedList<string, int>(cardsFrom.ToDictionary(r => r, r => ind++));

            for (int i = 0; i < cnt; i++)   //повторение n раз
            {
                //var num = cardsFrom.IndexOf(from);   //Перебор всех значений в листе - n раз      //42.8 cекунды на 100 000 записей (48.5Мб RAM)
                //var num = GetIndex(cardsFrom,from);   //Поиск значений через цикл                 //66.4 cекунды на 100 000 записей (70.1Мб RAM)
                //var num = cardsFrom.FindIndex(x => x.Equals(from, StringComparison.Ordinal));     //67.8 cекунд на 100 000 записей (48.5Мб RAM)
                var num = GetIndex(dictF, from);   //Поиск значений через SortedList                //0.67 секунды на 100 000 записей (48.5Мб RAM)

                from = cardsTo[num];   //2 действия
                result.Add(cards[num]);   //2 действия
            }

            //for (int i = 0; i < cards.Count-1; i++)
            //{
            //    cardCurr = cards[cards.IndexOf(cards[i])];
            //    cards[cards.IndexOf(cards[i])] = cards[i+1];
            //    cards[i+1] = cardCurr;
            //}

            //Количество операций для упорядочивания в зависимости от количества карточек(n): n * (n + 4)
            //O(n2) — квадратичная сложность

            return result;
            //return cards;
        }

        //Custom method instead "IndexOf"
        private static int GetIndex(List<string> list, string value)
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] == value)
                {
                    return index;
                }
            }

            return -1;
        }

        private static int GetIndex(SortedList<string, int> dict, string value)
        {
            var result = dict.Values[dict.IndexOfKey(value)];
            return result;
        }

        public List<Card> TestListAdd(int cityCount, int cityLen = 5)
        {
            string[] chars = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "a", "e", "i", "o", "u" };
            var rndFrom = new Random();
            var cards = new List<Card>();

            var citySrc = new string [cityCount];
            var city = "";
            var cnt = 0;

            var hash = new HashSet<string>();

            while (true)
            {
                for (int j = 0; j < cityLen; j++) //Длина названия города
                {
                    city += chars[rndFrom.Next(26)];
                }

                if (!hash.Add(city)) //Проверяем на уникальность
                    continue;

                citySrc[cnt] = city;
                city = "";
                cnt++;               

                if (cnt == cityCount) //Количество городов
                    break;
            }

            for (int i = 0; i < citySrc.Length - 1; i++)
            {
                var curr = new Card() { CityFrom = citySrc[i + 1], CityTo = citySrc[i] };
                cards.Add(curr);
            }

            return TestListShuffle(cards); 
        }

        public List<Card> TestListShuffle(List<Card> cards)
        {
            var rndFrom = new Random();

            //Тасование Фишера — Йетса
            for (int k = cards.Count - 1; k >= 1; k--)
            {
                int j = rndFrom.Next(k + 1);
                // обменять значения data[j] и data[i]
                var temp = cards[j];
                cards[j] = cards[k];
                cards[k] = temp;
            }

            return cards;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //nud_city.Value = nud_city.Maximum;
        }
    }
}
