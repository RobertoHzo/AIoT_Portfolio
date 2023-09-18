using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTApps.Models
{
    [Table("Tokens")]
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Data { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdSource { get; set; }
        [ForeignKey("IdSource")]
        public Source Source { get; set; }

        internal List<Token> GetToken()
        {
            throw new NotImplementedException();
        }
    } 
}