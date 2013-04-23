using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Toolbox.DomainEvents
{
    public class DefaultContainer : IHandlerContainer
    {
        private readonly _Assembly assembly;
        private readonly IDictionary<Type, object> cache;

        public DefaultContainer(Assembly assembly)
            : this(assembly as _Assembly)
        {
        }

        // Used for unit testing
        internal DefaultContainer(_Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            this.assembly = assembly;
            cache = new Dictionary<Type, object>();
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            IEnumerable<IHandlerOf<T>> handlers;

            if (cache.ContainsKey(typeof(T)))
                handlers = cache[typeof(T)] as IEnumerable<IHandlerOf<T>>;
            else
            {
                handlers = from type in assembly.GetTypes()
                           where typeof(IHandlerOf<T>).IsAssignableFrom(type)
                           select Activator.CreateInstance(type) as IHandlerOf<T>;
                cache.Add(typeof(T), handlers);
            }

            return handlers;
        }
    }
}