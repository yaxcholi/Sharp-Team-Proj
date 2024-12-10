public class User
{
    // Parameterized constructor
    public User(int userId, string userName, string password, string userEmail, int phoneNumber, string street, string city, string postcode)
    {
        this.UserId = userId > 0 ? userId : 0; // Default to 0 if invalid
        this.UserName = !string.IsNullOrWhiteSpace(userName) ? userName : "Unknown";
        this.Password = !string.IsNullOrWhiteSpace(password) ? password : "default";
        this.UserEmail = !string.IsNullOrWhiteSpace(userEmail) ? userEmail : "default@example.com";
        this.PhoneNumber = phoneNumber > 0 ? phoneNumber : 0;
        this.Street = !string.IsNullOrWhiteSpace(street) ? street : "Unknown";
        this.City = !string.IsNullOrWhiteSpace(city) ? city : "Unknown";
        this.Postcode = !string.IsNullOrWhiteSpace(postcode) ? postcode : "0000";
    }


    // Properties and getter set methods
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UserEmail { get; set; }
    public int PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }

    // Update profile method
    public void UpdateProfile(int userId, string userName, string userEmail, int phoneNumber, string street, string city, string postcode)
    {
        if (userId <= 0) throw new ArgumentException("UserId must be greater than zero.");
        if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException("UserName cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(userEmail)) throw new ArgumentException("UserEmail cannot be null or empty.");
        if (phoneNumber <= 0) throw new ArgumentException("PhoneNumber must be a positive number.");
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(postcode)) throw new ArgumentException("Postcode cannot be null or empty.");

        this.UserId = userId;
        this.UserName = userName;
        this.UserEmail = userEmail;
        this.PhoneNumber = phoneNumber;
        this.Street = street;
        this.City = city;
        this.Postcode = postcode;

        Console.WriteLine("Profile updated successfully.");
    }
}