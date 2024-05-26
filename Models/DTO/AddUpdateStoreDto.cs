using System.ComponentModel.DataAnnotations;

namespace StoreApi;

public class AddUpdateStoreDto
{

    [Required]
    public String Item { get; set; } = String.Empty;
    [Required]
    public String Desciption { get; set; } = String.Empty;
    [Required]
    [Range(1, 9)]
    public int Quantity { get; set; } = 0;
    [Required]
    public String Owner { get; set; } = String.Empty;
}
