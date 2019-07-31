﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Digiturk.Services.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Digiturk.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public LoginController(IUserService userService
            ,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/Login")]

        public IActionResult Post([FromBody]LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAllUsers().Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub,request.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Issuer"], //appsettings.json içerisinde bulunan issuer değeri
                    audience: _configuration["Audience"],//appsettings.json içerisinde bulunan audince değeri
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(30), // 30 gün geçerli olacak
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),//appsettings.json içerisinde bulunan signingkey değeri
                            SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}