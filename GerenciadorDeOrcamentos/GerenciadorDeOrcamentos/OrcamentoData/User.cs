using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class User
    {
        public int idusuario { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "O campo de Email deve ser preenchido.")]
        public string emailusuario { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "O campo de Senha deve ser preenchido.")]
        public string senhausuario { get; set; }
    }
}
