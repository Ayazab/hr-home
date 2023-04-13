using HR_One.HttpModel;
using Refit;

namespace HR_One.Interface
{
    public interface IProjectApi
    {
        [Get("/projects")]
        Task<HttpResponseMessage> GetProjectList();

        [Get("/{Id}/projects")]
        Task<HttpResponseMessage> GetEmployeeProjectList(int Id);

        [Get("/{Id}/messages")]
        Task<HttpResponseMessage> GetProjectMessageList(int Id);

        [Post("/messages")]
        Task<HttpResponseMessage> AddMessage([Body] MessageRequestModel model);

        [Put("/messages/{id}")]
        Task<HttpResponseMessage> UpdateMessage([Body] MessageRequestModel model, int id);

        [Delete("messages/{id}")]
        Task<HttpResponseMessage> DeleteMessage(int id);
    }
}
