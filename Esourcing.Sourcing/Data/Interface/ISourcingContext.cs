using Esourcing.Sourcing.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esourcing.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}
