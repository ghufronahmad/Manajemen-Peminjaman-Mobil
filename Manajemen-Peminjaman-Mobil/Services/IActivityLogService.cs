using System.Threading.Tasks;

public interface IActivityLogService
{
    Task LogActivityAsync(string action, string description);
}