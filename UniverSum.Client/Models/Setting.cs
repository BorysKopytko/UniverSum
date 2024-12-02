using SQLite;

namespace UniverSum.Client.Models
{
    public class Setting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value {  get; set; }
    }
}
