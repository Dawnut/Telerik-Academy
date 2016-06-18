using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DSpace;
using GenericClass;

    namespace Matrix
    {
        using System;
        using System.Text;

        public class Matrix<T> where T : IComparable
        {
            private T[,] matrix;

            public Matrix(int row, int col)
            {
                this.matrix = new T[row, col];
            }

            public int Rows
            {
                get { return this.matrix.GetLength(0); }
            }

            public int Columns
            {
                get { return this.matrix.GetLength(1); }
            }

            public T this[int row, int col]
            {
                get
                {
                    return this.matrix[row, col];
                }

                set
                {
                    this.matrix[row, col] = value;
                }
            }

            public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
            {
                if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
                {
                    throw new ArgumentException("Matrices cannot be with different dimensions!");
                }

                var result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Columns; col++)
                    {
                        result[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                    }
                }

                return result;
            }

            public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
            {
                if (firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
                {
                    throw new ArgumentException("Matrices cannot be with different dimensions!");
                }

                var result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Columns; col++)
                    {
                        result[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                    }
                }

                return result;
            }

            public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
            {
                if (firstMatrix.Columns != secondMatrix.Rows)
                {
                    throw new ArgumentException("Тhe product of two matrices is undefined.");
                }

                var result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
                for (int secondCol = 0; secondCol < secondMatrix.Columns; secondCol++)
                {
                    dynamic cell = 0;

                    for (int firstRow = 0; firstRow < firstMatrix.Rows; firstRow++)
                    {
                        for (int firstCol = 0; firstCol < firstMatrix.Columns; firstCol++)
                        {
                            cell += (dynamic)firstMatrix[firstRow, firstCol] * secondMatrix[firstCol, secondCol];
                        }

                        result[firstRow, secondCol] = cell;
                    }
                }

                return result;
            }

            public static bool operator true(Matrix<T> matrix)
            {
                bool isTrue = true;
                for (int row = 0; row < matrix.Rows; row++)
                {
                    for (int col = 0; col < matrix.Columns; col++)
                    {
                        if ((dynamic)matrix[row, col] == 0)
                        {
                            isTrue = false;
                        }
                    }
                }

                return isTrue;
            }

            public static bool operator false(Matrix<T> matrix)
            {
                bool isTrue = true;
                for (int row = 0; row < matrix.Rows; row++)
                {
                    for (int col = 0; col < matrix.Columns; col++)
                    {
                        if ((dynamic)matrix[row, col] == 0)
                        {
                            isTrue = false;
                        }
                    }
                }

                return !isTrue;
            }

            public override string ToString()
            {
                var output = new StringBuilder();
                for (int row = 0; row < this.matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < this.matrix.GetLength(1); col++)
                    {
                        output.AppendFormat("{0, 3} ", this.matrix[row, col]);
                    }

                    output.Append("\n");
                }

                return output.ToString();
            }
        }
    }
