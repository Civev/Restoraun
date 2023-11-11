namespace Restoraun.Models
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMassage { get; set; } = "";
        public List<string> ErrorMassages { get; set; }
    }
}
