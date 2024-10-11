using MediatR;
using USP.Application.Common.Dto;
using USP.Application.Common.Interfaces;
using USP.Application.Common.Mappers;

namespace USP.Application.Products.Queries;

public record GetAllProductQuery : IRequest<List<ProductDetailsDto>>;

public class GetAllProductQueryHandler(IProductService productService) : IRequestHandler<GetAllProductQuery, List<ProductDetailsDto>>
{
    public async Task<List<ProductDetailsDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var results = await productService.GetAllProductsAsync(cancellationToken);

        var listDto = new List<ProductDetailsDto>();

        foreach (var item in results)
        {
            var result = await item.ToDtoAsync();
            listDto.Add(result);
        }

        return listDto;
    }
}