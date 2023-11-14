namespace PruebaCheil.Aplication.Features.Get
{
    public class GetInfoResponseDto
    {
        public int Total { get; set; }

        public List<GetInfoDetail> GetInfoDetail { get; set; }
    }

    public class GetInfoDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stars { get; set; }
    }

}
