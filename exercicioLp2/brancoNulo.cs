using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioLp2
{
    class brancoNulo
    {
        int totalBranco;
        int totalNulo;

        public void setNulo()
        {
            totalNulo += 1;
            
        }
        public void setBranco()
        {
          
            totalBranco += 1;
            
        }
        public int getBranco()
        {
            return totalBranco;
        }
        public int getNulo()
        {
            return totalNulo;
        }
    }
}
