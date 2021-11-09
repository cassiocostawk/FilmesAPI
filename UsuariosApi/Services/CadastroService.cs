﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result Insert(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar o Usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
