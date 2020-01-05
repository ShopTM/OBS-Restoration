using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public enum UserType
    {
        Admin = 1,
        [Display(Name = "Level I")]
        [Description("Level I")]
        LevelI = 2,
        [Display(Name = "Level II")]
        [Description("Level II")]
        LevelII = 3,

        [Display(Name = "Level III")]
        [Description("Level III")]
        LevelIII = 4,
    }
    public enum ClientType
    {
        Owner = 1,
        Manager = 2,
        Enginner = 3
    }
}
