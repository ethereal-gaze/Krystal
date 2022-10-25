using System.Runtime.CompilerServices;

namespace Krystal
{
    /// <summary>
    /// Defines a type of content (i.e: projectiles, blocks etc)
    /// </summary>
    public abstract class ContentType : ILoadable
    {
        public readonly int ID;
        
        /// <summary>
        /// Display name
        /// </summary>
        public string Name { get; protected set; } 
        
        void ILoadable.Load()
        {
            SetDefaults();
            GameContent.Register(this);
        }

        /// <summary>
        /// Sets the default values for the properties of this type.
        /// </summary>
        protected abstract void SetDefaults();

        protected ContentType()
        {
            SetDefaults();
        }
    }
}

