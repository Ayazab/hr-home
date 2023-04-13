using HR_One.Interface;
using Refit;

namespace HR_One.EndPoint
{
    public class GetEmployeeEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IEmployeeApi>("https://api.onlinewebtutorblog.com").GetEmployeeList();
        }
    }
}
