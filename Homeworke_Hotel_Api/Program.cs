using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Services;
using Homeworke_Hotel_Api.Services.Bookings;
using Homeworke_Hotel_Api.Services.Guests;
using Homeworke_Hotel_Api.Services.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using System.Text;



//بداية تم شرح التعليقات السطرية على الغرفة من كل شي 
//مثل 
//1 - كيف تم انشاء 
//    controller 
//2- كيف تم انشاء الدوال الخاصة 
//3- .....4-......
//تم شرحها جميعها على 
//Room


//create logger in textfild
var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.File("D:\\HomeworkApi.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

//فحص 
//token
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretKey"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true
        };
    });

//اللغات 
//xml   -    json
builder.Services.AddControllers(option => option.ReturnHttpNotAcceptable = true)
                .AddNewtonsoftJson(option=>
                {
                    //تم وضع هذه التعليمة لتجاهل القيم 
                    //null 
                    //واجهتني مشكلة وهي اظهار مثلا 
                    //Hotel = null
                    //عند جلب معلومات الفندق 
                    option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    //تم وضع هذه التعليمة لتجاهل الحلقات المرجعية عند تسلسل الكائنات 
                    //اي اذا كان لدي فندق يحتوي على العديد من الموظفين 
                    //والموظف يحتوي على رقم الفندق الذي يعمل به 
                    // هكذا ستصبح حلقة لانهائية لجلب البيانات 
                    //لذلك تم استخدام هذه التعليمة 
                    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddXmlDataContractSerializerFormatters();

//تسجيل
//mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//تسجيل مكتبة 
//serilog
//for logger
builder.Host.UseSerilog();


//الاتصال مع قاعدة البيانات 
builder.Services.AddDbContext<DataBaseContext>(option =>
          option.UseSqlServer(builder.Configuration["ConnectionStrings:HotelDBConnection"]));
//جعل المتحول الذي يتم انشاءه من كلاس قاعدة البيانات عام لكل المشروع
builder.Services.AddScoped<DataBaseContext>();


//عندما يتم طلب 
//IHotelRepository
//يتم تحويل الطلب ل 
//HotelRepository
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingsRepository, BookingsRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//اضافة استخدام فحص تسجيل الدخول
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
