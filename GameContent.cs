namespace Krystal
{
    public static class GameContent
    {
        private static readonly List<ContentType> LoadedContent = new();

        /// <summary>
        /// Loads content singleton and gives an ID for later access
        /// </summary>
        /// <param name="type">Singleton to load</param>
        /// <returns>ID to access later using Get()</returns>
        public static int Register(ContentType type)
        {
            LoadedContent.Add(type);
            return LoadedContent.Count - 1;
        }
        
        /// <summary>
        /// Returns a loaded Content singleton
        /// </summary>
        /// <param name="id"> ID in which was given when registered</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="TypeLoadException"></exception>
        public static T Get<T>(int id) where T : ContentType
        {
            if (LoadedContent[id] is not T ret)
                throw new TypeLoadException();
            
            return ret;
        }
    }
}

