using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
    public interface IEventBus
    {
        void Publish<T> (T @event);
        void Subscribe<T> (Action<T> handler);
    }
}
