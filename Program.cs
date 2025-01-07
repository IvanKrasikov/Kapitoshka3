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
    nodeDb.Add(new Node("���������� ������", 0, 0));
    nodeDb.Add(new Node("������", 5, 1));
    nodeDb.Add(new Node("�������� �����", 0, 1));
    nodeDb.Add(new Node("��������", 6, 3));
    nodeDb.Add(new Node("��������������", 4, 3));
    nodeDb.Add(new Node("�����������", 7, 1));
    nodeDb.Add(new Node("���������� ������"));
    nodeDb.Add(new Node("��������������� ���������", 0, 7));
    nodeDb.Add(new Node("��������", 0, 8));
    nodeDb.Add(new Node("�����", 3, 9));
    nodeDb.Add(new Node("�����", 2, 9));
    nodeDb.Add(new Node("�������", 4, 8));
    nodeDb.Add(new Node("����������", 0, 7));
    nodeDb.Add(new Node("������", 1, 13));
    nodeDb.Add(new Node("�����", 1, 13));
    nodeDb.Add(new Node("����������� ������"));
    nodeDb.Add(new Node("�������������", 0, 16));
    nodeDb.Add(new Node("LEGO Mindstorms", 6, 17));
    nodeDb.Add(new Node("Arduino", 2, 17));
    nodeDb.Add(new Node("�������������", 5, 16));
}

app.Run();
