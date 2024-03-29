using Application.Features.CQRS.Commands.AboutCommand;
using Application.Features.CQRS.Handlers.AboutHandler;
using Application.Features.CQRS.Handlers.BannerHandler;
using Application.Features.CQRS.Handlers.BrandHandler;
using Application.Features.CQRS.Handlers.CarHandler;
using Application.Features.CQRS.Handlers.CategoryHandler;
using Application.Features.CQRS.Handlers.ContactHandler;
using Application.Interfaces;
using Application.Services;
using Application.Tools;
using CarBookDomain.Entities;
using CarBookWebAPI.Hubs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using Persistance.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(ICommentRepository),typeof(CommentRepository));
builder.Services.AddScoped(typeof(StatisticInterfaces),typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository),typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository),typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(ICarCommentRepository),typeof(CarCommentRepository));
builder.Services.AddScoped(typeof(IAppUserRepository),typeof(AppUserRepository));

// Add services to the container.
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQuertHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandle>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandle>();

builder.Services.AddScoped<GetCarByIdQueryResultHandler>();
builder.Services.AddScoped<GetCarQueryResultHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarsWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarByIdWithBrandQueryResultHandler>();


builder.Services.AddScoped<GetCategoryByIdResultHandler>();
builder.Services.AddScoped<GetCategoryResultHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryResultHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidAudience=JwtTokenDefault.ValidAudience,
		ValidIssuer=JwtTokenDefault.ValidIssuer,
		ClockSkew=TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key)),
		ValidateIssuerSigningKey=true,
		ValidateLifetime=true,
	};
});
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("WebApi", opts =>
	{
		opts.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
	});
});
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("WebApi");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
