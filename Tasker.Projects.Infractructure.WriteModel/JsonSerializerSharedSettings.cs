using Newtonsoft.Json;

namespace Tasker.Projects.Infractructure.WriteModel
{
    public static class JsonSerializerSharedSettings
    {
        public static JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };
    }
}
