using System;
using System.Collections.Generic;

namespace Panuon.WPF
{
    public static class IoC
    {
        #region Class
        private class IoCServiceMetadata
        {
            internal IoCServiceMetadata(object instance) 
            {
                Strategy = MultiplexingPatterns.Singleton;
                Instance = instance;
            }

            internal IoCServiceMetadata(Func<object> getInstance,
                MultiplexingPatterns strategy)
            {
                Strategy = strategy;
                GetInstance = getInstance;
            }

            public MultiplexingPatterns Strategy { get; set; }

            public object Instance { get; set; }

            public Func<object> GetInstance { get; set; }
        }

        #endregion

        private static Dictionary<object, IoCServiceMetadata> _metadatas 
            = new Dictionary<object, IoCServiceMetadata>();

        public static void Set<TService>(TService service)
        {
            var key = typeof(TService);
            _metadatas[key] = new IoCServiceMetadata(service);
        }

        public static void Set<TService>(object key,
            TService service)
        {
            _metadatas[key] = new IoCServiceMetadata(service);
        }

        public static void Set<TService>(Type serviceType,
            MultiplexingPatterns strategy)
        {
            var key = serviceType;
            _metadatas[key] = new IoCServiceMetadata(new Func<object>(() =>
            {
                return Activator.CreateInstance(serviceType);
            }), strategy);
        }

        public static void Set<TService>(object key,
            Type serviceType,
            MultiplexingPatterns strategy)
        {
            _metadatas[key] = new IoCServiceMetadata(new Func<object>(() =>
            {
                return Activator.CreateInstance(serviceType);
            }), strategy);
        }

        public static void Set<TService>(Func<TService> getService,
            MultiplexingPatterns strategy)
        {
            var key = typeof(TService);
            _metadatas[key] = new IoCServiceMetadata(new Func<object>(() =>
            {
                return getService.Invoke();
            }), strategy);
        }

        public static void Set<TService>(object key, 
            Func<TService> getService,
            MultiplexingPatterns strategy)
        {
            _metadatas[key] = new IoCServiceMetadata(new Func<object>(() =>
            {
                return getService.Invoke();
            }), strategy);
        }

        public static TService Get<TService>(object key = null)
        {
            key = key ?? typeof(TService);
            var metadata = _metadatas[key];
            if(metadata.Instance != null)
            {
                return (TService)metadata.Instance;
            }
            else
            {
                if(metadata.Strategy == MultiplexingPatterns.Singleton)
                {
                    metadata.Instance = metadata.GetInstance();
                    return (TService)metadata.Instance;
                }
                else
                {
                    return (TService)metadata.GetInstance();
                }
            }
            return default;
        }

    }
}
