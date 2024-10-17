using Newtonsoft.Json;

namespace Basiccrud.Models
{
    public class AdminModel
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; } // e.g., SuperAdmin, Manager, etc.

        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; } // Consider encrypting this field

        [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; } // Date when admin was created

        [JsonProperty(PropertyName = "lastLogin", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastLogin { get; set; } // Nullable for first-time admins

        [JsonProperty(PropertyName = "isActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsActive { get; set; } // To activate/deactivate admin account

        [JsonProperty(PropertyName = "permissions", NullValueHandling = NullValueHandling.Ignore)]
        public string Permissions { get; set; } // A set of permissions like "view", "edit", etc.

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } // Active, Suspended, etc.
    }
}
