using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixA = new Matrix(3);
            matrixA.RandomFill();

            var matrixB = new Matrix(3);
            matrixB.RandomFill();

            var matrixC = new Matrix(3);
            matrixC.RandomFill();

            Console.WriteLine("Matrix A:");
            matrixA.Print();

            Console.WriteLine("\nMatrix B:");
            matrixB.Print();

            Console.WriteLine("\nMatrix C:");
            matrixC.Print();

            var result = Logic.Actions(matrixA, matrixB, matrixC);
            Console.WriteLine("\nРезультат:");
            result.Print();
            Console.Read();
        }
    }
    public class Matrix
    {
        //Конструктор
        public int[,] data;
        private int n;

        public int SumMainDiagonal//Сумма элементов главной диагонали
        {
            get
            {
                var count = 0;
                for (var i = 0; i < this.n; i++)
                {
                    for (var j = 0; j < this.n; j++)
                    {
                        if (i == j)
                        {
                            count += this[i, j];
                        }
                    }
                }
                return count;
            }

        }

        public int SumSideDiagonal//Сумма элементов побочной диагонали
        {
            get
            {
                var count = 0;
                for (var i = 0; i < this.n; i++)
                {
                    for (var j = 0; j < this.n; j++)
                    {
                        if (j == (n - 1 - i))
                        {
                            count += this[i, j];
                        }
                    }
                }
                return count;
            }
        }

        public Matrix(int n)
        {
            this.data = new int[n, n];
            this.n = n;
        }

        public Matrix(int[,] inputData)
        {
            this.n = inputData.GetLength(0);

            this.data = new int[this.n, this.n];

            for (var i = 0; i < this.n; ++i)
            {
                for (var j = 0; j < this.n; ++j)
                {
                    this.data[i, j] = inputData[i, j];
                }
            }
        }

        public int Size//размер матрицы
        {
            get
            {
                return n;
            }
        }
        public int this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        }

        public void Print()//вывод
        {
            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    Console.Write("{0}\t", this[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void RandomFill()//рандом
        {
            var rand = new Random();
            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    this[i, j] = rand.Next() % 100;
                }
            }
        }

        public static Matrix operator +(Matrix A, Matrix B)//сумма
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    resultMatix[i, j] = A[i, j] + B[i, j];
                }
            }
            return resultMatix;
        }

        public static Matrix operator -(Matrix A, Matrix B)//вычитание
        {
            var result = new Matrix(A.Size);
            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < A.Size; j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix A, int number)//умножение
        {
            var result = new Matrix(A.Size);
            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < A.Size; j++)
                {
                    result[i, j] = A[i, j] * number;
                }
            }
            return result;
        }

        public static Matrix operator *(int number, Matrix A)
        {
            return A * number;
        }

        public static Matrix operator -(Matrix A, int number)//вычитание числа
        {
            Matrix resultMatrix = new Matrix(A.Size);
            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < A.Size; j++)
                {
                    resultMatrix[i, j] = A[i, j] - number;
                }
            }

            return resultMatrix;
        }

        public static Matrix operator -(int number, Matrix A)
        {
            return A - number;
        }

        public static Matrix operator /(Matrix A, int number)//деление
        {
            Matrix resultMatrix = new Matrix(A.Size);
            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < A.Size; j++)
                {
                    resultMatrix[i, j] = A[i, j] / number;
                }
            }
            return resultMatrix;
        }

        public static Matrix operator !(Matrix A)//транспонирование
        {
            Matrix trans = new Matrix(A.Size);
            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < A.Size; j++)
                {
                    trans[i, j] = A[j, i];
                }
            }
            return trans;
        }


        public override bool Equals(object obj)
        {
            var B = obj as Matrix;

            if (B == null)
                return false;

            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    if (this[i, j] != B[i, j])
                        return false;
                }
            }
            return true;
        }
    }
    public class Logic
    {
        public static Matrix Actions(Matrix A, Matrix B, Matrix C)//функция считающая условия
        {
            var F = new Matrix(A.Size);
            if (B.SumMainDiagonal > (A.SumSideDiagonal + C.SumSideDiagonal))//проверка условия
            {
                F = (!(A - B)) + (2 * C) - 5;
            }
            else
            {
                F = 3 * (!A) + B - (C / 4);
            }
            return F;
        }
    }

}
