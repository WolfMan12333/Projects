using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para2
{
    public class Para<T, C> : IComparable<Para<T, C>> where T : IComparable<T> where C : IComparable<C>
    {
        private T pierwszy = default(T);
        private C drugi = default(C);

        public Para(T pierwszy, C drugi)
        {
            this.pierwszy = pierwszy;
            this.drugi = drugi;
        }

        public override string ToString()
        {
            return pierwszy.ToString() + "\t" + drugi.ToString();
        }

        public int CompareTo(Para<T, C> innaPara)
        {
            int wartosc = this.pierwszy.CompareTo(innaPara.pierwszy);
            if (wartosc != 0) return wartosc;
            else return this.drugi.CompareTo(innaPara.drugi);
        }
    }
}
