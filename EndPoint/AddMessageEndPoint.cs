using HR_One.HttpModel;
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class AddMessageEndPoint
    {
        public MessageRequestModel MessageRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IProjectApi>("https://api.onlinewebtutorblog.com").AddMessage(MessageRequestModel);
        }
    }
}
