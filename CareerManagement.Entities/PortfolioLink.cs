namespace CareerManagement.Entities
{
    public class PortfolioLink
    {
        public string PortfolioId { get; set; }

        public string LinkId { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        public virtual Link Link { get; set; }
    }
}
