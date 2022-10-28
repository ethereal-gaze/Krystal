using System.Runtime.CompilerServices;

namespace Krystal
{
    public abstract class ContentType : ILoadable
    {
        public readonly int ID;

        public string Name { get; protected set; } 
        
        void ILoadable.Load()
        {
            SetDefaults();
        }
        
        protected abstract void SetDefaults();
    }
}

