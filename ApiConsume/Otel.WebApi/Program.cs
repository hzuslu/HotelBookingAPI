using Otel.BusinessLayer.Abstract;
using Otel.BusinessLayer.Concrete;
using Otel.DataAccessLayer.Abstract;
using Otel.DataAccessLayer.Concrete;
using Otel.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();

// DataAccessLayer
builder.Services.AddScoped<IStaffDal, EfStaffDAL>();
builder.Services.AddScoped<IRoomDal, EfRoomDAL>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDAL>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDAL>();
builder.Services.AddScoped<IServiceDal, EfServiceDAL>();

// BusinessLayer
builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("OtelApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
