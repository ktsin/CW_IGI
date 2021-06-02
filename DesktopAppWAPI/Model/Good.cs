using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopAppWAPI
{
    public class Good
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="ID магазина")]
        public int StoreId { get; set; }

        public string PathToPhotoGallery { get; set; }

        [Display(Name = "ID галвного фото")]
        public string MainPhotoName { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Наименование товара")]
        public string Name { get; set; }

        [Display(Name = "Цена, коп.")]
        public uint Price { get; set; }

        [Display(Name = "ID категории")]
        public int CategoryId { get; set; }

        [Display(Name = "Количество")]
        public ushort Quantity { get; set; }
    }
}