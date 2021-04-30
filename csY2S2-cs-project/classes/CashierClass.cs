using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csY2S2_cs_project.classes
{

    public class CashierClass : UserClass
    {
        public CashierClass(string name, string roleName,string image,string password)
        {
            this.Name = name;
            this.RoleName = roleName;
            this.image = image;
            this.Password = password;

        }
        public override string DisInformation()
        {

            return $"Hello, {this.Name.Split(' ')[0] }\n{this.RoleName}";
        }

    }
}
