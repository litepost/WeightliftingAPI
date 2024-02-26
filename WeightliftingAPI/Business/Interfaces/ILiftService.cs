namespace WeightliftingAPI;

public interface ILiftService
{
    Task<IResponseModel> CreateLiftAsync(Lift lift);
    Task<IResponseDataModel<Lift>> GetLiftAsync(Lift lift);
    Task<IResponseDataModel<IEnumerable<Lift>>> GetAllLiftsAsync();
    Task<IResponseModel> UpdateLiftAsync(Lift lift);
    Task<IResponseModel> DeleteLiftAsync(int id);
    Task<IResponseDataModel<Lift>> GetLiftByName(LiftName name);
}
