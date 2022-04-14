using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class FightUnit
    {
        protected string Name;
        protected int AT;
        protected int HP;
        protected int MAXHP;
        protected Inven Inventory;

        public string GS_Name { get { return Name; } set { Name = value; } }

        public virtual void StatusRender()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("공격력 : " + AT);
            Console.WriteLine("체력 : " + HP + "/" + MAXHP);
            Console.WriteLine("---------------------------------------");
        }

        public void MaxHeal()
        {
            int HowMuchHeal = MAXHP - HP;
            HP = MAXHP;
            Console.WriteLine("\n\n" + Name + "의 체력이 " + HowMuchHeal + "만큼 회복되었습니다.");
            Console.ReadKey();
        }

        public void Damage(FightUnit _OtherUnit)
        {
            _OtherUnit.HP -= AT;
            Console.Write("\n" + Name + "의 공격으로 " + _OtherUnit.Name + "의 체력이 " + AT + "감소했습니다!");
        }

        public int EndMatch(FightUnit _OtherUnit)
        {
            if (HP <= 0)
            {
                Console.WriteLine("\n\n" + _OtherUnit.Name + "의 공격으로 사망했습니다....");
                Console.WriteLine("GAME OVER");
                Console.ReadKey();
                return 0;
            }
            else if (_OtherUnit.HP <= 0)
            {
                Console.WriteLine("\n\n" + _OtherUnit.Name + "을(를) 쓰려트렸습니다!");
                Console.WriteLine("전리품으로 " + _OtherUnit.Inventory.GS_Item.GS_Name + "을(를) 획득했습니다!");
                Inventory.Insert(_OtherUnit.Inventory.GS_Item);
                Console.ReadKey();
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
