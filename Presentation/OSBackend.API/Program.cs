
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OSBackend.Persistence;
using OSBackend.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "https://localhost:3000")
));

builder.Services.AddAuthentication("User").AddJwtBearer(options =>   // "Teacher" yerine JwtBearerDefaults.AuthenticationScheme yazýlsaydý default bir þema adý üretirdi.
{
    options.TokenValidationParameters = new()
    {
        //true olanlar tokenda kontrol edilecek verilerdir.

        ValidateAudience = true,  // hangi sitelerin/originlerin kullanabileceði belirtilir. (frontend?)
        ValidateIssuer = true,    // Tokený kimin daðýttýðý belirtlir. (backend?) 

        ValidateLifetime = true, // bu sayede tokenýn bir yaþam süresi olur. False denilseydi ayný tokenla sonsuza kadar istek yapýlabilirdi.
        ValidateIssuerSigningKey = true, //tokenýn deðerininin bize ait olup olmadýðý takip edilir. 

        ValidIssuer = builder.Configuration["Token:Issuer"],  //appsettingsten deðerleri çekiyor.
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero  //sunucular arasýndaki zaman farký oluþmasýný engelliyor. 
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
