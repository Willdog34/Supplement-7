using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplement_7
{
    internal class LinqFunctions
    {
    }
}

namespace LinqProject
{
    using System;
    using System.Linq;

    public static class LinqFunctions
    {
        public static int[] GetEvenNumbers(int[] array, int skip = 0)
        {
            return array.Where(n => n % 2 == 0).Skip(skip).ToArray();
        }

        public static int[] GetOddNumbersAfterShuffle(int[] array, int skip = 0)
        {
            var shuffled = array.OrderBy(_ => Guid.NewGuid()).ToArray();
            return shuffled.Where(n => n % 2 != 0).Skip(skip).ToArray();
        }

        public static (double average, int min, int max) GetArrayStatistics(int[] array)
        {
            return (array.Average(), array.Min(), array.Max());
        }
    }
}