using System;
namespace APIHealthChecker.Models
{
    public class EndPoint
    {

        public string Name { get; set; }
        public string Description { get; set; } 
        public string Url { get; set; }
        public bool IsPost { get; set; }

        public EndPoint()
        {
        }
    }
}
