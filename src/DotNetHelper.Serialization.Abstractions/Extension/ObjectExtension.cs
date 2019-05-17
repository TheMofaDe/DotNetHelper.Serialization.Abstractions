﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetHelper.Serialization.Abstractions.Extension
{
    internal static class ObjectExtension
    {
        public static void IsNullThrow(this object obj, string name, Exception error = null)
        {
            if (obj != null) return;
            if (error == null) error = new ArgumentNullException(name);
            throw error;
        }
    }
}
