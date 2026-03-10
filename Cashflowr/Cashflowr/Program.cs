using GranaFacil.Data;
using GranaFacil.Repositories;
using GranaFacil.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyCashConnection");


//registra os controllers
builder.Services.AddControllers(); 

//serve para abrir o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ativa o autoMapper e carrega os mapeamentos definidos nos profiles
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*configuracao do banco. Esse bloco faz com que o EFCore:
-Registre o DbContext no sistema de DI;
-Use o MySQl como banco de dados (usar o connectionString para isso, lá contem as configs do banco);
-Detecte automaticamente a versão do MYSQL;
*/
builder.Services.AddDbContext<GranaFacilContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);


//onde liga-se a interface à implementação concreta. Registrando a DI dos repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<IGastoRepository, GastoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IMetaRepository, MetaRepository>();

//registrando a DI dos services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ContaService>();
builder.Services.AddScoped<EntradaService>();
builder.Services.AddScoped<GastoService>();
builder.Services.AddScoped<MetaService>();
builder.Services.AddScoped<ReservaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();