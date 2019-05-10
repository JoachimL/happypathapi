using System;

namespace HappyPathApi.Common
{

    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string type, int entityId) : base("Entity of type " + type + " with ID " + entityId + " was not found")
        {
            Type = type;
            EntityId = entityId;
        }

        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, EntityNotFoundException inner) : base(message, inner) { }
        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public string Type { get; }
        public int EntityId { get; }
    }
}