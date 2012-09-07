namespace ExemploWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExemploWebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExemploWebApi.Models.ExemploWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExemploWebApi.Models.ExemploWebAPIContext context)
        {
            context.Contatos.AddOrUpdate(
                new Contato() {
                    Id = 1,
                    PrimeiroNome = "Pessoa",
                    UltimoNome = "Um",
                    Email = "pessoa1@pessoas.com"
                },
                new Contato() {
                    Id = 2,
                    PrimeiroNome = "Pessoa",
                    UltimoNome = "Dois",
                    Email = "pessoa2@pessoas.com"
                },
                new Contato() {
                    Id = 3,
                    PrimeiroNome = "Pessoa",
                    UltimoNome = "Tres",
                    Email = "pessoa2@pessoas.com"
                }
            );
        }
    }
}
