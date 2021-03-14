using MediatR;
using Ordering.Application.Responses;
using System.Collections.Generic;

namespace Ordering.Application.Queries
{
    public class GetOrdersBySellerUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrdersBySellerUsernameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
