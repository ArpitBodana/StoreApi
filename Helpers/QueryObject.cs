namespace StoreApi;

public class QueryObject
{
    public String? Item { get; set; } = null;
    public String? Owner {get;set;} = null;
    public String? SortBy { get; set; }=null;
    public bool IsDescending {get;set;}=false;

    public int PageNumber {get;set;}=1;
    public int PageSize {get;set;}=10;

}
