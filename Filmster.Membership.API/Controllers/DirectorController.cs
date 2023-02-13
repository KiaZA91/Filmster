using Filmster.Common.DTOs;
using Filmster.Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filmster.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;
        public DirectorController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var directors = await _db.GetAsync<Director, DirectorDTO>();
                return Results.Ok(directors);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Director>();
                var director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id == id);
                return Results.Ok(director);
            }
            catch (Exception ex)
            {

                return Results.NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();

                return Results.Created(_db.GetURI(director), director);
            }
            catch (Exception ex)
            {

                return Results.BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                if (!id.Equals(dto.Id)) return Results.BadRequest();

                var success = await _db.AnyAsync<Director>(c => c.Id.Equals(id));

                if (!success) return Results.NotFound();

                _db.Update<Director, DirectorDTO>(dto.Id, dto);

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Director>(id);

                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }

    }
}