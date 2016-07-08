using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Osoby
{
    class Osoby

    {
        // jedina instance pro celou aplikaci, odkaz vlastni kazde okno
        private static Driver data=new Driver();


        static void Main(string[] par)
        {


            Application.EnableVisualStyles();
            Application.Run(new HlavniPanel(data));
        }
    }
}
