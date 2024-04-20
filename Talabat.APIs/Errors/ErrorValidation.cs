namespace Talabat.APIs.Errors
{
    public class ErrorValidation : ApiResponse
    {

        public IEnumerable<string> Errors { get; set; }


        public ErrorValidation() : base(400)
        {
            Errors = new List<string>();
        }
    }
}
