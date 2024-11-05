using Application;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddDebug();
}

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressInferBindingSourcesForParameters = true;
                });
builder.Services.AddHttpClient().AddDistributedMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
//builder.Services.AddInfrastructure(builder.Configuration["ConnectionString"]!);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
