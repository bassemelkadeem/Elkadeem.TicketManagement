using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Domain.Events;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository
                ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse();

            // We must validate business logic here
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                response.IsSuccess = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.IsSuccess)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                await _categoryRepository.SaveAsync();
                response.CreatedCategoryDto = _mapper.Map<CreatedCategoryDto>(category);
                response.Message = "Successfully added category";
            }

            return response;
        }
    }
}
