
namespace WeightliftingAPI;

public class LiftService(ILiftRepository liftRepository) : ILiftService
{
    private readonly ILiftRepository _liftRepository = liftRepository;

    public async Task<IResponseModel> CreateLiftAsync(Lift lift)
    {
        try {
            var result = await _liftRepository.CreateLiftAsync(lift);
            return result.Success.Equals(true) ? 
                new ResponseModel { Success = true} : 
                new ResponseModel { Success = false};
        }
        catch (Exception) {
            throw;
        }
    }

    public async Task<IResponseModel> DeleteLiftAsync(int id)
    {
        try
        {
            var getResult = await _liftRepository.GetLiftAsync(x => x.Id == id);
            if (!getResult.Success) 
                return new ResponseModel { Success = false};

            var result = await _liftRepository.DeleteLiftAsync(id);

            return result.Success.Equals(true) ? 
                new ResponseModel { Success = true } :
                new ResponseModel { Success = false};
        }
        catch (Exception) {
            throw;
        }
    }

    public async Task<IResponseDataModel<IEnumerable<Lift>>> GetAllLiftsAsync()
    {
        try {
            var result = await _liftRepository.GetAllLiftsAsync();

            return result.Success.Equals(true) ? 
                new ResponseDataModel<IEnumerable<Lift>> { Success = true, Data = result.Data} : 
                new ResponseDataModel<IEnumerable<Lift>> { Success = false};
        }
        catch (System.Exception) {
            throw;
        }
    }

    public async Task<IResponseDataModel<Lift>> GetLiftAsync(Lift lift)
    {
        try {
            var result = await _liftRepository.GetLiftAsync(x => x.Id == lift.Id);

            return result.Success.Equals(true) ? 
                new ResponseDataModel<Lift> { Success = true, Data = result.Data} : 
                new ResponseDataModel<Lift> { Success = false };
        }
        catch (System.Exception) {
            throw;
        }
    }

    public async Task<IResponseDataModel<Lift>> GetLiftByName(LiftName name)
    {
        try {
            var result = await _liftRepository.GetLiftAsync(x => x.Name == name);

            return result.Success.Equals(true) ? 
                new ResponseDataModel<Lift> { Success = true, Data = result.Data } : 
                new ResponseDataModel<Lift> { Success = false};
        }
        catch (Exception) {
            throw;
        }
    }

    public async Task<IResponseModel> UpdateLiftAsync(Lift lift)
    {
        try {
            var result = await _liftRepository.UpdateLiftAsync(lift);

            return result.Success.Equals(true) ? 
                new ResponseModel { Success = true } :
                new ResponseModel { Success = false};
        }
        catch (Exception) {
            throw;
        }
    }
}
