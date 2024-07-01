using System.ComponentModel.DataAnnotations;

namespace Facebook.Contracts.Friends.SearchUsersByFirstAndLastNamesRequest;

public record SearchUsersByFirstAndLastNamesRequest
{
    // [Required(ErrorMessage = "{PropertyName} must not be empty")]
    // public Guid UserId { get; set; }
    
    [Required(ErrorMessage = "{PropertyName} must not be empty")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "{PropertyName} must not be empty")]
    public string LastName { get; set; }
}