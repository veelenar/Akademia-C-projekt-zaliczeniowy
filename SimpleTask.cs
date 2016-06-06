using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Task_Manager_CSharp_WPF
{
    class SimpleTask : Task
    {
        public override Importance Importance {
            get { return Importance.Simple; }
        }
        public override Color Color { get { return Colors.LawnGreen; } }
    }
}
