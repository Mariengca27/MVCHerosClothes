using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerosMvc.Models
{

    [Table("RoupasHeros")]
    public class RoupasHeros
    {

        [Column("Id")]
        [Display(Name="Codigo")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }    


    }
}
