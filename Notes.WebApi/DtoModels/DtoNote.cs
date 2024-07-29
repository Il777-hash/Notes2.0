namespace Notes.WebApi.DtoModels
{
    public class DtoNote
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string[] TagNames { get; set; }
    }
}
