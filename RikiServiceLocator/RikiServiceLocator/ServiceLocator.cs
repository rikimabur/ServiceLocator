using System;
using System.Collections.Generic;

namespace RikiServiceLocator
{
    public class ServiceLocator
    {
        public static readonly IDictionary<Type, object> _serviceCache;
        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());
        static ServiceLocator()
        {
            _serviceCache = new Dictionary<Type, object>();
        }
        public void Register<T>(T service)
        {
            var key = typeof(T);
            if (_serviceCache.ContainsKey(key))
            {
                _serviceCache[key] = service;
            }
            else
            {
                _serviceCache.Add(key, service);
            }
        }
        public T GetService<T>()
        {
            var key = typeof(T);
            if (_serviceCache.ContainsKey(key))
                return (T)_serviceCache[key];
            throw new ArgumentException(string.Format("Type '{0}' has not been registered.", key.Name));
        }
    }
}
