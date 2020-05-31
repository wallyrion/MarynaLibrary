using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public static class RepositoryListener
    {
        public static event Action<string, object> onUpdate;

        public static void Update(string eventType, object entity)
        {
            onUpdate(eventType, entity);
        }
    }
}
