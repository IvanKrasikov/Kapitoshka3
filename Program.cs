using Kapitoshka3.Models.Node.Persistence;
using Kapitoshka3.Models.Node.Domain.Entity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

NodeDb nodeDb = new();
if (nodeDb.IsNull())
{
    nodeDb.Add(new Node("Спортивные секции", 0, 0));
    nodeDb.Add(new Node("Футбол", 5, 1));
    nodeDb.Add(new Node("Цирковая школа", 0, 1));
    nodeDb.Add(new Node("Клоунада", 6, 3));
    nodeDb.Add(new Node("Эквилибристика", 4, 3));
    nodeDb.Add(new Node("Иппотерапия", 7, 1));
    nodeDb.Add(new Node("Творческие студии"));
    nodeDb.Add(new Node("Изобразительное искусство", 0, 7));
    nodeDb.Add(new Node("Живопись", 0, 8));
    nodeDb.Add(new Node("Гуашь", 3, 9));
    nodeDb.Add(new Node("Масло", 2, 9));
    nodeDb.Add(new Node("Графика", 4, 8));
    nodeDb.Add(new Node("Литература", 0, 7));
    nodeDb.Add(new Node("Поэзия", 1, 13));
    nodeDb.Add(new Node("Проза", 1, 13));
    nodeDb.Add(new Node("Технические кружки"));
    nodeDb.Add(new Node("Робототехника", 0, 16));
    nodeDb.Add(new Node("LEGO Mindstorms", 6, 17));
    nodeDb.Add(new Node("Arduino", 2, 17));
    nodeDb.Add(new Node("Моделирование", 5, 16));
}

app.Run();
