namespace ppedv.CarManager.Model.Contracts
{
    public interface ILogic
    {
        IEnumerable<Car> GetCarsSorted(IEnumerable<Car> cars);
    }
}
