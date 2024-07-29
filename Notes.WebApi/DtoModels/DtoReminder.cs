namespace Notes.WebApi.DtoModels
{
    public class DtoReminder
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string[] TagNames { get; set; }
        public DateTime AlertDateTime { get; set; }
    }
}
