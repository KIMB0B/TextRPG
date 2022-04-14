using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player : FightUnit
    {
        UNITCLASS UnitClass;
        public Player(string _Name, UNITCLASS _Class)
        {
            Name = _Name;
            UnitClass = _Class;
            switch (UnitClass)
            {
                case UNITCLASS.KNIGHT:
                    AT = 10;
                    HP = 10;
                    MAXHP = 100;
                    Inventory = new Inven(5, 5);
                    Inventory.Insert(new Item("롱소드", 200, 50));
                    break;
                case UNITCLASS.WIZARD:
                    AT = 7;
                    HP = 50;
                    MAXHP = 50;
                    Inventory = new Inven(5, 5);
                    Inventory.Insert(new Item("완드", 500, 100));
                    break;
                case UNITCLASS.THIEF:
                    AT = 8;
                    HP = 80;
                    MAXHP = 80;
                    Inventory = new Inven(5, 10);
                    Inventory.Insert(new Item("복면", 0, 0));
                    break;
                case UNITCLASS.PRIEST:
                    AT = 5;
                    HP = 50;
                    MAXHP = 50;
                    Inventory = new Inven(5,5);
                    Inventory.Insert(new Item("성서", 300, 200));
                    break;
            }
        }

        public override void StatusRender()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("이름 : " + Name + "[" + UnitClass + "]");
            Console.WriteLine("공격력 : " + AT);
            Console.WriteLine("체력 : " + HP + "/" + MAXHP);
            Console.WriteLine("---------------------------------------");
        }

        public void InvenRender()
        {
            Console.Clear();
            Inventory.Render();
            Console.ReadKey();
        }
        public void RivalAlert(Player _OtherUnit)
        {
            Console.Clear();
            Console.WriteLine(_OtherUnit.Name + "[" + _OtherUnit.UnitClass + "]이(가) 나타났다!!");
            Console.ReadKey();
        }
        public void RivalAlert(FightUnit _OtherUnit)
        {
            Console.Clear();
            Console.WriteLine(_OtherUnit.GS_Name + "이(가) 나타났다!!");
            Console.ReadKey();
        }
    }
}
