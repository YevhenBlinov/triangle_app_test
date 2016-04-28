using System;
using System.Collections.Generic;

namespace TriangleApp
{
    public sealed class MaximumSumCalculator
    {
        private readonly List<List<int>> _triangle;

        public MaximumSumCalculator(List<List<int>> triangle)
        {
            _triangle = triangle;
        }

        public int Calculate()
        {
            if (_triangle.Count == 1) 
                return _triangle[0][0];

            for (var i = _triangle.Count - 2; i >= 0; i--)
            {
                if (_triangle[i + 1].Count - _triangle[i].Count != 1)
                {
                    throw new IndexOutOfRangeException();
                }

                for (var j = 0; j <= i; j++)
                {
                    _triangle[i][j] += Math.Max(_triangle[i + 1][j], _triangle[i + 1][j + 1]);
                }
            }

            return _triangle[0][0];
        }
    }
}
