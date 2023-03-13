using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class PrototypeSquareMatrix : SquareMatrix, ICloneable
    {
        public PrototypeSquareMatrix(int Size) : base(Size) { }
        public PrototypeSquareMatrix() : base() { }

        public object Clone()
        {
            PrototypeSquareMatrix Result = new PrototypeSquareMatrix(Size);

            Result.Size = this.Size;
            Result.Matrix = this.Matrix;

            return Result;
        }
    }
}
