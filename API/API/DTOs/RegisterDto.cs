namespace API.DTOs;

public class RegisterDto
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DeviceId { get; set; }
}
