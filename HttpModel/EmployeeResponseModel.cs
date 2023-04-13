using Newtonsoft.Json;

namespace HR_One.HttpModel
{
    public class EmployeeResponseModel
    {
        [JsonProperty("error")]
        public int Error { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public List<EmployeeDetails> EmployeeDetails { get; set; }
    }

    public class EmployeeDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("complete_address")]
        public string CompleteAddress { get; set; }
    }
}
