using Filmster.Membership.Database.Entities;
using Filmster.Membership2.API.Util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filmster.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmsController : ControllerBase
    {
        private readonly IDbService _db;

        public SimilarFilmsController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<SimilarFilm>();
                List<SimilarFilmsDTO>? similarFilms = await _db.GetAsync<SimilarFilm, SimilarFilmsDTO>();
                return Results.Ok(JsonUtility.RemoveLoops(similarFilms));
            }
            catch
            {
                return Results.NotFound();
            }
        }
		//[HttpPut("{id}")]

		//public async Task<IResult> Put(int id, [FromBody] List<SimilarFilmsDTO> dto)
		//{
		//    try
		//    {
		//        if (dto == null)
		//        {
		//            return Results.BadRequest();
		//        }
		//        var toKeep = await _db.GetAsync<SimilarFilm, SimilarFilmsDTO>(a => a.FilmId == id && dto.Select(b => b.SimilarFilmId).ToList().Contains(a.SimilarFilmId));
		//        var toDelete = await _db.GetAsync<SimilarFilm, SimilarFilmsDTO>(a => a.FilmId == id && !dto.Select(a => a.SimilarFilmId).ToList().Contains(a.SimilarFilmId));
		//        var toAdd = dto.Where(a => !toKeep.Select(b => b.SimilarFilmId).ToList().Contains(a.SimilarFilmId)).ToList();

		//        foreach (var item in toDelete)
		//        {
		//            _db.DeleteAsync<SimilarFilm>(new SimilarFilm() { FilmId = (int)item.FilmId, SimilarFilmId = (int)item.SimilarFilmId });
		//            await _db.SaveChangesAsync();
		//        }
		//        foreach (var item in toAdd)
		//        {
		//            _db.AddAsync<SimilarFilm, SimilarFilmsDTO>(item);
		//        }

		//        var success = await _db.SaveChangesAsync();
		//        if (!success)
		//        {
		//            return Results.BadRequest();
		//        }
		//        return Results.NoContent();
		//    }
		//    catch
		//    {
		//        return Results.BadRequest();
		//    }
		//}

		[HttpPost]
		public async Task<IResult> Post(SimilarFilmsDTO dto)
		{
			try
			{
				if (dto == null) return Results.BadRequest();
				var filmgenre = await _db.AddAsync<SimilarFilm, SimilarFilmsDTO>(dto);
				var success = await _db.SaveChangesAsync();
				if (!success) return Results.BadRequest();
				return Results.Ok();
			}
			catch
			{
			}
			return Results.NotFound();
		}
		[HttpDelete]

		public async Task<IResult> Delete(SimilarFilmsDTO dto)
		{
			try
			{
				_db.Delete<SimilarFilm, SimilarFilmsDTO>(dto);
				var success = await _db.SaveChangesAsync(); if (!success) return Results.BadRequest(); return Results.NoContent();
			}
			catch { }
			return Results.BadRequest();
		}
	}
}
