using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OpenCiv1
{
    partial class OpenCiv1
    {
        #region Global variables
        public Point[] aiCityOffsets = new Point[] {
            new Point(0, -1), new Point(1, 0), new Point(0, 1),
            new Point(-1, 0), new Point(1, -1), new Point(1, 1), new Point(-1, 1), new Point(-1, -1),
            new Point(0, -2), new Point(2, 0), new Point(0, 2), new Point(-2, 0), new Point(-1, -2),
            new Point(1, -2), new Point(2, -1), new Point(2, 1), new Point(1, 2), new Point(-1, 2),
            new Point(-2, 1), new Point(-2, -1), new Point(0, 0) };

        public ushort Var_d768 = 0;
        public ushort Var_db3a = 0;
        public ushort Var_db3c = 0;
        public ushort Var_db3e = 0;
        #endregion
    }
}
