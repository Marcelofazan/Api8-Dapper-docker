using ApiMySql.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// CONFIGURAÇÃO DOS SERVIÇOS (ConfigureServices)
// ==========================================

// Substitui o antigo AddMvc() e gerencia os controllers
builder.Services.AddControllers();

// Configuração do Swagger atualizada para o .NET 8
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência do repositório usando a connection string do appsettings.json
builder.Services.AddScoped<IPessoaRepository>(factory => 
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlDbConnection");
    return new PessoaRepository(connectionString);
});

var app = builder.Build();

// ==========================================
// PIPELINE DE EXECUÇÃO (Configure)
// ==========================================

if (!app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection();
}

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    // Ativa o middleware do Swagger e a interface gráfica
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = "api/swagger";
    });
}
else
{
    app.UseHsts();
}

// Redirecionamento HTTPS (opcional, mas recomendado no .NET 8)
app.UseHttpsRedirection();

// Configuração de rotas nativa (substitui o UseMvc)
app.UseAuthorization();
app.MapControllers();

app.Run();
