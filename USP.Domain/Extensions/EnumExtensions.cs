using USP.Domain.Enums;

namespace USP.Domain.Extensions;

public class EnumExtensions
{
    public static readonly string ValidCategoryList =
        string.Join(", ", Category.List.Select(x => x.Name + "-" + x.Value));
}