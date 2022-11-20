using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    /// <summary>
    /// Interface methods for setting object property values from the console menu screen.
    /// </summary>
    public interface IMenuLogic
    {
        public void SetIntPropertyValues();
        public void SetStringPropertyValues();
        public void SetDecimalPropertyValues();
    }
}
