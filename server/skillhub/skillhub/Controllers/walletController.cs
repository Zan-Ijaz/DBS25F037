﻿using Microsoft.AspNetCore.Mvc;
using skillhub.CommonLayer.Model;
using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces.IServiceLayer;

namespace skillhub.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class walletController : Controller
    {
        private readonly IWalletSL walletInterface;

        public walletController(IWalletSL walletInterface)
        {
            this.walletInterface = walletInterface;
        }

        [HttpPost("create")]
        public async Task<IActionResult> MakeWallet(WalletRequest request)
        {
            try
            {
                var response = await walletInterface.MakeWallet(request);

                return Ok(new { message = "Wallet made successfully", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Find_wallet")]
        public async Task<IActionResult> FindWallet(int userid)
        {
            try
            {
                var response = await walletInterface.FindWallet(userid);

                return Ok(new { message = "Wallet found successfully", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("UpdateWallet")]
        public async Task<IActionResult> updateWallet(WalletRequest request)
        {
            try
            {
                var response = await walletInterface.UpdateWallet(request);

                return Ok(new { message = "Wallet updated successfully", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

