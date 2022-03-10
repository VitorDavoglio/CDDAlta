namespace API_CodigoPenal.Responses
{
    public class Success<T>
    {
        public Success(T data)
        {
            Data = data;
        }

        public object Data { get; set; }
    }
}
