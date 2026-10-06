using Microsoft.AspNetCore.Mvc;
using Datagaucha.DAL.interfaces;
using Datagaucha.Domain.Exceptions;
using Datagaucha.Domain.FileSystem;
using Microsoft.AspNetCore.Authorization;

namespace Datagaucha.API.Controllers.Post;

[ApiController]
[Route("api/post")]
public class PostController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork dataBase = unitOfWork;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetPost(, CancellationToken cancellationToken)
    {
        Datagaucha.Domain.FileSystem.File? file = await this.dataBase.FileRepository.GetByName(id);
        if (file is null)
        {
            throw new BusinessNotFoundException("La imagen no existe en la base de datos");
        }

        string quesoy = file.QueSoy();

		FileStorageService fileStorage = new FileStorageService(this.env);
        var physicalPath = fileStorage.GetPhysicalPath(file.StoragePath);

        if (string.IsNullOrWhiteSpace(physicalPath) || !System.IO.File.Exists(physicalPath))
        {
            throw new BusinessNotFoundException("No se encontró la imagen fisica");
        }

        var contentType = string.IsNullOrWhiteSpace(file.ContentType) ? "application/octet-stream" : file.ContentType;
        return PhysicalFile(physicalPath, contentType);
    }
}