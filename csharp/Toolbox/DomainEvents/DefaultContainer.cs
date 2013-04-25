using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Toolbox.DomainEvents
{
    public class DefaultContainer : IHandlerContainer
    {
        private readonly _Assembly assembly;
        private readonly ConcurrentDictionary<Type, object> cache;

        public DefaultContainer(Assembly assembly)
            : this(assembly as _Assembly)
        {
        }

        // Used for unit testing
        internal DefaultContainer(_Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            this.assembly = assembly;
            cache = new ConcurrentDictionary<Type, object>();
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            return cache.GetOrAdd(typeof(T), key => LoadHandlersFromAssembly<T>()) as IEnumerable<IHandlerOf<T>>;
        }

        private IEnumerable<IHandlerOf<T>> LoadHandlersFromAssembly<T>() where T: IDomainEvent
        {
            return from type in assembly.GetTypes()
                   where typeof(IHandlerOf<T>).IsAssignableFrom(type)
                   select Activator.CreateInstance(type) as IHandlerOf<T>;
        }
    }
}