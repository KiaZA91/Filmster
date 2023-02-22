//using AutoMapper;
//using Filmster.Membership.Database.Entities;
//using Filmster.Membership.Database;
//using Filmster.Common.DTOs;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(policy =>
//{
//    policy.AddPolicy("CorsAllAccessPolicy", opt =>
//        opt.AllowAnyOrigin()
//           .AllowAnyHeader()
//           .AllowAnyMethod()
//    );
//});

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<FilmContext>(
//options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("FilmsterConnection")));

//builder.Services.AddScoped<IDbService, DbService>();

//// Add services to the container.
//ConfigureAutoMapper();

//void ConfigureAutoMapper()
//{
//    var config = new AutoMapper.MapperConfiguration(cfg =>
//    {
//        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();

//        cfg.CreateMap<DirectorCreateDTO, Director>().ReverseMap();

//        cfg.CreateMap<Film, FilmDTO>().ReverseMap();
//        cfg.CreateMap<FilmCreateDTO, Film>().ReverseMap();

//        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

//        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
//        cfg.CreateMap<GenreCreateDTO, Genre>().ReverseMap();

//        cfg.CreateMap<SimilarFilm, SimilarFilmsDTO>().ReverseMap();

//    });
//    var mapper = config.CreateMapper();
//    builder.Services.AddSingleton(mapper);
//}


//// Configure the HTTP request pipeline.
//ConfigureMiddleware();

//void ConfigureMiddleware()
//{
//    var app = builder.Build();

//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }

//    app.UseHttpsRedirection();

//    app.UseCors("CorsAllAccessPolicy");

//    app.UseAuthorization();
//    app.MapControllers();

//    app.Run();
//}



using Filmster.Membership.Database;
using Filmster.Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilmContext>(
options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("FilmsterConnection")));
builder.Services.AddScoped<IDbService, DbService>();

ConfigureAutomapper();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseBlazorFrameworkFiles("");
app.UseStaticFiles();

app.UseRouting();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

void ConfigureAutomapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        //Films mapping

        cfg.CreateMap<Film, FilmDTO>().ReverseMap()
        .ForMember(dest => dest.Director, src => src.Ignore());

        cfg.CreateMap<FilmEditDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
        cfg.CreateMap<DirectorCreateDTO, Director>().ReverseMap();

        //Genre
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
        cfg.CreateMap<FilmGenre, FilmGenreCreateDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreCreateDTO>();
        //SimilarFilms

        cfg.CreateMap<SimilarFilm, SimilarFilmsDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
