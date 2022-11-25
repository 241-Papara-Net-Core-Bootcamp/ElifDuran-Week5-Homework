using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeekHomework.Business.Interfaces
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out List<T> value);
        T Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
