using System.ComponentModel;

namespace VatanAPI.Domain.Models
{
    public enum EMarka:byte
    {
        [Description("LENOVO")]
        LENOVO = 1,

        [Description("ASUS")]
        ASUS = 2,

        [Description("SAMSUNG")]
        SAMSUNG = 3,

        [Description("ACER")]
        ACER = 4,

        [Description("APPLE")]
        APPLE = 5,

        [Description("DELL")]
        DELL = 6,

        [Description("HUAWEI")]
        HUAWEİ = 7,

        [Description("HP")]
        HP = 8,

        [Description("HOMETECH")]
        HOMETECH = 9
    }
}