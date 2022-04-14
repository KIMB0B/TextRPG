using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Item
{
    string Name;
    int B_Gold;
    int S_Gold;

    public Item(string _Name, int _B_Gold, int _S_Gold)
    {
        Name = _Name;
        B_Gold = _B_Gold;
        S_Gold = _S_Gold;
    }

    public string GS_Name { get { return Name; } set { Name = value; } }
    public int GS_S_Gold { get { return S_Gold; } set { S_Gold = value; } }
}
