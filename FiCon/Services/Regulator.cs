using FiCon.Models.Shared;
using System.Collections.Concurrent;


namespace FiCon.Services
{
    public class Regulator
    {
        private static readonly object _txn_lock = new object();

        protected sealed class GateFactory<T>
        {
            internal static readonly ConcurrentDictionary<Type, IEnumerable<T>> _cache = new();

            internal static readonly ConcurrentDictionary<char, T> _store_c = new();

            internal static readonly ConcurrentDictionary<(Type, Type), IEnumerable<T>> _cacheGeneric = new();
        }

        public static SemaphoreSlim GetGate<T>(char device, byte tolerance = 1)
        {
            lock (_txn_lock)
            {
                return GateFactory<SemaphoreSlim>._store_c.GetOrAdd(device, (x) => new SemaphoreSlim(tolerance, tolerance));
            }
        }
    }
}
