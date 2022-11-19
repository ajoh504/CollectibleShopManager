using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    public interface IMenuLogic
    {
        List<string> GetAllMenuQuestions();
        void SetMenuValues(List<string> menuQuestions);
    }
}
