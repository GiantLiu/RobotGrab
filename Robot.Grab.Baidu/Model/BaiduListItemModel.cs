using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Grab.Baidu
{
    public class BaiduListItemModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string RealAddress { get; set; }
        public string Content { get; set; }
        public override string ToString()
        {
            return String.Format("{0}\r\n百度地址：{1}\r\n真实地址：{2}\r\n{3}\r\n\r\n", Title, Address, RealAddress, Content);
        }
    }
}
