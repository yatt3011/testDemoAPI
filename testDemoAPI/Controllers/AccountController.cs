﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testDemoAPI.Data;
using testDemoAPI.Models;

namespace testDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly testDemoContext _context;

        public AccountController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/Account/Login
        [HttpGet("Login")]
        public IEnumerable<LoginRequest> GetloginRequests()
        {
            return _context.loginRequests;
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<IActionResult> PostLoginRequest([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.loginRequests.Add(loginRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginRequest", new { id = loginRequest.userName }, loginRequest);
        }

        // GET: api/User
        [HttpGet("User")]
        public IEnumerable<TableUser> GettableUsers()
        {
            return _context.tableUsers;
        }

        // POST: api/User
        [HttpPost("User")]
        public async Task<IActionResult> PostTableUser([FromBody] TableUser tableUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tableUsers.Add(tableUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableUser", new { id = tableUser.id }, tableUser);
        }

        #region
        /**
         * 
        // GET: api/Account/5
        [HttpGet("Login/{id}")]
        public async Task<IActionResult> GetLoginRequest([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginRequest = await _context.loginRequests.FindAsync(id);

            if (loginRequest == null)
            {
                return NotFound();
            }

            return Ok(loginRequest);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginRequest([FromRoute] string id, [FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginRequest.userName)
            {
                return BadRequest();
            }

            _context.Entry(loginRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginRequest([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginRequest = await _context.loginRequests.FindAsync(id);
            if (loginRequest == null)
            {
                return NotFound();
            }

            _context.loginRequests.Remove(loginRequest);
            await _context.SaveChangesAsync();

            return Ok(loginRequest);
        }

        private bool LoginRequestExists(string id)
        {
            return _context.loginRequests.Any(e => e.userName == id);
        }
        **/
        #endregion
    }
}