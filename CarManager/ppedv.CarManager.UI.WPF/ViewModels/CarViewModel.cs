using ppedv.CarManager.Model;
using ppedv.CarManager.Model.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ppedv.CarManager.UI.WPF.ViewModels
{
    public class CarViewModel
    {
        public ObservableCollection<Car> CarList { get; set; }

        public Car SelectedCar { get; set; }

        public CarViewModel() : this(null)
        { }

        public CarViewModel(ILogic logic)
        {
            var data = new List<Car>();
            data.Add(new Car() { Id = 1, Manufacturer = "YAYAYA", Model = "B11", KW = 82, Color = "Blue" });
            data.Add(new Car() { Id = 2, Manufacturer = "YAYAYA", Model = "B22", KW = 122, Color = "Red" });

            if (logic != null)
                CarList = new ObservableCollection<Car>(logic.GetCarsSorted(data));
        }
    }
}
