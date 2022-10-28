namespace ParcelDelivery.Logic.Exceptions
{
    public class BaseException
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
