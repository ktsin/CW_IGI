using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class GoodDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string PathToPhotoGallery { get; set; }

        public string MainPhotoName { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public uint Price { get; set; }

        public int CategoryId { get; set; }
        
        public ushort Quantity { get; set; }
    }
}