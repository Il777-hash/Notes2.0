namespace Notes.WebApi.DtoModels
{
    public class DtoReminder
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string[] TagNames { get; set; } = new string[0];
        public DateTime AlertDateTime { get; set; }
    }
}
