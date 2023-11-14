namespace PruebaCheil.Aplication.Features.Get
{
    public class GetInfoDto
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public int? Stars { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }
}
