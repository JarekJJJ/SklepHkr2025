using MediatR;

namespace SklepHkr2025.Application.Common.Files.Command
{
    public class AddFilesToDiskCommandHandler: IRequestHandler<AddFilesToDiskCommand, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AddFilesToDiskCommandHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> Handle(AddFilesToDiskCommand request, CancellationToken cancellationToken)
        {
            var file = request.FileForListVm.File;
            if (file == null || file.Length == 0)
            {
                return "File is empty";
            }
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "files", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "File uploaded successfully";
        }
    }
}
