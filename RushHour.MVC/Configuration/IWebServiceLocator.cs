using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.MVC.Configuration
{
    public interface IWebServiceLocator
    {
        string ServiceAddress { get; }
    }
}
