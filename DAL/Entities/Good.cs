using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Good
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
        
        public ICollection<UserBasket> InBaskets { get; set; }
    }
}