using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tirgum
    {
        string BliNeikud;
        Dictionary<string,int> WithNikud;

        public Tirgum(string firstNikud)
        {
            WithNikud = new Dictionary<string,int>();
            WithNikud.Add(firstNikud, 1);
        }

        public string FoundProb()
        {
            return WithNikud.FirstOrDefault(x => x.Value == WithNikud.Values.Max()).Key;
        }

        public void add(string ToAdd)
        {
            if(WithNikud.ContainsKey(ToAdd))
            {
                WithNikud[ToAdd] += 1;
            }
            else
            {
                WithNikud.Add(ToAdd, 1);
            }
        }
    }
}

public class MyCompare : IComparable<int>
{
    public int Compare(int x,int y)
    {
        return x.CompareTo(y);
    }

    public int CompareTo(int other)
    {
        return CompareTo(other);
    }
}
