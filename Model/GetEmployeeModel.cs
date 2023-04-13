using HR_One.EndPoint;
using HR_One.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace HR_One.Model
{
    public class GetEmployeeModel
    {
        private GetEmployeeEndPoint _getEmployeeEndPoint;
        public List<EmployeeDetails> EmployeeDetails { get; set; }
        public GetEmployeeModel()
        {
            _getEmployeeEndPoint = new GetEmployeeEndPoint();
        }

        public async Task<Results> GetEmployeeDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getEmployeeEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<EmployeeResponseModel>(data);
                    EmployeeDetails = employee.EmployeeDetails;
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