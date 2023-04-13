using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class UpdateMessageModel
    {
        private UpdateMessageEndPoint _updateMessageEndPoint;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public UpdateMessageModel()
        {
            _updateMessageEndPoint= new UpdateMessageEndPoint();
        }

        public async Task<Results> UpdateMessageDetailsAsync()
        {


            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new MessageRequestModel()
                {
                    Title = Title,
                    Body = Body
                };

                _updateMessageEndPoint.Id = Id;
                _updateMessageEndPoint.MessageRequestModel = requestModel;
                var response = await _updateMessageEndPoint.ExecuteAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<ProjectMessageResponseModel>(data);

                    return new Results()
                    {
                        IsSuccess = true,
                        Message = "Message Updated successfully"
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
