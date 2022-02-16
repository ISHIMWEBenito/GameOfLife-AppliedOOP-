using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{

    
    abstract internal class Cell 
    /**************************************
            ABSTRACTION 
            THIS IS AN ABSTRACT CLASS ABOVE
    ***************************************/


    {

        /**************************************
            ABSTRACTION 
            THIS IS AN ABSTRACT METHOD BELOW
    ***************************************/
        public abstract void SetAlive(int x, int y);
    }
}
