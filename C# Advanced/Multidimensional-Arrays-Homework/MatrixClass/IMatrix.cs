namespace MatrixClass
{
    public interface IMatrix
    {
        int Height { get; set; }
        int Width { get; set; }

        int this[int row, int column] { get; set; }

        IMatrix Add(IMatrix matrix);
        IMatrix Substract(IMatrix matrix);
        IMatrix Multiply(IMatrix matrix);
    }
}
