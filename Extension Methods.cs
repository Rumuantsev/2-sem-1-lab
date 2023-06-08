using Lab3;
using System;

namespace Lab3
{
    public static class ExtensionMethods
    {
        public static SquareMatrix Transpose(this SquareMatrix TransponseMatrix)
        {
            for (int RowIndex = 0; RowIndex < TransponseMatrix.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < TransponseMatrix.Size; ++ColumnIndex)
                {
                    if (RowIndex != ColumnIndex)
                    {
                        int Element = TransponseMatrix.Matrix[RowIndex, ColumnIndex];

                        TransponseMatrix.Matrix[RowIndex, ColumnIndex] = TransponseMatrix.Matrix[ColumnIndex, RowIndex];
                        TransponseMatrix.Matrix[ColumnIndex, RowIndex] = Element;
                    }
                }
            }

            return TransponseMatrix;
        }

        public static int MatrixTrace(this SquareMatrix Matrix)
        {
            int SumOfDiagonalElements = default;

            for (int RowIndex = 0; RowIndex < Matrix.Size; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex <= RowIndex; ++ColumnIndex)
                {
                    SumOfDiagonalElements += Matrix.Matrix[RowIndex, ColumnIndex];
                }
            }

            return SumOfDiagonalElements;
        }
    }
}