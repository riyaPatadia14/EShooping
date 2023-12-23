using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.Enums
{
    public enum ColorEnum
    {
        [Display(Name = "White")]
        White = 0,
        [Display(Name = "Banana Yellow")]
        BananaYellow = 1,
        [Display(Name = "Navy Blue")]
        NavyBlue = 2,
        [Display(Name = "Barn Red")]
        BarnRed = 3,
        [Display(Name = "Teal Green")]
        TealGreen = 4,
        [Display(Name = "Sky Blue")]
        SkyBlue = 5,
        [Display(Name = "Eerie Black")]
        EerieBlack = 6,
        [Display(Name = "Saddle Brown")]
        SaddleBrown = 7,
        [Display(Name = "Pearly Purple")]
        PearlyPurple = 8,
        [Display(Name = "Silver")]
        Silver = 9
    }
}
