using Microsoft.AspNetCore.Mvc;
using Datagaucha.DAL.interfaces;
using Datagaucha.Domain.Exceptions;
using Datagaucha.Domain.FileSystem;
using Microsoft.AspNetCore.Authorization;
using Datagaucha.API.Utils;
using Datagaucha.Domain.Post;
using Datagaucha.Domain.Auth;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using Datagaucha.API.DTOs.Post;
using System.Net;

namespace Datagaucha.API.Controllers;

[ApiController]
[Route("api/post")]
public class PostController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork dataBase = unitOfWork;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetPost([FromQuery]GetPostRequest request, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();

        User user = await this.dataBase.UserRepository.GetuserById(userId);

        List<Post> posts = await this.dataBase.PostRepository.GetPosts(
            user,
            request.currentPage,
            request.pageSize,
            request.orderBy,
            request.orderDirection,
            request.search
        );
        List<PostDTO> postDTOs = new List<PostDTO>();
        foreach (Post post in posts)
        {
            postDTOs.Add(new PostDTO
            {
                id = post.Id,
                userName = post.GetUserName(),
                content = post.Body,
                urlImage = post.ImageUrl()
            });
        }
        return Ok(new ResponseDTO<List<PostDTO>>(){
            code = (int)HttpStatusCode.OK,
            message = "Post obtenido",
            payload = postDTOs,
            success = true
        });
    }
}