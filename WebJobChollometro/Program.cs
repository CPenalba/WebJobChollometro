using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

Console.WriteLine("Binvenido a nuestros Chollos!!!");
string connectionString = "Data Source=sqlcarolina3213.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=carolinasql;Password=PenalbaCorpa1@;Encrypt=True;Trust Server Certificate=True";

//NECESITAMOS UTILIZAR INYECCION DE DEPENDENCIAS PARA PODER CREAR LOS OBJETOS.
var provider = new ServiceCollection().AddTransient<RepositoryChollometro>()
    .AddDbContext<ChollometroContext>(options => options.UseSqlServer(connectionString)).BuildServiceProvider();

//DESDE ESTE CODIGO NECESITAMOS RECUPERAR EL REPO INYECTADO
RepositoryChollometro repo = provider.GetService<RepositoryChollometro>();

Console.WriteLine("Pulse Enter para Iniciar!!!");
Console.ReadLine();
await repo.PopulateChollosAzureAsync();
Console.WriteLine("Proceso completado correctamente");
Console.WriteLine("Enhorabuena!!!");


