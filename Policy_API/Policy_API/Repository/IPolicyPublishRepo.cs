using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Policy_API.Repository
{
    public interface IPolicyPublishRepo
    {
        Task<string> PublishPolicyData(string TopicName, string Message, IConfiguration configuration);
    }
}
