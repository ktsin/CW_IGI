using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Good
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        
        public ulong StoreId { get; set; }
        
        public string PathToPhotoGallery { get; set; }
        
        public string MainPhotoName { get; set; }
        
        public string Description { get; set; }
        
        public string Name { get; set; }
        
        public uint Price { get; set; }
        
        public uint CategoryId { get; set; }
    }
}