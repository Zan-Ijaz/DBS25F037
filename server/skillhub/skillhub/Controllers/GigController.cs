﻿using global::skillhub.Interfaces.IServiceLayer;
using Microsoft.AspNetCore.Mvc;
using skillhub.CommonLayer.Model.Freelancer;
using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces.IServiceLayer;
using skillhub.CommonLayer.Model.Gigs;
using skillhub.ServiceLayer;
using skillhub.RepositeryLayer;



namespace skillhub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigController : Controller
    {
        public readonly IGigSL gig;
        public GigController(IGigSL gig)
        {
            this.gig = gig;
        }
        [HttpPost("add_Freelancer_Gig")]
        public async Task<IActionResult> AddFreelancerGig(GigRequest gigRequest)
        {
            try
            {
                var result = await gig.AddFreelancerGig(gigRequest);
                return Ok(new { message = "Freelancer Information saved successfully", data = result });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteGig")]
        public async Task<IActionResult> DeleteGig(int id)
        {
            try
            {
                var result = await gig.DeleteGig(id);
                return Ok(new { message = "Freelancer Information deleted successfully", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateGig")]
        public async Task<IActionResult> UpdateGig(int id, [FromBody] GigRequest gigRequest)
        {
            try
            {
                var result = await gig.UpdateGig(id, gigRequest);
                return Ok(new { message = "Freelancer Information updated successfully", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("FindGig")]
        public async Task<IActionResult> FindGid(int id)
        {
            try
            {
                var result = await gig.GetGig(id);
                return Ok(new { message = "Gig Retrived successfully", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}

