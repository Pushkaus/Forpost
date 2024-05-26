using Swashbuckle.AspNetCore.Annotations;

namespace Forpost.Web.Contracts.OrderBlock
{
    public class OrderBlockResponse
    {
        public OrderBlockResponse(int Id, string? Klient, string? Account, string? Block)
        {
            this.Id = Id;
            this.Klient = Klient;
            this.Account = Account;
            this.Block = Block;
        }

        /// <summary>
        /// gavno
        /// </summary>
        public int Id { get; set; }
        public string? Klient { get; set; }
        public string? Account { get; set; }
        public string? Block { get; set; }
    }
}