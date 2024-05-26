namespace StoreApi;

public class StoreDto
{
    public Guid Id { get; set; }
    public String Item { get; set; } = String.Empty;
    public String Desciption { get; set; } = String.Empty;
    public int Quantity { get; set; } = 0;
    public String Owner { get; set; } = String.Empty;

}
