using MediatR;
using SklepHkr2025.Model;

namespace SklepHkr2025.Application.Common.Files.Command
{
    public class AddFilesToDiskCommand : IRequest<string>
    {
   public FileForListVm FileForListVm { get; set; } = new FileForListVm();
    }
}
