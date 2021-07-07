﻿using _1911061027_DoTrongThuong_BigSchool.DTOs;
using _1911061027_DoTrongThuong_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;



namespace _1911061027_DoTrongThuong_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _dbContext.Followings
                .SingleOrDefault(a => a.FollowerId == userId && a.FolloweeId == id);

            if (following == null)
                return NotFound();

            _dbContext.Followings.Remove(following);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}