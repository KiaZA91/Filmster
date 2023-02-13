using Filmster.Membership.Database.Entities;
using Filmster.Membership.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmster.Common.DTOs;

namespace Filmster.Membership.Database.Extensions
{
    public static class FilmsterContextExtensions
    {
        public static async Task seedMembershipData(this IDbService service)
        {
            string description = "Movie Collection";

            try
            {
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {

                    Name = "Peter Jackson",
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {

                    Name = "The Wachowski sisters",
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {

                    Name = "George Lucas",
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {

                    Name = "Dan Kwan",
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {

                    Name = "David Fincher",
                });

                await service.SaveChangesAsync();

                var director1 = await service.SingleAsync<Director, DirectorDTO>(f => f.Name.Equals("Peter Jackson"));
                var director2 = await service.SingleAsync<Director, DirectorDTO>(f => f.Name.Equals("The Wachowski sisters"));
                var director3 = await service.SingleAsync<Director, DirectorDTO>(f => f.Name.Equals("George Lucas"));
                var director4 = await service.SingleAsync<Director, DirectorDTO>(f => f.Name.Equals("Dan Kwan"));
                var director5 = await service.SingleAsync<Director, DirectorDTO>(f => f.Name.Equals("David Fincher"));


                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {

                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Released = new DateTime(2001, 12, 10),
                    DirectorId = director1.Id,
                    Free = true,
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    FilmUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&t=2s"
                });

                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {

                    Title = "The Matrix",
                    Released = new DateTime(1999, 03, 31),
                    DirectorId = director2.Id,
                    Free = true,
                    Description = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                    FilmUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8"
                });

                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {

                    Title = "Star Wars: A new Hope",
                    Released = new DateTime(1977, 05, 25),
                    DirectorId = director3.Id,
                    Free = true,
                    Description = "The Imperial Forces, under orders from cruel Darth Vader, hold Princess Leia hostage in their efforts to quell the rebellion against the Galactic Empire. Luke Skywalker and Han Solo.",
                    FilmUrl = "https://www.youtube.com/watch?v=vZ734NWnAHA"
                });

                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {

                    Title = "Everything Everywhere All at Once",
                    Released = new DateTime(2022, 04, 24),
                    DirectorId = director4.Id,
                    Free = true,
                    Description = "With her laundromat teetering on the brink of failure and her marriage to wimpy husband Waymond on the rocks, overworked Evelyn Wang struggles to cope with everything.",
                    FilmUrl = "https://www.youtube.com/watch?v=wxN1T1uxQ2g"
                });

                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {

                    Title = "Fight Club",
                    Released = new DateTime(1999, 09, 10),
                    DirectorId = director4.Id,
                    Free = true,
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    FilmUrl = "https://www.youtube.com/watch?v=O1nDozs-LxI"
                });
                await service.SaveChangesAsync();


                var film1 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("The Lord of the Rings: The Fellowship of the Ring"));
                var film2 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("The Matrix"));
                var film3 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("Star Wars: A new Hope"));
                var film4 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("Everything Everywhere All at Once"));
                var film5 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("Fight Club"));

                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Drama",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Action",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Fantasy",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Sci-Fi",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Animation",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Romance",
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {

                    Name = "Comedy",
                });

                await service.SaveChangesAsync();

                var Genre1 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Drama"));
                var Genre2 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Action"));
                var Genre3 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Fantasy"));
                var Genre4 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Sci-Fi"));
                var Genre5 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Animation"));
                var Genre6 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Romance"));
                var Genre7 = await service.SingleAsync<Genre, GenreDTO>(f => f.Name.Equals("Comedy"));


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
