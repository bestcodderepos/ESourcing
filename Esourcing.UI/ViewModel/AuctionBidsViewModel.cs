using System.Collections.Generic;

namespace Esourcing.UI.ViewModel
{
    public class AuctionBidsViewModel
    {
        public string AuctionId { get; set; }
        public string ProductId { get; set; }
        public string SellerUserName { get; set; }
        public bool IsAdmin { get; set; }
        public List<BidViewModel> Bids { get; set; }
    }
}
