using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetProjectMessageModel
    {
        private GetProjectMessageEndPoint _projectMessageEndPoint;
        public List<MessageDetails> MessageDetails { get; set; }
        public int Id { get; set; }
        public GetProjectMessageModel()
        {
            _projectMessageEndPoint = new GetProjectMessageEndPoint();
        }
        public async Task<Results> GetProjectMessageDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _projectMessageEndPoint.Id = Id;
                var response = await _projectMessageEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var messages = JsonConvert.DeserializeObject<ProjectMessageResponseModel>(data);
                    MessageDetails = messages.MessageDetails;
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

