﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeedShop.Core.ExceptionHandling
{
    public class ErrorFactory : IErrorFactory
    {
        public void Invalid(string message)
        {
            throw new Exception(message);
        }
    }
}
