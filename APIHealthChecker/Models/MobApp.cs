using System.Collections.Generic;

namespace APIHealthChecker.Models
{
    public class MobApp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<EndPoint> EndPoints { get; set; }
        public string FileName { get; set; }
        public MobApp()
        {
        }
    }
}
