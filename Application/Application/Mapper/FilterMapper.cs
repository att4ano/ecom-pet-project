using Application.Dto;
using Application.Dto.FilterDto;
using Domain.Models;

namespace Application.Mapper;

public static class FilterMapper
{
    public static Func<Product, bool> ToMapper(this ProductFilterDto filterDto)
    {
        Func<Product, bool> filter = _ => true;

        if (filterDto.CategoryId is not null)
        {
            var tmpFilter = filter;
            filter = product => product.CategoryId == filterDto.CategoryId && tmpFilter(product);
        }

        if (filterDto.Price is not null)
        {
            if (filterDto.Price.Value == 0) 
                return filter;
            
            var tmpFilter = filter;
            filter = product => product.Price < filterDto.Price && tmpFilter(product);
        }

        return filter;
    }

    public static Func<Order, bool> ToMapper(this OrderFilterDto filterDto)
    {
        Func<Order, bool> filter = _ => true;
        
        if (filterDto.CreationTime is not null)
        {
            var tmpFilter = filter;
            filter = order => order.CreationData <= filterDto.CreationTime && tmpFilter(order);
        }
        
        if (filterDto.OrderStatus is not null)
        {
            var tmpFilter = filter;
            filter = order => order.Status == filterDto.OrderStatus && tmpFilter(order);
        }

        return filter;
    }

    public static Func<OrderItem, bool> ToMapper(this ItemFilterDto filterDto)
    {
        Func<OrderItem, bool> filter = _ => true;

        if (filterDto.CategoryId is not null)
        {
            var tmpFilter = filter;
            filter = item => item.ProductItem.CategoryId == filterDto.CategoryId && tmpFilter(item);
        }
        
        if (filterDto.ProductId is not null)
        {
            var tmpFilter = filter;
            filter = item => item.ProductId == filterDto.ProductId && tmpFilter(item);
        }

        return filter;
    }
}