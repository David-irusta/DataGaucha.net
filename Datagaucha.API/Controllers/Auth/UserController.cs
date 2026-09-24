using System.ComponentModel.DataAnnotations;
using Datagaucha.DAL.interfaces;
using Datagaucha.Domain.Auth;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Net.WebRequestMethods;
using System.Net;
using Datagaucha.Domain.FileSystem;

namespace Datagaucha.API.Controllers.Auth;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase{
    private readonly IUnitOfWork dataBase;
    private IWebHostEnvironment env;

    public UserController(IUnitOfWork database, IWebHostEnvironment env)
    {
        this.dataBase = database;
        this.env = env;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateUserRequest request)
    {
        await validationUser(request);

        Image? image = await generateImage(request);

        //Agregar validacion usando regex para:
        //8 caracteres, 1 mayus, 1 minus y 1 numero

        //Si llegue aca. Es que esta todo Ok

        User user = createUser(request, image);

        await saveInDataBase(user);

        CreateUserResponse response = new CreateUserResponse
        {
            id = user.Id,
            avatarUrl = user.GetAvatarurl(),
            userName = user.UserName
        };

        return Ok(new ResponseDTO<CreateUserResponse>
        {
            code = (int)HttpStatusCode.OK,
            message = "Usuario guardado correctamente",
            success = true,
            payload = response
        });
    }

    private async Task saveInDataBase(User user)
    {
        await dataBase.UserRepository.Create(user);
        await this.dataBase.SaveChangesAsync();
    }

    private static User createUser(CreateUserRequest request, Image? image)
    {
        User user = new User
        {
            UserName = request.userName,
            Image = image
        };

        user.SetPassword(request.password);
        return user;
    }

    private async Task<Image?> generateImage(CreateUserRequest request)
    {

        if (request.file is null) return null;

        await using var stream = request.file.OpenReadStream();
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        byte[]? fileData = ms.ToArray();
        string? fileName = request.file.FileName;

        FileStorageService fileStorageService = new FileStorageService(env);
        return await fileStorageService.SaveImageAsync(fileData, fileName);

    }

    private async Task validationUser(CreateUserRequest request)
    {
        if (String.IsNullOrEmpty(request.password))
        {
            throw new ValidationException("La contraseña es un dato obligatorio");
        }

        if (String.IsNullOrEmpty(request.userName))
        {
            throw new ValidationException("El nombre de usuario es un dato obligatorio");
        }

        User? existedUser = await this.dataBase.UserRepository.GetuserByUserName(request.userName);

        if (existedUser != null)
        {
            throw new ValidationException("Ya existe un usuario con el nombre " + request.userName);
        }
    }
}