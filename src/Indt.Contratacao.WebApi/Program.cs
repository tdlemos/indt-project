using Indt.Contratacao.Application;
using Indt.Contratacao.Application.Services;
using Indt.Contratacao.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRefit(builder.Configuration);

builder.Services.AddScoped<IContratacaoService, ContratacaoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
