using BlogAPI2.EndPoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.AddAnalyticsEndpoints();
app.AddBlogsEndpoints();
app.AddLoggingEndpoints();

app.MapGet("/", () => "Hello World!");
app.UseSwaggerUI();
app.Run();