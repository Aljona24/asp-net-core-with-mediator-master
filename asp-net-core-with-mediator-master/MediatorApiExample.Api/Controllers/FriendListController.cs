using MediatorApiExample.Application.Feature.FriendCreate;
using MediatorApiExample.Application.Feature.FriendLike;
using MediatorApiExample.Application.Feature.FriendRemove;
using MediatorApiExample.Application.Feature.GetFriendList;
using MediatorApiExample.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using MediatorApiExample.Application.Feature.GetFriend;

namespace MediatorApiExample.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FriendsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<Guid>> CreateFriendsAsync(FriendsCreateCommand cmd) => 
        await mediator.Send(cmd);

    [HttpGet]
    public async Task<FriendItem[]> GetFriendsListAsync() =>
        await mediator.Send(new GetFriendListQuery());
    
    [HttpGet]
    [Route("{id:guid?}")]
    public async Task<FriendItem> GetFriendAsync(Guid id) => 
        await mediator.Send(new GetFriendQuery(id));
    
    [HttpDelete]
    public async Task RemoveFriendAsync(FriendRemoveCommand cmd) => 
        await mediator.Send(cmd);

    [HttpPost("like")]
    public async Task LikeFriendAsync(FriendLikeCommand cmd) => 
        await mediator.Send(cmd);
}