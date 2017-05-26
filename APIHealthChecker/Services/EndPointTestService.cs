using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIHealthChecker.Models;

namespace APIHealthChecker.Services
{
    public class EndPointTestService
    {
        public EndPointTestService()
        {
        }

        public static async Task<TestResult> TestEndPoint(string url, bool isPost)
        {
            try
            {
                HttpClient client = new HttpClient();
                string response = "";
                if(isPost)
                {
                    var postResult = await client.PostAsync(url,new StringContent(""));
                    response = await postResult.Content.ReadAsStringAsync();
                }
                else
                {
					response = await client.GetStringAsync(url);
				}

				return new TestResult() 
                { 
                    IsWorking = !string.IsNullOrWhiteSpace(response), 
                    Details = response
                };
			}
			catch (Exception exception)
			{
                return new TestResult()
                {
                    IsWorking = false,
                    Details = exception.ToString()
				};
			}
        }

        public static async Task<IList<TestResult>> TestAllAppEndPoints(MobApp app)
        {
            var results = new List<TestResult>();
            foreach(EndPoint endPoint in app.EndPoints)
            {
                var testResult = await TestEndPoint(endPoint.Url, endPoint.IsPost);
                testResult.EndPoint = endPoint;
                results.Add(testResult);
            }

            return results;
        }
    }
}
