using System;
using System.Collections.Generic;

namespace КР
{
    class Program
    {
        static void Main(string[] args)
        {
           int max = 5;
            var mas = new int[max, max];


            var rand = new Random();
            for (var i = 0; i < max; i++)
            {
                for (var j = 0; j < max; j++)
                {
                    if (mas[i, j] > 0)
                    {
                        continue;
                    }

                    mas[i, j] = i == j ? 0 : rand.Next(9);
                    mas[j, i] = mas[i, j];
                }
            }

            var maxCost = 0;
            var maxPath = new List<int>();

            for (var i = 0; i < max; i++)
            {
                for (var j = 0; j < max; j++)
                {
                    if (mas[i, j] > 0)
                    {
                        var maxRowCost = 0;
                        var indexK = 0;
                        for (var k = j; k < max; k++)
                        {
                            if (mas[j, k] > maxRowCost && k != i)
                            {
                                maxRowCost = mas[j, k];
                                indexK = k;
                            }
                        }
                        var res = mas[i, j] + mas[j, indexK];
                        if (res > maxCost)
                        {
                            maxCost = res;
                            maxPath = new List<int> { i, j, indexK };
                        }
                    }

                }
            }

            for (var i = 0; i < max; i++)
            {
                for (var j = 0; j < max; j++)
                {
                    Console.Write(mas[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Майксимальная цепь : A["+ maxPath[0]+","+maxPath[1]+"] + A["+maxPath[1]+","+maxPath[2]+"] = "+maxCost);
        

        }
    }
}
