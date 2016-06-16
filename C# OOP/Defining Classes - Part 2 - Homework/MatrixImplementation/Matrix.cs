namespace MatrixImplementation
{
    using System;

    internal class Matrix<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        private const string RowOutOfBoundsErrorMessage = "Row index is out of the bounds!";
        private const string ColumnOutOfBoundsErrorMessage = "Column index is out of the bounds!";
        private const string EqualRowsAndColumnsErrorMessage = "Matrices must have equal rows nad columns!";

        private int rows;
        private int columns;
        private T[,] elements;

        public Matrix(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.elements = new T[this.Rows, this.Columns];
        }

        public T this[int row, int column]
        {
            get
            {
                if (!this.IsInRangeOfRows(row))
                {
                    throw new IndexOutOfRangeException(RowOutOfBoundsErrorMessage);
                }

                if (!this.IsInRangeOfColumns(column))
                {
                    throw new IndexOutOfRangeException(ColumnOutOfBoundsErrorMessage);
                }

                return this.elements[row, column];
            }

            set
            {
                if (!this.IsInRangeOfRows(row))
                {
                    throw new IndexOutOfRangeException(RowOutOfBoundsErrorMessage);
                }

                if (!this.IsInRangeOfColumns(column))
                {
                    throw new IndexOutOfRangeException(ColumnOutOfBoundsErrorMessage);
                }

                this.elements[row, column] = value;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rows count cannot be negative or equal to 0!");
                }

                rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Columns count cannot be negative or equal to 0!");
                }

                columns = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new InvalidOperationException(EqualRowsAndColumnsErrorMessage);
            }

            int newMatrixRows = firstMatrix.Rows;
            int newMatrixColums = firstMatrix.Columns;
            var newMatrix = new Matrix<T>(newMatrixRows, newMatrixColums);

            try
            {
                for (int row = 0; row < newMatrixRows; row++)
                {
                    for (int col = 0; col < newMatrixColums; col++)
                    {
                        dynamic firstMatrixValue = firstMatrix[row, col];
                        dynamic secondMatrixValue = secondMatrix[row, col];
                        dynamic value = firstMatrixValue + secondMatrixValue;
                        newMatrix[row, col] = value;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return newMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Columns != secondMatrix.Columns))
            {
                throw new InvalidOperationException(EqualRowsAndColumnsErrorMessage);
            }

            int newMatrixRows = firstMatrix.Rows;
            int newMatrixColums = firstMatrix.Columns;
            var newMatrix = new Matrix<T>(newMatrixRows, newMatrixColums);

            try
            {
                for (int row = 0; row < newMatrixRows; row++)
                {
                    for (int col = 0; col < newMatrixColums; col++)
                    {
                        dynamic firstMatrixValue = firstMatrix[row, col];
                        dynamic secondMatrixValue = secondMatrix[row, col];
                        dynamic value = firstMatrixValue - secondMatrixValue;
                        newMatrix[row, col] = value;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return newMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Columns != secondMatrix.Rows)
            {
                throw new InvalidOperationException("First matrix columns must be equal to second matrix rows.");
            }

            int newMatrixRows = firstMatrix.Rows;
            int newMatrixColums = secondMatrix.Columns;
            var newMatrix = new Matrix<T>(newMatrixRows, newMatrixColums);

            try
            {
                for (int row = 0; row < newMatrixRows; row++)
                {
                    for (int col = 0; col < newMatrixColums; col++)
                    {
                        for (int i = 0; i < firstMatrix.Columns; i++)
                        {
                            dynamic firstMatrixValue = firstMatrix[row, i];
                            dynamic secondMatrixValue = secondMatrix[i, col];
                            dynamic value = firstMatrixValue * secondMatrixValue;
                            newMatrix[row, col] += value;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return newMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsInRangeOfRows(int index)
        {
            return index >= 0 && index < this.Rows;
        }

        private bool IsInRangeOfColumns(int index)
        {
            return index >= 0 && index < this.Columns;
        }
    }
}
