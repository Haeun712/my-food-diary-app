﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services.PartialMethods
{
    static partial class WindowSizeHandler
    {
        public static void CallSetWindowSize()
        {
            SetWindowSize();
        }
        static partial void SetWindowSize();
    }
}
