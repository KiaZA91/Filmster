using Filmster.Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filmster.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IDbService _db;

        public GenreController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<GenreDTO>? genres = await _db.GetAsync<Genre, GenreDTO>();

                return Results.Ok(genres);
            }
            catch { }

            return Results.NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var genres = await _db.SingleAsync<Genre, GenreDTO>(c => c.Id.Equals(id));
                return Results.Ok(genres);
            }

            catch { }

            return Results.NotFound();
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var genre = await _db.AddAsync<Genre, GenreCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Genre>(genre), genre);
            }

            catch { }

            return Results.BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] GenreDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                if (!id.Equals(dto.Id)) return Results.BadRequest();

                var exists = await _db.SaveChangesAsync();
                if (!exists) return Results.BadRequest();

                _db.Update<Genre, GenreDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();
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
                var exist = await _db.DeleteAsync<Genre>(id);
                if (!exist) return Results.NotFound();

                var success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }
    }
}
