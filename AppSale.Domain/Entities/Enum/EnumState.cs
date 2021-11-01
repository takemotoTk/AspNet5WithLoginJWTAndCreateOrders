using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Entities.Enum
{
    public enum EnumState
    {
        Acre,
        Alagoas,

        [Display(Name = "Amapá")]
        Amapa,
        Amazonas,
        Bahia,

        [Display(Name = "Ceará")]
        Ceara,

        [Display(Name = "Distrito Federal")]
        DistritoFederal,

        [Display(Name = "Espírito Santo")]
        EspiritoSanto,

        [Display(Name = "Goiás")]
        Goias,

        [Display(Name = "Maranhão")]
        Maranhao,

        [Display(Name = "Mato Grosso")]
        MatoGrosso,

        [Display(Name = "Mato Grosso do Sul")]
        MatoGrossodoSul,

        [Display(Name = "Minas Gerais")]
        MinasGerais,

        [Display(Name = "Pará")]
        Para,

        [Display(Name = "Paraíba")]
        Paraiba,

        [Display(Name = "Paraná")]
        Parana,
        Pernambuco,

        [Display(Name = "Piauí")]
        Piaui,

        [Display(Name = "Rio de Janeiro")]
        RiodeJaneiro,

        [Display(Name = "Rio Grande do Norte")]
        RioGrandedoNorte,

        [Display(Name = "Rio Grande do Sul")]
        RioGrandedoSul,

        [Display(Name = "Rondônia")]
        Rondonia,

        Roraima,

        [Display(Name = "Santa Catarina")]
        SantaCatarina,

        [Display(Name = "São Paulo")]
        SaoPaulo,

        Sergipe,
        Tocantins
    }
}
