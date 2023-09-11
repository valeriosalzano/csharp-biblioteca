using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class User
    {
        // PROPERTIES
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }

        // CONSTRUCTORS
        public User(string name, string surname, string email, string password, string phone)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
        }

        // SEEDER
        static public List<User> UserSeeder()
        {
            return new List<User> {
                new User("Giorgio","Rossi","giorgiorossi@gmail.com","giorgiothebest","3331212123"),
                new User("Francesca","Verdi","francescaverdi@outlook.it","password","3331212122"),
                new User("Mario","Bianchi","mariobianchi@gmail.com","password","3341212123"),
                new User("Barbara","Neri","barbaraneri@gmail.com","testtest","3331212124"),
                new User("Giorgio","Rossi","giorgiorossi2@gmail.com","giorgiothebest","3331212126"),
            };

        }
    }
}
