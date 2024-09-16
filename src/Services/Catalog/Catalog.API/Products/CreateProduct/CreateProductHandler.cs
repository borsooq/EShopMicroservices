using FluentValidation;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidatoer : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidatoer()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image is requred");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

internal class CreateProductCommandHandler(IDocumentSession session, IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //BusinessLogic
        var result = await validator.ValidateAsync(command,cancellationToken);
        var errors = result.Errors.Select(err => err.ErrorMessage).ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        //Create product Entity
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        //Add entity to DB

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //Return result
        return new CreateProductResult(product.Id);
    }
}
