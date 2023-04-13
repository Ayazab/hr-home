using HR_One.HttpModel;
using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class UpdateMessageEndPoint
    {
        public int Id { get; set; }
        public MessageRequestModel MessageRequestModel { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IProjectApi>("https://api.onlinewebtutorblog.com").UpdateMessage(MessageRequestModel, Id);
        }
    }
}
