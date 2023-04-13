using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class GetProjectMessageEndPoint
    {
        public int Id { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IProjectApi>("https://api.onlinewebtutorblog.com/projects").GetProjectMessageList(Id);
        }

    }
}
