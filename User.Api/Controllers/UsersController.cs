﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models;
using User.Api.Service;
using User.Api.ServiceModel;
using User.Api.ViewModels;

namespace User.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserContext db = new UserContext();


        [HttpGet]
        [Route("/")]
        public IActionResult UserRetrieved(RequestUser request)
        {
            try
            {


                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        } 

        [HttpPost]
        public async Task<IActionResult> Post(FaceServiceModel request)
        {
            try
            {
                var faceGuid = await FacialService.UpsertBase64(request.face);
                var imageFace = db.UserFace.Where(x => x.faceId == faceGuid.Value.ToString()).FirstOrDefault();

                if(imageFace != null) //JA TEM CADASTRADO
                {

                }
                else //NÂO TEM CADASTRADO
                {


                }


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }        
    }
    }
}
