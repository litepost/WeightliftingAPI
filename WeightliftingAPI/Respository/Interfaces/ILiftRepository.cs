using System.Linq.Expressions;

namespace WeightliftingAPI;

public interface ILiftRepository
{
    Task<IResponseModel> CreateLiftAsync(Lift lift);
    Task<IResponseDataModel<Lift>> GetLiftAsync(Expression<Func<Lift, bool>>? filter);
    Task<IResponseDataModel<IEnumerable<Lift>>> GetAllLiftsAsync(Expression<Func<Lift, bool>>? filter = null);
    Task<IResponseModel> UpdateLiftAsync(Lift lift);
    Task<IResponseModel> DeleteLiftAsync(int id);
}
