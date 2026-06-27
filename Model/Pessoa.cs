using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    ///<summary>
    /// Classe pessoa que representa um registro de pessoa no banco de dados
    ///</summary>
    public class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(80)]
        public string RazaoSocial { get; set; } = string.Empty;

        [StringLength(18)]
        public string CnpjCpf { get; set; } = string.Empty;

        [StringLength(120)]
        public string Email { get; set; } = string.Empty;

        [StringLength(15)]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(100)]
        public string Usuario { get; set; } = string.Empty;

        [StringLength(12)]
        public string Senha { get; set; } = string.Empty;

    }
}
