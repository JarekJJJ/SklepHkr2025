using MediatR;
using SklepHkr2025.Application.Common.Files.Command;
using SklepHkr2025.Model;

namespace SklepHkr2025.Client.Service.Files
{
    public class FilesService
    {
        private readonly IMediator _mediator;
        // private readonly HttpClient _httpClient;
        public FilesService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<string> UploadFileAsync(FileForListVm fileForListVm)
        {
            AddFilesToDiskCommand command = new AddFilesToDiskCommand
            {
                FileForListVm = fileForListVm
            };
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
