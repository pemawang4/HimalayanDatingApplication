using System;
using System.Collections.Generic;
using HimalayanMeetDatingApp.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using HimalayanMeetDatingApp.Entity;


namespace HimalayanMeetDatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("userList")]
        public ActionResult<List<User>> userList()
        {
            return _user.userList();
        }

        [HttpPost]
        [Route("saveUser")]
        public IActionResult saveUser([FromBody] User user)
        {
            User newUser = new User();
            try
            {
                newUser = _user.saveUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(newUser.userId);
        }


        [HttpPost]
        [Route("userLogin")]
        public IActionResult userLogin([FromBody] User user)
        {
            User newUser = new User();
            if (newUser != null)
            {
                try
                {
                    newUser = _user.userLogin(user);
                    return Ok(newUser);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return NotFound("Error");
            }
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public IActionResult getUserById(int id)
        {
            User newUser = new User();
            if (newUser != null)
            {
                try
                {
                    newUser = _user.getUserById(id);
                    return Ok(newUser.userId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return NotFound("Error");
            }
        }
        //Preference section
        [HttpPost]
        [Route("savePreference")]
        public IActionResult savePreference([FromBody] Preference preference)
        {
            try
            {
                _user.savePreference(preference);
                return Ok("Preference saved.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getMatches/{id}")]
        public ActionResult<List<MatchList>> getMatches(int id)
        {
            try
            {
                List<MatchList> matchList = _user.getMatches(id);
                return Ok(matchList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}


