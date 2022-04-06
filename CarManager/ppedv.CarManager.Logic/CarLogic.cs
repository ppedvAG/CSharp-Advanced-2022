using ppedv.CarManager.Model;
using ppedv.CarManager.Model.Contracts;

namespace ppedv.CarManager.Logic
{
    public class CarLogic : ILogic
    {
        public IEnumerable<Car> GetCarsSorted(IEnumerable<Car> cars)
        {
            return cars.OrderBy(x => x.KW).ThenBy(x => x.Color);
        }
    }

    public class NEWCarLogic : ILogic
    {
        public IEnumerable<Car> GetCarsSorted(IEnumerable<Car> cars)
        {
            return cars.OrderBy(x => x.Manufacturer).ThenBy(x => x.Model).ThenBy(x => x.Color);
        }
    }
}