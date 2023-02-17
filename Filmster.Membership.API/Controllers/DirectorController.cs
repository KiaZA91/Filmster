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
        public DirectorController(IDbService db) => _db = db;


        // GET: api/<FilmsController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                // _db.Include<Director>();
                // _db.Include<FilmGenre>();

                List<DirectorDTO>? directors = await _db.GetAsync<Director, DirectorDTO>();

                return Results.Ok(directors);
            }
            catch (Exception ex)
            {

            }
            return Results.NotFound();

        }

        // GET api/<FilmsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Film>();
                // _db.Include<FilmGenre>();
                var director = await _db.SingleAsync<Director, DirectorDTO>(d => d.Id.Equals(id));

                return Results.Ok(director);
            }

            catch
            {

            }
            return Results.NotFound();
        }

        // POST api/<FilmsController>
        [HttpPost]

        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Director>(director), director);
            }
            catch { }

            return Results.BadRequest();
        }

        // PUT api/<FilmsController>/5
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

        // DELETE api/<FilmsController>/5
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

