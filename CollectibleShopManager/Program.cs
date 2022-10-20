using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace CollectibleShopManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExecutionFlow flow = new ExecutionFlow();
            flow.MainMenuFlow();
        }
    }
}