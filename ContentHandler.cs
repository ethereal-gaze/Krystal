using System.Reflection;
using Krystal.Content;
using Krystal.Graphics;

namespace Krystal
{
    /// <summary>
    /// Handles loading content and accessing content singletons.
    /// </summary>
    internal static class ContentHandler
    {
        private static readonly Dictionary<Type, ILoadable> LoadedGameContent = new();
        private static readonly Dictionary<TextureID, Texture2D> LoadedTextures = new();

        public static void LoadContent()
        {
            var loadableInstances = from t in Assembly.GetExecutingAssembly().GetTypes()
                where (t.GetInterfaces().Contains(typeof(ILoadable)) && !t.IsAbstract) && t.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(t) as ILoadable;

            foreach (var instance in loadableInstances)
            {
                instance.Load();
                if (LoadedGameContent.ContainsKey(instance.GetType()))
                    throw new TypeLoadException("Type already loaded");
                
                Console.WriteLine("ContentHandler: Loading {0}", instance);
                LoadedGameContent.Add(instance.GetType(), instance);
            }
        }
        
        public static T GameContent<T>() where T : class
        {
            Type contentType = typeof(T);
            
            if (!typeof(ILoadable).IsAssignableFrom(contentType))
                throw new ArgumentException("Provided type is not ILoadable");

            if (!LoadedGameContent.ContainsKey(contentType))
                throw new Exception("Type not loaded");

            if (LoadedGameContent[contentType] == null)
                throw new Exception("Type not loaded");

            return LoadedGameContent[contentType] as T;
        }

        public static void LoadTexture(TextureID textureId, string path)
        {
            if (LoadedTextures.ContainsKey(textureId))
                throw new Exception("Texture already loaded");
            
            LoadedTextures.Add(textureId, new Texture2D(path));
        }

        public static Texture2D Texture(TextureID textureId)
        {
            if (!LoadedTextures.ContainsKey(textureId))
                throw new Exception("Texture not loaded");

            return LoadedTextures[textureId];
        }
    }
}

