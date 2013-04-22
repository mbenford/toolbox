using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Toolbox.DomainEvents
{
    public class DefaultContainer : IHandlerContainer
    {
        private readonly Assembly assembly;

        public DefaultContainer(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            this.assembly = assembly;
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {         
            return from type in assembly.GetTypes()
                   where typeof(IHandlerOf<T>).IsAssignableFrom(type)
                   select Activator.CreateInstance(type) as IHandlerOf<T>;
        }
    }    
}