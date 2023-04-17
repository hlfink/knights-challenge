namespace Knights.Challenge.Core.Application.Contracts
{
    public class KnightResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weapons { get; set; }
        public string Attribute { get; set; } = string.Empty;
        public int Attack { get; set; }
        public int Experiense { get; set; }
    }
}
