using SQLite;

namespace ProjectManager.Models
{
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon {  get; set; }
        public DateTime Date { get; set; }
    }
}
