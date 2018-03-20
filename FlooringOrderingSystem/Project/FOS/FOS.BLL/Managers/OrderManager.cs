using FOS.BLL.Managers;
using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IStateTaxRepository _stateTaxRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, IStateTaxRepository stateTaxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _stateTaxRepository = stateTaxRepository;
        }

        public OrderGetListResponse GetOrderList(DateTime date)
        {
            OrderGetListResponse response = new OrderGetListResponse();

            response.Orders = _orderRepository.ListOrdersForDate(date);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"There were no files for {date}.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public OrderAddResponse AddOrder(Order order)
        {
            OrderAddResponse orderResponse = new OrderAddResponse();

            //valid order
            bool validOrder = false;

            //validate name
            bool validName = false;
            if (string.IsNullOrEmpty(order.CustomerName))
            {
                orderResponse.Message = "Name field is null";
                orderResponse.Success = false;
            }
            else
            {
                validName = true;
            }

            //validate area
            bool validArea = false;
            if (order.Area < 100)
            {
                orderResponse.Message = "Area cannot be less than 100 sq ft";
                orderResponse.Success = false;
            }
            else
            {
                validArea = true;
            }

            //validate product 
            bool validProduct = false;

            List <Product> products = _productRepository.GetProductList();
            foreach(Product prod in products)
            {
                if(prod.ProductType == order.ProductType)
                {
                    validProduct = true;
                }
            }

            //validate state
            bool validState = false;

            List<StateTax> states = _stateTaxRepository.ListStates();
            foreach(StateTax state in states)
            {
                if(state.StateAbbreviation == order.State)
                {
                    validState = true;
                }
            }


            if (validName && validArea && validProduct && validState)
            {
                validOrder = true;
            }

            if (validOrder)
            {
                orderResponse.Success = _orderRepository.Add(order);

                if (!orderResponse.Success)
                {
                    orderResponse.Message = "Add failed";
                }
            }

            return orderResponse;
        }

        public OrderGetSingleResponse GetSingleOrder(DateTime date, int orderNumber)
        {
            OrderGetSingleResponse response = new OrderGetSingleResponse();

            var orders = GetOrderList(date).Orders;

            if(orders == null)
            {
                response.Message = "Order date does not exist";
                response.Success = false;
            }
            else if (!orders.Any(w => w.OrderNumber == orderNumber))
            {
                response.Message = "Order number does not exist";
                response.Success = false;
            }
            else
            {
                response.Order = _orderRepository.GetSingleOrder(date, orderNumber);

                if (response.Order == null)
                {
                    response.Success = false;
                    response.Message = "Could not find order";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public OrderAddEditedResponse AddEditedOrder(Order order)
        {
            OrderAddEditedResponse response = new OrderAddEditedResponse();

            response.Success = _orderRepository.Edit(order);

            if (!response.Success)
            {
                response.Message = "Edit unsuccessful.";
            }

            return response;
        }

        public OrderRemoveResponse RemoveOrder(Order order)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();

            response.Success = _orderRepository.Remove(order);

            if (!response.Success)
            {
                response.Message = "Remove unsuccessful";
            }

            return response;
        }
    } 
}
