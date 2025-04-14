namespace JwtApi.Dtos
{
    public record LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
