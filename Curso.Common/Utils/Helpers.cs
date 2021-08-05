using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Common.Utils
{
    public static class Helpers
    {
        public static string Algo { get; set; }

        public static string GetDateTimeString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
