using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class AddMessageModel
    {
        private AddMessageEndPoint _addMessageEndPoint;
        public string Title { get; set; }
        public string Body { get; set; }

        public AddMessageModel()
        {
            _addMessageEndPoint = new AddMessageEndPoint();
        }

        public async Task<Results> AddMessageDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new MessageRequestModel()
                {
                    Title= Title,
                    Body= Body
                };

                _addMessageEndPoint.MessageRequestModel = requestModel;
                var response = await _addMessageEndPoint.ExecuteAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<ProjectMessageResponseModel>(data);

                    return new Results()
                    {
                        IsSuccess = true,
                        Message = "Message added successfully"
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