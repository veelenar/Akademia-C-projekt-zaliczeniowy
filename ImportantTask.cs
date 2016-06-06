using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Task_Manager_CSharp_WPF
{
    public class ImportantTask : Task
    {
        public override Importance Importance
        {
            get { return Importance.Important; }
        }

        public override Color Color
        {
            get { return Color.FromRgb(0xff, 0x00, 0x00); }
        }
    }
}
