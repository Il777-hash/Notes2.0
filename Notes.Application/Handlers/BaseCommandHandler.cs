using Notes.Application.Interfaces;

namespace Notes.Application.Handlers
{
    public class BaseCommandHandler<T>
    {
        protected readonly IRepository<T> _repositoryContext;

        public BaseCommandHandler(IRepository<T> repositiryContext)
        {
            _repositoryContext = repositiryContext ?? throw new ArgumentNullException(nameof(repositiryContext)); ;
        }
    }
}
