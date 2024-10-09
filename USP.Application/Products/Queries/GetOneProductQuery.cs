using MediatR;
using MongoDB.Entities;
using USP.Application.Common.Dto;
using USP.Application.Common.Mappers;

namespace USP.Application.Products.Queries;

public record GetOneProductQuery(string Id) : IRequest<ProductDetailsDto?>;

public class GetOneProductQueryHandler : IRequestHandler<GetOneProductQuery, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(GetOneProductQuery request, CancellationToken cancellationToken)
    {
        var entity = await DB.Find<Domain.Entities.Product>().OneAsync(request.Id, cancellation: cancellationToken);
        // var test= entity.ReferencedOneToOneUser.ToEntityAsync(cancellation: cancellationToken);
        var dto = await entity?.ToDtoAsync()!;
        return dto;
    }
}