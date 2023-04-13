using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class DeleteMessageModel
    {
        private DeleteMessageEndPoint _deleteMessageEndPoint;
        public int Id { get; set; }
        public DeleteMessageModel()
        {
            _deleteMessageEndPoint = new DeleteMessageEndPoint();
        }
        public async Task<Results> DeleteMessageDetailAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _deleteMessageEndPoint.Id = Id;
                var response = await _deleteMessageEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<ProjectMessageResponseModel>(data);
                    return new Results()
                    {
                        IsSuccess = true,
                        Message = "Message deleted successfully"
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