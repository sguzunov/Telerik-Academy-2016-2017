// Write a class Matrix, to hold a matrix of integers.
// Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

namespace MatrixClass
{
    using System;
    using System.Text;
    public class Matrix : IMatrix
    {
        private const string HeightErrorMessage = "Height must be greater than 0!";
        private const string WidthErrorMessage = "Width must be greater than 0!";
        private const string MatrixNullErrorMessage = "Matrix cannot be null!";
        private const string DifferentMatrixSizesErrorMessage = "Matrices must have same size!";
        private const string IncompatibleDimensionsErrorMessage = "Incompatible dimensions for multiplication!";

        private int height;
        private int width;
        private int[,] matrix;

        public Matrix(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.matrix = new int[this.Height, this.Width];
        }

        public int this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= this.Height || column < 0 || column >= this.Width)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.matrix[row, column];
            }

            set
            {
                if (row < 0 || row >= this.Height || column < 0 || column >= this.Width)
                {
                    throw new IndexOutOfRangeException();
                }

                this.matrix[row, column] = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(HeightErrorMessage);
                }

                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(WidthErrorMessage);
                }

                this.width = value;
            }
        }

        public IMatrix Add(IMatrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(MatrixNullErrorMessage);
            }

            if (this.Height != matrix.Height || this.Width != matrix.Width)
            {
                throw new ArgumentException(DifferentMatrixSizesErrorMessage);
            }

            IMatrix resultMatrix = new Matrix(this.Height, this.Width);
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    resultMatrix[i, j] = this.matrix[i, j] + matrix[i, j];
                }
            }

            return resultMatrix;
        }

        public IMatrix Multiply(IMatrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(MatrixNullErrorMessage);
            }

            if (this.Width != matrix.Height)
            {
                throw new ArgumentException(IncompatibleDimensionsErrorMessage);
            }

            IMatrix resultMatrix = new Matrix(this.Height, matrix.Width);
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < this.Width; k++)
                    {
                        sum += this[i, k] * matrix[k, j];
                    }

                    resultMatrix[i, j] = sum;
                }
            }

            return resultMatrix;
        }

        public IMatrix Substract(IMatrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(MatrixNullErrorMessage);
            }

            if (this.Height != matrix.Height || this.Width != matrix.Width)
            {
                throw new ArgumentException(DifferentMatrixSizesErrorMessage);
            }

            IMatrix resultMatrix = new Matrix(this.Height, this.Width);
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    resultMatrix[i, j] = this.matrix[i, j] - matrix[i, j];
                }
            }

            return resultMatrix;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    result.Append(this.matrix[i, j]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
