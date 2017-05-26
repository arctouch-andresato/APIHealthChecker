using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using APIHealthChecker.Models;
using Newtonsoft.Json;

namespace APIHealthChecker.Repositories
{
    public class MobAppRepo
    {
        private const string APP_LIST_JSON_PATH = "APIHealthChecker.Data.AppList.json";
        public MobAppRepo()
        {
        }

        public static async Task<MobApp> GetMobApp(string appName)
        {
			var assembly = typeof(MobAppRepo).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream($"APIHealthChecker.Data.{appName}.json");
            using (var reader = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (MobApp)serializer.Deserialize(reader,typeof(MobApp));
            }
        }

        public static async Task<IEnumerable<MobApp>> GetAllAppNames()
        {
			var assembly = typeof(MobAppRepo).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(APP_LIST_JSON_PATH);
			using (var reader = new StreamReader(stream))
			{
				JsonSerializer serializer = new JsonSerializer();
                return (IList<MobApp>)serializer.Deserialize(reader, typeof(IList<MobApp>));
			}
        }
    }
}
