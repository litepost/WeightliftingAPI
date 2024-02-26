using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WeightliftingAPI;

public class LiftRespository(LiftListDbContext liftDb) : ILiftRepository
{
    private readonly LiftListDbContext _liftDb = liftDb;

    public async Task<IResponseModel> CreateLiftAsync(Lift lift)
    {
        try {
            _liftDb.LiftList.Add(lift);

            // SaveChangesAsync returns the number of rows affected -> adding 1 record so 1 should be returned
            return await _liftDb.SaveChangesAsync() == 1 ?
                new ResponseModel { Success = true } :
                new ResponseModel { Success = false };
        }
        catch (Exception) {
            throw;
        }

    }

    public async Task<IResponseModel> DeleteLiftAsync(int id)
    {
        try {
            var lift = await GetLiftAsync(x => x.Id == id);

            if (!lift.Success) 
                return new ResponseModel { Success = false };

            _liftDb.Remove(lift.Data);
            
            return await _liftDb.SaveChangesAsync() == 1 ?
                new ResponseModel { Success = true } :
                new ResponseModel { Success = false };
        }
        catch (Exception) {
            throw;
        }
    }

    public async Task<IResponseDataModel<IEnumerable<Lift>>> GetAllLiftsAsync(Expression<Func<Lift, bool>>? filter = null)
    {
        return new ResponseDataModel<IEnumerable<Lift>> 
        {
            Success = true,
            Data = await _liftDb.LiftList.ToListAsync()
        };
    }

    public async Task<IResponseDataModel<Lift>> GetLiftAsync(Expression<Func<Lift, bool>>? filter)
    {
        try {
            if (filter is null) 
                return new ResponseDataModel<Lift> { Success = false, Message = "Invalid Search" };
            
            var lift = await _liftDb.LiftList.SingleOrDefaultAsync(filter);

            if (lift is null)
                return new ResponseDataModel<Lift> { Success = false, Message = "Lift not found" };
            else
                return new ResponseDataModel<Lift> { Success = true, Data = lift };
        }
        catch (Exception) {
            throw;
        }
    }

    public async Task<IResponseModel> UpdateLiftAsync(Lift lift)
    {
        try {
            lift.Id = lift.Id;
            lift.Name = lift.Name;
            lift.Weight = lift.Weight;
            lift.Reps = lift.Reps;

            _liftDb.LiftList.Update(lift);

            return await _liftDb.SaveChangesAsync() == 1 ?
                new ResponseModel { Success = true} :
                new ResponseModel { Success = false };
        }
        catch (Exception) {
            throw;
        }
    }
}
