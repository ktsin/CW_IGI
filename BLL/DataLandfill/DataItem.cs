using System.ComponentModel.DataAnnotations;

namespace BLL.DataLandfill
{
    public class DataItem
    {
        [Key] public string Id { get; set; }

        public string Base64String { get; set; }
    }
}