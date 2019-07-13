using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSApiApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        ///
      

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}



/*https:// api.vk.com/method/messages.send?user_id=270328727&random_id=123&message=%27%D0%9F%D1%80%D0%B8%D0%B2%D0%B5%D1%82%27&access_token=e3c30bf8a99dd17da33d10b5087627fd5b23ce60cb6e894d4598d8265b4ea7310b85ed6fabb5da3019b37&v=5.101*/
