using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string VERSAO = "v1";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen(opt =>
{
    opt.DescribeAllParametersInCamelCase();
    opt.SwaggerDoc($"{VERSAO}", new OpenApiInfo
    {
        Version = $"{VERSAO}",
        Title = "NomeProjeto",
        Description = "DescricaoApi",
        TermsOfService = new Uri("https://www.google.com/"),
        License = new OpenApiLicense
        {
            Name = "License.Nome",
            Url = new Uri("https://www.google.com/"),
        },
        Contact = new OpenApiContact
        {
            Name = "Contact.Nome",
            Email = "Email",
            Url = new Uri("https://www.google.com/"),
        }
    });    

    foreach (var itemFile in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
        opt.IncludeXmlComments(itemFile, true);

    opt.ExampleFilters();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s=> 
    {
        s.SwaggerEndpoint($"/swagger/{VERSAO}/swagger.json", "NomeProjeto");
        s.DocumentTitle = "API-NomeProjeto";
        //s.RoutePrefix = string.Empty;

        s.DefaultModelRendering(ModelRendering.Model);      // Posiciona no Schema
        s.DefaultModelExpandDepth(2);                       // Abre todos os niveis do objeto do Schema
        s.EnableFilter();                                   // Mostra filtro de pesquisa
        s.DocExpansion(DocExpansion.None);                  // Fecha todas controles
        s.DefaultModelsExpandDepth(-1);                     // Ocultar os objetos 
        s.DisplayRequestDuration();                         // Mostra o tempo da requisição (Abaixo do-Response body\Response headers)
        if (!app.Environment.IsDevelopment())
            s.SupportedSubmitMethods();                     // Só habilita o "Try it out" para os tipos informados ex: SubmitMethod.Get

        s.InjectStylesheet("/swagger-ui/custom.css");
        s.InjectJavascript("/swagger-ui/custom.js");

        s.DisplayRequestDuration();                         // Tempo de demorou o request
        //s.DisplayOperationId();         // mostra um nome loko no método      
        //s.MaxDisplayedTags(2);          // define quantos metodos serão exibidos
        //s.EnableDeepLinking();          // não sei oq é
        //s.ShowExtensions();             // não sei oq é
        //s.EnableValidator(null);        // não sei oq é
        
    });    
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
