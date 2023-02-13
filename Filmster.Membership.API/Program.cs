using AutoMapper;
using Filmster.Membership.Database.Entities;
using Filmster.Membership.Database;
using Filmster.Common.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy => {
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
        builder.Configuration.GetConnectionString("VODConnection")));

builder.Services.AddScoped<IDbService, DbService>();

// Add services to the container.
ConfigureAutoMapper();

void ConfigureAutoMapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Director, DirectorCreateDTO>()
        .ReverseMap();

        cfg.CreateMap<Film, FilmDTO>()
        .ReverseMap();
        //.ForMember(dest => dest.Courses, src => src.Ignore());

        cfg.CreateMap<FilmGenre, FilmGenreDTO>()
           .ReverseMap();
        // Only needed for seeding data.
        // .ForMember(dest => dest.Instructor, src => src.Ignore());

        cfg.CreateMap<Genre, GenreDTO>();
        //.ForMember(dest => dest.Instructor, src => src.Ignore())
        //.ForMember(dest => dest.Sections, src => src.Ignore());

        cfg.CreateMap<SimilarFilm, SimilarFilmsDTO>()
            //.ForMember(dest => dest.Course, src => src.MapFrom(s => s.Course.Title))
            .ReverseMap();
        //.ForMember(dest => dest.Course, src => src.Ignore());
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



