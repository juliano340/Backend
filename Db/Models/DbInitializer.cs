using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Models
{
    public static class DbInitializer
    {
        public static void SeedAdminUser(AppDbContext context)
        {
            // Verifica se já existe um usuário com o email admin
            if (!context.Pessoas.Any(p => p.Email == "admin@example.com"))
            {
                // Cria o usuário admin
                var admin = new Pessoa
                {
                    Name = "admin",
                    Email = "admin@example.com",
                    Password = "root", // TODO Use hashing para senhas
                    Role = Pessoa.UserRole.Admin
                };

                context.Pessoas.Add(admin);
                context.SaveChanges();

                Console.WriteLine("Admin user created.");
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }
        }

    }
}
