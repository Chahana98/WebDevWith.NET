var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CollegeDbContext> ();
var app = builder.Build();

app.MapGet("/", () => " Learning developing REST API on .NET");
app.MapGet("/courses", (CollegeDbContext db) => db.Courses.ToList());
app.MapGet("/courses/{id:int}", (int id, CollegeDbContext db) => db.Courses.Find(id));
app.MapGet("/sessions", (CollegeDbContext db) =>db.Sessions.ToList());
app.MapGet("/sessions/{id:int}", (int id, CollegeDbContext db) => db.Sessions.Find(id));


app.Run();
