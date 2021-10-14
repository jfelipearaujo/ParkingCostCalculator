using ParkCostCalc.Core.Models;

namespace ParkCostCalc.Core.Services
{
    public interface IEmailService
    {
        bool SendEmailToSupport(Contact contact);
    }
}
