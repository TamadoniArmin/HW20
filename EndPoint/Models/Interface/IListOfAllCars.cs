namespace EndPoint.Models.Interface
{
    public interface IListOfAllCars
    {
        public void GetAllCars(CancellationToken cancellation);
        public void RemoveCarsInMemmory();
    }
}
