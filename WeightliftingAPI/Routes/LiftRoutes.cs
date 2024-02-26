namespace WeightliftingAPI;

public class LiftRoutes
{
    public static async Task<IResult> GetAllLifts(ILiftService liftService) 
    {
        var result = await liftService.GetAllLiftsAsync();
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }

    public static async Task<IResult> GetLift(int id, ILiftService liftService)
    {
        var result = await liftService.GetLiftAsync(new Lift {Id = id});
        return result.Success ? 
            TypedResults.Ok(result) : 
            TypedResults.BadRequest(result);
    }

    public static async Task<IResult> GetLiftByName(ILiftService liftService, LiftName name)
    {
        var result = await liftService.GetLiftByName(name);
        return result.Success ? 
            TypedResults.Ok(result) : 
            TypedResults.BadRequest(result);
    }

    public static async Task<IResult> CreateLift(Lift lift, ILiftService liftService)
    {
        var result = await liftService.CreateLiftAsync(lift);
        return result.Success ? 
            TypedResults.Created($"/lifts/{lift.Id}", result) : 
            TypedResults.BadRequest(result);
    }

    public static async Task<IResult> UpdateLift(Lift lift, ILiftService liftService)
    {
        var result = await liftService.UpdateLiftAsync(lift);
        return result.Success ? 
            TypedResults.Ok(result) : 
            TypedResults.BadRequest(result);
    }

    public static async Task<IResult> DeleteLift(int id, ILiftService liftService)
    {
        var result = await liftService.DeleteLiftAsync(id);
        return result.Success ? 
            TypedResults.Ok(result) : 
            TypedResults.BadRequest(result);
    }

    public static Task<IResult> FakeError() 
    {
        throw new InvalidOperationException("Fake error");
    }

}
