using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // Here we must validate request before any saving data

            var author = _mapper.Map<Domain.Courses.Author>(request);
            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveAsync();

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
