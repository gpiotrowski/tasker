using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace Tasker.Users.API.Client
{
    public class UserApiClient : IUserApiClient
    {
        public Task<bool> CheckIfUserExist(Guid userId)
        {
            //TODO: Get url from configuration file
            var client = new RestClient("http://localhost:60348");

            var request = new RestRequest("api/Users/CheckIfUserExist", Method.GET);
            request.AddHeader("X-Gateway-Target", "Users");
            request.AddParameter("id", userId);

            var requestTask = new TaskCompletionSource<bool>();

            client.ExecuteAsync(request, response => {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    requestTask.SetResult(true);
                }
                else
                {
                    requestTask.SetResult(false);
                }
            });

            return requestTask.Task;
        }
    }
}
