using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.StorageTableRepository
{
    public abstract class ChildEntity<TKey> : Entity<TKey>, IChildEntity<TKey>
    {
    }
}
