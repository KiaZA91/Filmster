using AutoMapper;
using Filmster.Membership.Database.Entities;
using Filmster.Membership.Database;
using Filmster.Common.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FilmContext>(
options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FilmsterConnection")));

builder.Services.AddScoped<IDbService, DbService>();

// Add services to the container.
ConfigureAutoMapper();

void ConfigureAutoMapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();

        cfg.CreateMap<DirectorCreateDTO, Director>().ReverseMap();

        cfg.CreateMap<Film, FilmDTO>().ReverseMap();
        cfg.CreateMap<FilmCreateDTO, Film>().ReverseMap();

        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

        cfg.CreateMap<Genre, GenreDTO>();
        cfg.CreateMap<GenreCreateDTO, Genre>();

        cfg.CreateMap<SimilarFilm, SimilarFilmsDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}


// Configure the HTTP request pipeline.
ConfigureMiddleware();

void ConfigureMiddleware()
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("CorsAllAccessPolicy");

    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}



