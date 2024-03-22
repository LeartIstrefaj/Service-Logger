using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Logging
{
    public interface IFajllManipuluesi
    {
        IEnumerable<string> LexoPermbajtjen();

        void Fshijfajllat();

    }
}
