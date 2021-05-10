using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class CategoryDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PicturePath { get; set; }

        public string Description { get; set; }
    }
}