using Document.Application;
using Document.Application.Common.Exceptions;
using Document.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter JWT token in format: Bearer {token}"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddProblemDetails();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ProvisionalUser", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("CustomerBound", policy => policy.RequireAuthenticatedUser().RequireClaim("CustomerId"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        var problem = new ProblemDetails
        {
            Instance = context.Request.Path,
            Type = "setit"
        };

        switch (ex)
        {
            case NotFoundException nf:
                problem.Status = StatusCodes.Status404NotFound;
                problem.Title = "Resource Not Found";
                problem.Detail = nf.Message;
                problem.Type = "https://docs.yourdomain.com/problems/not-found";
                break;
            case FluentValidation.ValidationException ve:
                problem.Status = StatusCodes.Status422UnprocessableEntity;
                problem.Title = "Validation Failed";
                problem.Detail = ve.Message;
                problem.Type = "https://docs.yourdomain.com/problems/validation";
                problem.Extensions["errors"] = ve.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                break;
            default:
                problem.Status = StatusCodes.Status500InternalServerError;
                problem.Title = "Internal Server Error";
                problem.Detail = ex?.Message;
                break;
        }
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problem.Status!.Value;
        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(problem));
    });
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
