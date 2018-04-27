using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Grab.Baidu
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("请输入要查询的关键字,按回车结束：");
                var keyword = Console.ReadLine();
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(String.Format("开始查询关键字为：{0} ，页码为：{1} 的百度数据。。。", keyword, i));
                    PhantomGrab bg = new PhantomGrab();
                    var html = bg.Get(keyword, i).Result;
                    bg.Analysis(html).Wait();
                }
                Console.WriteLine("数据检索结束，按Q键结束，按任意键继续");
                var key = Console.ReadKey();
                if (key.KeyChar == 'Q' || key.KeyChar == 'q') return;
                Console.WriteLine();
            }
        }
    }
}
