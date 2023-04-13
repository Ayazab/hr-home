using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetProjectModel
    {
        private GetProjectEndPoint _getProjectEndPoint;
        public List<ProjectDetails> ProjectDetails { get; set; }
        public GetProjectModel()
        {
            _getProjectEndPoint = new GetProjectEndPoint();
        }

        public async Task<Results> GetProjectDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getProjectEndPoint.ExecuteAsync();               
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var project = JsonConvert.DeserializeObject<ProjectResponseModel>(data);
                    ProjectDetails = project.ProjectDetails;
                    return new Results()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Results()
                    {
                        IsSuccess = false,
                        Message = "Something went wrong"
                    };
                }
            }
            else
            {
                return new Results()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }
    }
}
