namespace FiCon.Helpers
{
    internal class Helper
    {
        internal static T ScopeEntity<T>(string entityType) where T : class
        {
            var assemblyName = entityType.Remove(entityType.IndexOf('.'));

            if (Activator.CreateInstance(assemblyName, entityType)?.Unwrap() is not T entity) throw new EntryPointNotFoundException(nameof(FiCon));

            return entity;
        }

        internal static T ScopeEntity<T>() where T : class
        {
            var instance = AppDomain.CurrentDomain.GetAssemblies().SelectMany((x) => x.GetTypes())
                              .Where((t) => t.IsAssignableTo(typeof(T)))
                              .Where((t) => !t.IsAbstract && !t.IsInterface).ToList()
                              .FirstOrDefault();
            if (instance is not null)
            {
                if (Activator.CreateInstance(instance) is T t) return t;
            }
            throw new EntryPointNotFoundException(nameof(FiCon));
        }
    }
}
