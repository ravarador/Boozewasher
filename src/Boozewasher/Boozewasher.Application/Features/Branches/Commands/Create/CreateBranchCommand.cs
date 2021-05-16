using Boozewasher.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Boozewasher.Domain.Entities;

namespace Boozewasher.Application.Features.Branches.Commands.Create
{
    public partial class CreateBranchCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<int>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateBranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Branch>(request);
            await _branchRepository.InsertAsync(product);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(product.Id);
        }
    }
}
