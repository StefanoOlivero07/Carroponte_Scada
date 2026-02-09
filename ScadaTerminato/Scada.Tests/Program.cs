var builder = WebApplication.CreateBuilder(args);

// Aggiunge i servizi MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Abilita i file statici (CSS, JS, immagini)
app.UseStaticFiles();

// Configura il routing: usa i Controller e le Views
app.UseRouting();

// Inizialmente non lo usiamo
// app.UseAuthorization();

// Imposta la route predefinita per i Controller
// MapControllerRoute è un metodo che accetta due parametri: nome e pattern.
// action è una funzione che è in grado di restituire qualcosa (stringa, pagina html ecc.)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();