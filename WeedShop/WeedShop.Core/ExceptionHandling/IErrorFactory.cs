using System;
using System.Collections.Generic;
using System.Text;

namespace WeedShop.Core.ExceptionHandling
{
    public interface IErrorFactory
    {
        void Invalid(string message);
    }
}
