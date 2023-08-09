
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

builder.Services.AddAuthentication("User").AddJwtBearer(options =>   // "Teacher" yerine JwtBearerDefaults.AuthenticationScheme yaz�lsayd� default bir �ema ad� �retirdi.
{
    options.TokenValidationParameters = new()
    {
        //true olanlar tokenda kontrol edilecek verilerdir.

        ValidateAudience = true,  // hangi sitelerin/originlerin kullanabilece�i belirtilir. (frontend?)
        ValidateIssuer = true,    // Token� kimin da��tt��� belirtlir. (backend?) 

        ValidateLifetime = true, // bu sayede token�n bir ya�am s�resi olur. False denilseydi ayn� tokenla sonsuza kadar istek yap�labilirdi.
        ValidateIssuerSigningKey = true, //token�n de�erininin bize ait olup olmad��� takip edilir. 

        ValidIssuer = builder.Configuration["Token:Issuer"],  //appsettingsten de�erleri �ekiyor.
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero  //sunucular aras�ndaki zaman fark� olu�mas�n� engelliyor. 
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
