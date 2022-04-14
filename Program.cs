using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum STARTSELECT
{
    SELECTTOWN,
    SELECTBALTTLE,
    SELECTEND,
    NONESELECT
}

enum UNITCLASS
{
    KNIGHT,
    WIZARD,
    THIEF,
    PRIEST
}

namespace TextRPG
{
    class Program
    {
        static string SetName()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("캐릭터 이름을 설정해 주세요 : ");
                string Name = Console.ReadLine();
                if (Name == "")
                {
                    Console.WriteLine("\n이름을 입력하지 않았습니다.");
                    Console.ReadKey();
                }
                else
                {
                    return Name;
                }
            }
        }

        static UNITCLASS SetClass()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("직업을 선택해야 합니다.");
                Console.WriteLine("1. 검사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 도적");
                Console.WriteLine("4. 성직자");
                Console.Write("어느 길로 가시겠습니까? : ");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("검을 들었습니다.");
                        Console.ReadKey();
                        return UNITCLASS.KNIGHT;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("지팡이를 들었습니다.");
                        Console.ReadKey();
                        return UNITCLASS.WIZARD;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("복면을 들었습니다.");
                        Console.ReadKey();
                        return UNITCLASS.THIEF;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("성서를 들었습니다.");
                        Console.ReadKey();
                        return UNITCLASS.PRIEST;
                    default:
                        Console.WriteLine("\n\n잘못 선택했습니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static STARTSELECT StartSelect()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 마을");
                Console.WriteLine("2. 배틀");
                Console.WriteLine("0. 게임 종료");
                Console.Write("어디로 가시겠습니까? : ");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\n\n마을로 이동합니다.");
                        Console.ReadKey();
                        return STARTSELECT.SELECTTOWN;
                    case ConsoleKey.D2:
                        Console.WriteLine("\n\n배틀을 시작합니다.");
                        Console.ReadKey();
                        return STARTSELECT.SELECTBALTTLE;
                    case ConsoleKey.D0:
                        Console.WriteLine("\n\n 게임을 종료합니다.");
                        Console.ReadKey();
                        return STARTSELECT.SELECTEND;
                    default:
                        Console.WriteLine("\n\n잘못 선택했습니다...");
                        Console.ReadKey();
                        return STARTSELECT.NONESELECT;
                }
            }
        }

        static void Town(Player _Player)
        {
            while (true)
            {
                Console.Clear();
                _Player.StatusRender();
                Console.WriteLine("1. 체력을 회복한다.");
                Console.WriteLine("2. 인벤토리를 확인한다.");
                Console.WriteLine("3. 무기를 강화한다.");
                Console.WriteLine("4. 마을을 나간다.");
                Console.Write("마을에서 무슨일을 하시겠습니까? : ");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        _Player.MaxHeal();
                        break;
                    case ConsoleKey.D2:
                        _Player.InvenRender();
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("\n\n마을을 나갑니다.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("\n\n선택지에 있는 것만 골라주세요.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Battle(Player _Player)
        {
            Monster _Monster = new Monster("슬라임", 2, 30, 30, 1, new Item("물컹물컹 신발", 0, 500));
            _Player.RivalAlert(_Monster);
            while (_Player.EndMatch(_Monster)==2)
            {
                Console.Clear();
                _Player.StatusRender();
                Console.WriteLine("                 vs");
                _Monster.StatusRender();
                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 도망치기");
                Console.Write("무슨 행동을 하시겠습니까? : ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("");
                        _Player.Damage(_Monster);
                        _Monster.Damage(_Player);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("\n\n도망치기에 성공했다!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("선택지에 있는 것만 골라주세요.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Player NewPlayer = new Player(SetName(), SetClass());
            while (true)
            {
                STARTSELECT SelectCheck = StartSelect();
                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTTOWN:
                        Town(NewPlayer);
                        break;
                    case STARTSELECT.SELECTBALTTLE:
                        Battle(NewPlayer);
                        break;
                    case STARTSELECT.SELECTEND:
                        return;
                }
            }
        }
    }
}