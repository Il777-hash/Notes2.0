namespace Notes.WebApi.DtoModels
{
    public class DtoNote
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string[] TagNames { get; set; } = new string[0];
    }
}
