using System.Web.Http;
using System.Net;

[RoutePrefix("api/values")]
public class ValuesController : ApiController
{
    [HttpGet]
    [Route("{Path1}/{Path2}")]
    public object Get([FromUri]string Path1, [FromUri] string Path2, string query1, string query2, string query3)
    {
        return new ResponseModel(Path1, Path2, query1, query2, query3);
    }
}


public class ResponseModel
{
    public string Path1 { get; set; }
    public string DecodedPath1 { get; set; }
    public string Path2 { get; set; }
    public string DecodedPath2 { get; set; }
    public string Query1 { get; set; }
    public string DecodedQuery1 { get; set; }
    public string Query2 { get; set; }
    public string DecodedQuery2 { get; set; }
    public string Query3 { get; set; }
    public string DecodedQuery3 { get; set; }
    public ResponseModel(string Path1, string Path2, string Query1, string Query2, string Query3)
    {
        this.Path1 = Path1;
        this.Path2 = Path2;
        this.Query1 = Query1;
        this.Query2 = Query2;
        this.Query3 = Query3;
        this.DecodedPath1 = WebUtility.UrlDecode(Path1);
        this.DecodedPath2 = WebUtility.UrlDecode(Path2);
        this.DecodedQuery1 = WebUtility.UrlDecode(Query1);
        this.DecodedQuery2 = WebUtility.UrlDecode(Query2);
        this.DecodedQuery3 = WebUtility.UrlDecode(Query3);
    }

    public override string ToString()
    {
        return $"Path1 = {Path1}, Path2 = {Path2}, Query1 = {Query1}, Query2 = {Query2}, Query3 = {Query3}, DecodedPath1 = {DecodedPath1}, DecodedPath2 = {DecodedPath2}, DecodedQuery1 = {DecodedQuery1}, DecodedQuery2 = {DecodedQuery2}, DecodedQuery3 = {DecodedQuery3}";
    }

}