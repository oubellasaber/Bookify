using Bookify.Domain.Events;

namespace Application.Abtractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string body);
    }
}
