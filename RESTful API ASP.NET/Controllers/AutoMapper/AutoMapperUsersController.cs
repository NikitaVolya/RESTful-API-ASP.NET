using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful_API_ASP.NET.Data;
using RESTful_API_ASP.NET.Models.AutoMapper;
using RESTful_API_ASP.NET.DTO.AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace RESTful_API_ASP.NET.Controllers.AutoMapper
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoMapperUsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AutoMapperUsersController(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool short_version = false)
        {
            if (short_version)
            {
                List<UserShortDto> resShort = _mapper.Map<List<UserShortDto>>(
                    await _context.AutoMapperUsers.Include(u => u.Address).ToListAsync()
                );
                return Ok(resShort);
            }
            else
            {
                List<UserDto> res = _mapper.Map<List<UserDto>>(
                    await _context.AutoMapperUsers.Include(u => u.Address).ToListAsync()
                );
                return Ok(res);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var address = _mapper.Map<Address>(userDto.Address);

            Address? existingAddress = await _context.AutoMapperAddresses
                .FirstOrDefaultAsync(a => a.Street == address.Street && a.City == address.City);

            if (existingAddress != null)
            {
                user.AddressId = existingAddress.Id;
            }
            else {
                await _context.AutoMapperAddresses.AddAsync(address);
                await _context.SaveChangesAsync();

                user.AddressId = address.Id;
            }

            await _context.AutoMapperUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
