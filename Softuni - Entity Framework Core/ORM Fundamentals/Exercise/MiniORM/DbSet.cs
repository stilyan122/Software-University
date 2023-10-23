using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        public int Count => Entities.Count;

        public bool IsReadOnly => Entities.IsReadOnly;

        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Item cannot be null");
            }
            Entities.Add(entity);
            ChangeTracker.Add(entity);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = Entities.First();
                Remove(entity);
            }
        }

        public bool Contains(TEntity item) => Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex) 
            => Entities.CopyTo(array, arrayIndex);

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null");
            }
            var removedSuccesfully = Entities.Remove(item);
            if (removedSuccesfully)
            {
                ChangeTracker.Remove(item);
            }
            return removedSuccesfully;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToArray())
            {
                Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
            => Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
