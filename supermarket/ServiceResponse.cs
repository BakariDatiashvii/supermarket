namespace supermarket.EntityModel
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool? Success { get; set; }
        public string Massage { get; set; } = string.Empty;
    }
}
