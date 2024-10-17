    using Basiccrud.Common;
    using Newtonsoft.Json;

    namespace Basiccrud.Entities
    {
        public class Visitor: BaseEntity
        {

            [JsonProperty(PropertyName = "firstName", NullValueHandling = NullValueHandling.Ignore)]
            public string FirstName { get; set; }

            [JsonProperty(PropertyName = "lastName", NullValueHandling = NullValueHandling.Ignore)]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
            public string PhoneNumber { get; set; }

            [JsonProperty(PropertyName = "visitDate", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime VisitDate { get; set; }

            [JsonProperty(PropertyName = "checkInTime", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? CheckInTime { get; set; } // Nullable for optional

            [JsonProperty(PropertyName = "checkOutTime", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? CheckOutTime { get; set; } // Nullable for optional

            [JsonProperty(PropertyName = "purposeOfVisit", NullValueHandling = NullValueHandling.Ignore)]
            public string PurposeOfVisit { get; set; }

            [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
            public string Status { get; set; }
        }
    }
