using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Monster : FightUnit
    {
        public Monster(string _Name, int _AT, int _HP, int _MAXHP, int _ItemX, Item _Item)
        {
            Name = _Name;
            AT = _AT;
            HP = _HP;
            MAXHP = _MAXHP;
            Inventory = new Inven(_ItemX, 1);
            Inventory.Insert(_Item);
        }
        public Monster(string _Name, int _AT, int _HP, int _MAXHP, int _ItemX, Item _Item1, Item _Item2)
        {
            Name = _Name;
            AT = _AT;
            HP = _HP;
            MAXHP = _MAXHP;
            Inventory = new Inven(_ItemX, 1);
            Inventory.Insert(_Item1);
            Inventory.Insert(_Item2);
        }
        public Monster(string _Name, int _AT, int _HP, int _MAXHP, int _ItemX, Item _Item1, Item _Item2, Item _Item3)
        {
            Name = _Name;
            AT = _AT;
            HP = _HP;
            MAXHP = _MAXHP;
            Inventory = new Inven(_ItemX, 1);
            Inventory.Insert(_Item1);
            Inventory.Insert(_Item3);
        }
    }
}
