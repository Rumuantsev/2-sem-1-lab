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
            for (int ColumnIndex = 0; ColumnIndex < Size; ++ColumnIndex)
            {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex)
                {
                    Result.Matrix[ColumnIndex, RowIndex] = this.Matrix[ColumnIndex, RowIndex];
                }
            }

            return Result;
        }
    }
}
