using CourseSignUp.Application.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Queries
{
    public interface IGetStatisticsCommand
    {
        Task<List<GetStatisticsResponse>> ExecuteAsync();
    }
}