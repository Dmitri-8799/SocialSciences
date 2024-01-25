using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
 
var builder = WebApplication.CreateBuilder();
 
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)            /*
                                                                                        Чтобы указать, что приложение для аутентификации будет использовать токена, 
                                                                                        в метод AddAuthentication() передается значение константы JwtBearerDefaults.AuthenticationScheme.
                                                                                      */


  
    .AddJwtBearer(options =>                                                          /*
                                                                                        С помощью метода AddJwtBearer() в приложение добавляется конфигурация токена. 
                                                                                        Для конфигурации токена применяется объект JwtBearerOptions, 
                                                                                        который позволяет с помощью свойств настроить работу с токеном. 
                                                                                        Данный объект имеет множество свойств. З
                                                                                        десь же использовано только свойство TokenValidationParameters, 
                                                                                        которое задает параметры валидации токена.
                                                                                      */
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER, 
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
         };
});
var app = builder.Build();
 
app.UseAuthentication();
app.UseAuthorization();


/*
Чтобы пользователь мог использовать токен, приложение должно отправить ему этот токен, а перед этим соответственно сгенерировать токен. 
И для генерации токена здесь предусмотрена типовая конечная точка "/login":
*/

//А МЫ ЧТО ДОЛЖНЫ СДЕЛАТЬ КОНЕЧНОЙ ТОЧКОЙ? ВОЗНИКЛА ИДЕЯ ПРИ НАЖАТИИ НА КНОПКУ "LogIn" передавать какой-либо CommandParameter или true/false, н
//о пока тема конечных точек для меня трудна для понимания... Или наоборот нам не надо никакие параметры передавать и метод сам возьмет Login человека {username} и использует его для создания JWT-токена?


app.Map("/login/{username}", (string username) => 
{
    var claims = new List<Claim> {new Claim(ClaimTypes.Name, username) }; // а мы сюда не переносим модель UserOfApp, которая существует на этапе регистрации ?
  
    /* создаем JWT-токен: Для создания токена применяется конструктор JwtSecurityToken. 
    Одним из параметров служит список объектов Claim. 
    Объекты Claim служат для хранения некоторых данных о пользователе, описывают пользователя. 
    Затем эти данные можно применять для аутентификации. В данном случае добавляем в список один Claim, который хранит логин пользователя.

    Затем собственно создаем JWT-токен, передавая в конструктор JwtSecurityToken соответствующие параметры. 
    для инициализации токена применяются все те же константы и ключ безопасности, которые определены в классе AuthOptions 
    и которые использовались для конфигурации настроек в методе AddJwtBearer().
      */
    var jwt = new JwtSecurityToken(                        
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            
    return new JwtSecurityTokenHandler().WriteToken(jwt);       //посредством метода JwtSecurityTokenHandler().WriteToken(jwt) создается сам токен , который отправляется клиенту.
});
 
app.Map("/data", [Authorize] () => new { message= "Hello World!" });
 
app.Run();


//Для описания некоторых настроек генерации токена в конце кода определен специальный класс AuthOptions:

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; //Константа ISSUER представляет издателя токена. Здесь можно определить любое название.

    public const string AUDIENCE = "MyAuthClient"; // Константа AUDIENCE представляет потребителя токена - опять же может быть любая строка, обычно это сайт, на котором применяется токен.

    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
                                                  /*
                                                  Константа KEY хранит ключ, который будет применяться для создания токена. 
                                                  Стоит отметить, что для разных алгоритмов шифрования могут применяться ограничения на размер ключа. 
                                                  Так, в данном примере применяется алгоритм SecurityAlgorithms.HmacSha256, 
                                                  для которого необходим ключ длиной не менее 256 бит или 32 байта
                                                  */


  
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>  /*
                                                                      метод GetSymmetricSecurityKey() возвращает ключ безопасности, 
                                                                      который применяется для генерации токена. 
                                                                      Для генерации токена нам необходим объект класса SecurityKey. 
                                                                      В качестве такого здесь выступает объект производного класса SymmetricSecurityKey, 
                                                                      в конструктор которого передается массив байт, созданный по секретному ключу.
                                                                      */


        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

}
