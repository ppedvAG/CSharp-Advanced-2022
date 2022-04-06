namespace ppedv.CarManager.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public bool IsElectric { get; set; }
        public int KW { get; set; }
        public string Color { get; set; }
    }
}