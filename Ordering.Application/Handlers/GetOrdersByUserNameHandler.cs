using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class GetOrdersByUserNameHandler : IRequestHandler<GetOrdersBySellerUsernameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersByUserNameHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersBySellerUsernameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersBySellerUserName(request.UserName);

            var response = _mapper.Map<IEnumerable<OrderResponse>>(orderList);

            return response;
        }
    }
}
