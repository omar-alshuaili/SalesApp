using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csY2S2_cs_project.classes
{
    public class managerClass: UserClass
    {




        public string DisInformation()
        {
           
            return $"Hello, {this.Name.Split(' ')[0] }";
        }
    }
}
