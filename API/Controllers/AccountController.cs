using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

#pragma warning disable CS9113 // Parameter is unread.
public class AccountController(DataContext context, ITokenService tokenService): BaseApiController
#pragma warning restore CS9113 // Parameter is unread.
{
    [HttpPost("register")] // acoount/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

        return Ok();
    }


     private async Task<bool> UserExists(string username)
     {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()); 
     }
}
