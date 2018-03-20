using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.UI_Elements
{
    public class Headers
    {
        public static string SeperatorBar = "=================================";

        public static void DisplayHeader(string workflow)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(SeperatorBar);
            Console.WriteLine($"         {workflow} An Order:       ");
            Console.WriteLine(SeperatorBar);
            Console.WriteLine();
        }

        public static void MainMenuHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" **********************************************");
            Console.WriteLine(" *                                            *");
            Console.WriteLine(" *              FLOOR: RUGNAROK               *");
            Console.WriteLine(" *                                            *");
            Console.WriteLine(" *        Floor Order Management System       *");
            Console.WriteLine(" *                                            *");
            Console.WriteLine(" **********************************************");
            Console.WriteLine();
        }
    }
}
