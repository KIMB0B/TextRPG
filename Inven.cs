using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Inven
{
    Item[] ArrItem;
    int X;
    int Y;

    public Inven(int _X, int _Y)
    {
        if (_X < 1)
        {
            _X = 1;
        }
        if (_Y < 1)
        {
            _Y = 1;
        }
        X = _X;
        Y = _Y;
        ArrItem = new Item[(_X * _Y)];
    }

    public void Render()
    {
        int position = 0;
        while (true)
        {
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i % X == 0)
                {
                    Console.WriteLine();
                }
                if (ArrItem[i] == null)
                {
                    if (i == position)
                    {
                        Console.Write("▣");
                    }
                    else
                    {
                        Console.Write("□");
                    }
                }
                else
                {
                    if (i == position)
                    {
                        Console.Write("▣");
                    }
                    else
                    {
                        Console.Write("■");
                    }
                }
            }
            if (ArrItem[position] == null)
            {
                Console.WriteLine("\n\n" + (position + 1) + ". 비어있습니다.");
            }
            else
            {
                Console.WriteLine("\n\n" + (position + 1) + ". " + ArrItem[position].GS_Name);
                Console.WriteLine("판매가 : " + ArrItem[position].GS_S_Gold);
            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    Console.Clear();
                    if (position >= X)
                    {
                        position -= X;
                    }
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    if (position % X != 0)
                    {
                        position -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    Console.Clear();
                    if (position < X * Y - X)
                    {
                        position += X;
                    }
                    break;
                case ConsoleKey.D:
                    Console.Clear();
                    if (position % X != X - 1)
                    {
                        position += 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    if (position >= X)
                    {
                        if (ArrItem[position - X] == null)
                        {
                            ArrItem[position - X] = ArrItem[position];
                            ArrItem[position] = null;
                            position -= X;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    if (position % X != 0)
                    {
                        if (ArrItem[position - 1] == null)
                        {
                            ArrItem[position - 1] = ArrItem[position];
                            ArrItem[position] = null;
                            position -= 1;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    if (position < X * Y - X)
                    {
                        if (ArrItem[position + X] == null)
                        {
                            ArrItem[position + X] = ArrItem[position];
                            ArrItem[position] = null;
                            position += X;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    if (position % X != X - 1)
                    {
                        if (ArrItem[position + 1] == null) 
                        {
                            ArrItem[position + 1] = ArrItem[position];
                            ArrItem[position] = null;
                            position += 1;
                        }
                    }
                    break;
                case ConsoleKey.Enter:
                    return;
                default:
                    Console.Clear();
                    break;
            }
        }
    }

    public void Insert(Item _Item)
    {
        for (int i = 0; i < ArrItem.Length; i++)
        {
            if (ArrItem[i] == null)
            {
                ArrItem[i] = _Item;
                break;
            }
            else if (ArrItem.Length - 1 < i)
            {
                Console.WriteLine("인벤토리가 꽉 찼습니다.");
                Console.ReadKey();
            }
        }
    }

    public Item GS_Item { get { return ArrItem[0]; } set { ArrItem[0] = value; } }
}
