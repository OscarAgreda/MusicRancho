using System.ComponentModel.DataAnnotations;
namespace MusicRancho_Web.Models.Dto
{
    public class RanchoNumberUpdateDTO
    {
        [Required]
        public int RanchoNo { get; set; }
        [Required]
        public int RanchoID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
