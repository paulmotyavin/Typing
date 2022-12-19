using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace Typing
{
    public class Program
    {
        public static string name;
        public static string randstr;
        public static ConsoleKeyInfo button;
        public static int i = 60;
        public static List<char> chars;
        public static List<char> green = new List<char>();
        public static List<char> wrong = new List<char>();
        public static void Main()
        {
            string text1 = "Каждое утро, ещё при свете звезд, Якоб Иванович Бах просыпался и, лежа под толстой стеганой периной утиного пуха, слушал мир. Тихие нестройные звуки текущей где-то вокруг него и поверх него чужой жизни успокаивали. Гуляли по крышам ветры — зимой тяжёлые, густо замеша/енные со снегом и ледяной крупой, весной упругие, дышащие влагой и небесным электричеством, летом вялые, сухие, вперемешку с пылью и легким ковыльным семенем. Лаяли собаки, приветствуя вышедших на крыльцо сонных хозяев, и басовито ревел скот на пути к водопою. Мир дышал, трещал, свистел, мычал, стучал копытами, звенел и пел на разные голоса.";
            string text2 = "Профессорская дача на берегу Финского залива. В отсутствие хозяина, друга моего отца, нашей семье позволялось там жить. Даже спустя десятилетия помню, как после утомительной дороги из города меня обволакивала прохлада деревянного дома, как собирала растрясшееся, распавшееся в экипаже тело. Эта прохлада не была связана со свежестью, скорее, как ни странно, — с упоительной затхлостью, в которой слились ароматы старых книг и многочисленных океанских трофеев, непонятно как доставшихся профессору-юристу. Распространяя солоноватый запах, на полках лежали засушенные морские звёзды, перламутровые раковины, резные маски, пробковый шлем и даже игла рыбы-иглы.";
            string text3 = "Мама, обычно холодная, как оконное стекло, была в такой ярости, что переколотила дома всю посуду. Хотела даже просить расчёт, но опомнилась: в других ресторанах и своих певиц хватало. Потому мама просто перестала брать Саню с собой, и он впервые оказался предоставлен самому себе. Поначалу Саня робел один выйти наружу, скучал, слонялся, не зная, чем заняться, — то по комнатам, то по двору. Но к весне осмелел настолько, что исследовал сперва окрестные улицы, а потом и весь обитаемый воронежский мир. Объяснений своим несчастьям он найти не сумел, поэтому решил принять жизнь как она есть.";
            string text4 = "Несколько дней после отчисления Костя ещё ходил в гимназию, каждое утро прилежно собирая учебники и тетрадки, но учителям не велено было его пускать: директор считал, что глухой ученик требует слишком много внимания. Поэтому он, как потерянный, часами бродил вокруг школьного здания либо сидел на траве, глядя в распахнутые настежь окна. Оставаться дома Костя не хотел: в любом углу, в любом закуточке он ощущал на себе печальный взгляд мамы. Рядом с гимназией беззвучно волновалась рыночная площадь, и однажды Костя помог соседке принести оттуда старые юбки-кринолины. Она скупала их и перешивала в рубахи и платья на продажу для горожан победнее.";
            string text5 = "Вечером мы выступили в ночной марш к реке Рузе, за тридцать километров от Волоколамска. Житель южного Казахстана, я привык к поздней зиме, а здесь, в Подмосковье, в начале октября утром уже подмораживало. На рассвете по схваченной морозом дороге, по затвердевшей, вывороченной колёсами грязи мы подошли к селу Новлянскому. Оставив батальон близ села, в лесу, я с командирами рот отправился на рекогносцировку. Моему батальону было отмерено семь километров по берегу извилистой Рузы. В бою, по нашим уставам, такой участок велик даже для полка. Это, однако, не тревожило. Я был уверен, что, если противник действительно подойдёт когда-нибудь сюда, его встретит на наших семи километрах не батальон, а пять или десять батальонов."; Random random = new Random();
            int randint = random.Next(1, 6);
            if (randint == 1) randstr = text1;
            if (randint == 2) randstr = text2;
            if (randint == 3) randstr = text3;
            if (randint == 4) randstr = text4;
            if (randint == 5) randstr = text5;

            Console.WriteLine("Введите ваше имя для таблицы рекордов:");
            name = Console.ReadLine();
            Console.Clear();
            Typing();
        }
        private static void Typing()
        {
            chars = randstr.ToCharArray().ToList();
            ConsoleKeyInfo button;
            int pos = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(randstr);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Нажмите Enter, чтобы начать тест на скоропечатание");
            button = Console.ReadKey();
            if (button.Key == ConsoleKey.Enter)
            {
                Timer();
                while (green.Count != chars.Count && i != 0)
                {

                    button = Console.ReadKey(true);
                    if (chars[pos] == button.KeyChar)
                    {
                        green.Add(button.KeyChar);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(0, 0);
                        for(int i = 0; i < pos; i++)
                        {
                            Console.Write(chars[i]);
                        }
                        pos++;
                    }
                    else
                    {
                        wrong.Add(button.KeyChar);
                    }

                }
            }
            else
            {
                Console.Clear();
                Typing();
            }
        }
        private static void Timer()
        {
            Thread thread = new Thread(_ =>
            {
                do
                {
                    Console.SetCursorPosition(0, 10);
                    if (i < 10) Console.WriteLine("Таймер: 0:0" + i);
                    else Console.WriteLine("Таймер: 0:"+ i);
                    i--;
                    Thread.Sleep(1000);
                } while (i != 0);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Records.main();
            });
            thread.Start();
        }
        
    }
}




/*ConsoleKeyInfo button;
        int pos = 0;
        int pos1 = 0;
        do
        {
            chars = Lclothes[pos1].ToString().ToCharArray().ToList();
            button = Console.ReadKey();
            if (button.Key == ConsoleKey.LeftArrow)
            {
                pos = (pos - 1 == -1) ? pos : pos - 1;
            }
            else if (button.Key == ConsoleKey.RightArrow)
            {
                pos = (pos + 1 == chars.Count + 1) ? pos : pos + 1;
            }
            if (button.Key == ConsoleKey.DownArrow)
            {
                pos1++;
                chars = Lclothes[pos1].ToString().ToCharArray().ToList();
            }
            if (button.Key == ConsoleKey.UpArrow)
            {
                pos1--;
                chars = Lclothes[pos1].ToString().ToCharArray().ToList();
            }
            else if (button.Key == ConsoleKey.Backspace)
            {
                chars.RemoveAt(pos - 1);
                pos--;
            }
            if (button.Key == ConsoleKey.Spacebar)
            {
                chars.Insert(pos, ' ');
                pos++;
            }
            else if (Char.IsLetterOrDigit(button.KeyChar))
            {
                chars.Insert(pos, button.KeyChar);
                pos++;

            }
            Lclothes[pos1] = string.Join("", chars);
            chars = Lclothes[pos1].ToString().ToCharArray().ToList();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                  ");
            Console.SetCursorPosition(0, 0);
            foreach (var item in Lclothes)
                Console.WriteLine(item);
            Console.SetCursorPosition(pos, pos1);
        } while (button.Key != ConsoleKey.F1);



static void Typing()
        {
            List<char> chars = randstr.ToCharArray().ToList();
            List<char> symbol = new List<char>();
            ConsoleKeyInfo button;
            int pos = 0;
            Console.WriteLine(randstr);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Нажмите Enter, чтобы начать тест на скоропечатание");
            button = Console.ReadKey();
            if (button.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, 0);
                do
                {
                    button = Console.ReadKey(true);
                    symbol.Insert(pos, button.KeyChar);
                    if (chars[pos] == symbol[pos])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(symbol[pos]);
                        pos++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(symbol[pos]);
                        pos++;
                    }

                    if (button.Key == ConsoleKey.Backspace)
                    {
                        pos--;
                        symbol.RemoveAt(pos-1);
                        Console.Write(symbol[pos-1]);
                    }
                    if (button.Key == ConsoleKey.Spacebar)
                    {
                        symbol.Insert(pos, ' ');
                    }
                } while (true);
            }
            else Typing();

        }
        */