using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Typing
{
    static class Records
    {
        public static int mistakes;
        public static int green_counts;
        public static string name;
        public static int cpm;
        public static double cps;
        public static List<Leaderboard.Leaderboard> list = new();
        public static List<Leaderboard.Leaderboard> leaderboard = new();
        public static ConsoleKeyInfo buttonchik;
        private static void MAIN()
        {
            cpm = Program.green.Count;
            mistakes = Program.wrong.Count;
            name = Program.name;
            cps = Math.Round(((double)cpm / 60), 2);
            Leaderboard.Leaderboard user = new(name, cpm, cps, mistakes);
            list.Add(user);


        }
        public static void main()
        {
            MAIN();
            Deserialize();
            Serialize();
            Console.Clear();
            Console.SetCursorPosition(24, 0);
            Console.WriteLine("Таблица рекордов");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Имя\t" + "Символов в минуту\t" + "Символов в секунду\t" + "Ошибок");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var i in list)
            {
                Console.Write(i.Name + "\t\t" + i.Cpm + "\t\t" + i.Cps + "\t\t" + i.Mistakes +"\n");
            }
            Console.WriteLine("\nВведите Enter для прохождения теста заново");
            while(buttonchik.Key != ConsoleKey.Enter || buttonchik.Key != ConsoleKey.Escape)
            {
                buttonchik = Console.ReadKey(true);
                if (buttonchik.Key == ConsoleKey.Enter) Program.Main();
                if (buttonchik.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
        private static void Serialize()
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\paulscriptum\\Desktop\\Leaderboard.json", json);
        }
        private static void Deserialize()
        {
            string text = File.ReadAllText("C:\\Users\\paulscriptum\\Desktop\\Leaderboard.json");
            leaderboard = JsonConvert.DeserializeObject<List<Leaderboard.Leaderboard>>(text);
            for (int i = 0; i < leaderboard.Count;i++)
            {
                list.Add(leaderboard[i]);
            }
        }
    }
}
