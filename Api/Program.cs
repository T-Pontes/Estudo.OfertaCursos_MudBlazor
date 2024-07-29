using Api.Data.Context;
using Api.Data.Repositories;
using Core.Abstractions.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicos do contexto
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DEV_Conn")));
builder.Services.AddTransient<IClassRepository, ClassRepository>();
builder.Services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();




var app = builder.Build();








// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Mapeamento dos endpoints
#region Class

var classGroup = app.MapGroup("/v1/classes")
    .WithTags("Classes");

classGroup.MapGet("/", async (IClassRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
})
    .WithName("Listar Classes")
    .WithOpenApi();

classGroup.MapGet("/{id}", async (int id, IClassRepository repository) =>
{
    var obj = await repository.GetByIdAsync(id);
    return obj != null ? Results.Ok(obj) : Results.NotFound();
})
    .WithName("Obter Class por Id")
    .WithOpenApi();

classGroup.MapPost("/", async (Class obj, IClassRepository repository) =>
{
    await repository.CreateAsync(obj);
    return Results.Created($"/classes/{obj.Id}", obj);
})
    .WithName("Salvar Class")
    .WithOpenApi();

classGroup.MapPut("/{id}", async (int id, Class obj, IClassRepository repository) =>
{
    var _obj = await repository.GetByIdAsync(id);
    if (_obj is null) return Results.NotFound();

    _obj.ClassCode = obj.ClassCode;
    _obj.StartDate = obj.StartDate;
    _obj.EndDate = obj.EndDate;
    _obj.CourseId = obj.CourseId;
    _obj.InstructorId = obj.InstructorId;
    
    await repository.UpdateAsync(_obj);
    return Results.Ok(_obj);
})
    .WithName("Atualizar Class")
    .WithOpenApi();

classGroup.MapDelete("/{id}", async (int id, IClassRepository repository) =>
{
    await repository.DeleteAsync(id);
    return Results.NoContent();
})
    .WithName("Excluir Class")
    .WithOpenApi();

#endregion

#region Course

var courseGroup = app.MapGroup("/v1/courses")
    .WithTags("Courses");

courseGroup.MapGet("/", async (ICourseRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
})
    .WithName("Listar Courses")
    .WithOpenApi();

courseGroup.MapGet("/{id}", async (int id, ICourseRepository repository) =>
{
    var obj = await repository.GetByIdAsync(id);
    return obj != null ? Results.Ok(obj) : Results.NotFound();
})
    .WithName("Obter Course por Id")
    .WithOpenApi();

courseGroup.MapPost("/", async (Course obj, ICourseRepository repository) =>
{
    await repository.CreateAsync(obj);
    return Results.Created($"/courses/{obj.Id}", obj);
})
    .WithName("Salvar Course")
    .WithOpenApi();

courseGroup.MapPut("/{id}", async (int id, Course obj, ICourseRepository repository) =>
{
    var _obj = await repository.GetByIdAsync(id);
    if (_obj is null) return Results.NotFound();

    _obj.NameCourse = obj.NameCourse;
    _obj.Workload = obj.Workload;

    await repository.UpdateAsync(_obj);
    return Results.Ok(_obj);
})
    .WithName("Atualizar Course")
    .WithOpenApi();

courseGroup.MapDelete("/{id}", async (int id, ICourseRepository repository) =>
{
    await repository.DeleteAsync(id);
    return Results.NoContent();
})
    .WithName("Excluir Course")
    .WithOpenApi();
#endregion

#region Enrollment

var enrollmentGroup = app.MapGroup("/v1/enrollments")
    .WithTags("Enrollments");

enrollmentGroup.MapGet("/", async (IEnrollmentRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
})
    .WithName("Listar Enrollments")
    .WithOpenApi();

enrollmentGroup.MapGet("/{id}", async (int id, IEnrollmentRepository repository) =>
{
    var obj = await repository.GetByIdAsync(id);
    return obj != null ? Results.Ok(obj) : Results.NotFound();
})
    .WithName("Obter Enrollment por Id")
    .WithOpenApi();

enrollmentGroup.MapPost("/", async (Enrollment obj, IEnrollmentRepository repository) =>
{
    await repository.CreateAsync(obj);
    return Results.Created($"/enrollments/{obj.Id}", obj);
})
    .WithName("Salvar Enrollment")
    .WithOpenApi();

enrollmentGroup.MapPut("/{id}", async (int id, Enrollment obj, IEnrollmentRepository repository) =>
{
    var _obj = await repository.GetByIdAsync(id);
    if (_obj is null) return Results.NotFound();

    _obj.StudentId = obj.StudentId;
    _obj.ClassId = obj.ClassId;

    await repository.UpdateAsync(_obj);
    return Results.Ok(_obj);
})
    .WithName("Atualizar Enrollment")
    .WithOpenApi();

enrollmentGroup.MapDelete("/{id}", async (int id, IEnrollmentRepository repository) =>
{
    await repository.DeleteAsync(id);
    return Results.NoContent();
})
    .WithName("Excluir Enrollment")
    .WithOpenApi();
#endregion

#region Instructor

var instructorGroup = app.MapGroup("/v1/instructors")
    .WithTags("Instructors");

instructorGroup.MapGet("/", async (IInstructorRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
})
    .WithName("Listar Instructors")
    .WithOpenApi();

instructorGroup.MapGet("/{id}", async (int id, IInstructorRepository repository) =>
{
    var obj = await repository.GetByIdAsync(id);
    return obj != null ? Results.Ok(obj) : Results.NotFound();
})
    .WithName("Obter Instructor por Id")
    .WithOpenApi();

instructorGroup.MapPost("/", async (Instructor obj, IInstructorRepository repository) =>
{
    await repository.CreateAsync(obj);
    return Results.Created($"/instructors/{obj.Id}", obj);
})
    .WithName("Salvar Instructor")
    .WithOpenApi();

instructorGroup.MapPut("/{id}", async (int id, Instructor obj, IInstructorRepository repository) =>
{
    var _obj = await repository.GetByIdAsync(id);
    if (_obj is null) return Results.NotFound();

    _obj.Name = obj.Name;

    await repository.UpdateAsync(_obj);
    return Results.Ok(_obj);
})
    .WithName("Atualizar Instructor")
    .WithOpenApi();

instructorGroup.MapDelete("/{id}", async (int id, IInstructorRepository repository) =>
{
    await repository.DeleteAsync(id);
    return Results.NoContent();
})
    .WithName("Excluir Instructor")
    .WithOpenApi();
#endregion

#region Student

var studentGroup = app.MapGroup("/v1/estudents")
    .WithTags("Students");

studentGroup.MapGet("/", async (IStudentRepository repository) =>
{
    return Results.Ok(await repository.GetAllAsync());
})
    .WithName("Listar Students")
    .WithOpenApi();

studentGroup.MapGet("/{id}", async (int id, IStudentRepository repository) =>
{
    var obj = await repository.GetByIdAsync(id);
    return obj != null ? Results.Ok(obj) : Results.NotFound();
})
    .WithName("Obter Student por Id")
    .WithOpenApi();

studentGroup.MapPost("/", async (Student obj, IStudentRepository repository) =>
{
    await repository.CreateAsync(obj);
    return Results.Created($"/students/{obj.Id}", obj);
})
    .WithName("Salvar Student")
    .WithOpenApi();

studentGroup.MapPut("/{id}", async (int id, Student obj, IStudentRepository repository) =>
{
    var _obj = await repository.GetByIdAsync(id);
    if (_obj is null) return Results.NotFound();

    _obj.Name = obj.Name;
    _obj.StudentCode = obj.StudentCode;

    await repository.UpdateAsync(_obj);
    return Results.Ok(_obj);
})
    .WithName("Atualizar Student")
    .WithOpenApi();

studentGroup.MapDelete("/{id}", async (int id, IStudentRepository repository) =>
{
    await repository.DeleteAsync(id);
    return Results.NoContent();
})
    .WithName("Excluir Student")
    .WithOpenApi();
#endregion











//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
