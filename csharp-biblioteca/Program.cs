namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //seeders
            Library myLibrary = new Library();
            myLibrary.Users = User.UserSeeder();
            List<Book> books = Book.BooksSeeder(10);
            foreach (Book book in books)
            {
                myLibrary.Documents.Add(book);
            }
            List<DVD> dvds = DVD.DVDsSeeder(10);
            foreach(DVD d in dvds)
            {
                myLibrary.Documents.Add(d);
            }

            //program start
            bool exitProgram = false;
            User loggedUser = null;
            do
            {
                if(loggedUser == null)
                {
                    Console.WriteLine(Environment.NewLine + "***** Menù *****" + Environment.NewLine);
                    Console.WriteLine("1. Accedi");
                    Console.WriteLine("2. Registrati");
                    Console.WriteLine("0. Esci");
                    Console.WriteLine(Environment.NewLine + "**************" + Environment.NewLine);

                    Console.Write("Digita il numero corrispondente: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine(Environment.NewLine + "--- Accesso ---" + Environment.NewLine);
                                Console.Write("Digita la mail: ");
                                string userEmail = Console.ReadLine();
                                User user = myLibrary.GetUser(userEmail);
                                if(user == null)
                                    Console.WriteLine("Email non registrata.");
                                else
                                {
                                    Console.Write("Digita la password: ");
                                    if (Console.ReadLine() == user.Password)
                                    {
                                        loggedUser = user;
                                        Console.WriteLine(Environment.NewLine + $"--- Bentornat* {loggedUser.Name}! ---" + Environment.NewLine);
                                    }
                                    else
                                        Console.WriteLine("Password errata");
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine(Environment.NewLine + "--- Registrazione ---" + Environment.NewLine);
                                
                                Console.Write("Inserisci il tuo nome: ");
                                string name = Console.ReadLine();

                                Console.Write("Inserisci il tuo cognome: ");
                                string surname = Console.ReadLine();

                                Console.Write("Inserisci la tua email: ");
                                string email = Console.ReadLine();

                                Console.Write("Inserisci la tua password: ");
                                string password = Console.ReadLine();

                                Console.Write("Inserisci il tuo numero telefonico: ");
                                string phone = Console.ReadLine();

                                
                                loggedUser = new User(name, surname, email, password, phone);
                                myLibrary.AddUser(loggedUser);
                                Console.WriteLine(Environment.NewLine + $"--- Benvenut* {loggedUser.Name}! ---" + Environment.NewLine);
                                break;
                            }
                        case "0":
                            {
                                Console.WriteLine(Environment.NewLine + "--- Arrivederci! ---" + Environment.NewLine);
                                exitProgram = true;
                                break;
                            }
                        default:
                            Console.WriteLine("Comando non riconosciuto");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "***** Menù *****" + Environment.NewLine);
                    Console.WriteLine("1. Cerca documento per id");
                    Console.WriteLine("2. Cerca documento per titolo");
                    Console.WriteLine("3. Prendi in prestito un documento");
                    Console.WriteLine("4. Stampa i miei prestiti");
                    Console.WriteLine("5. Restituisci documento.");
                    Console.WriteLine("0. Esci");
                    Console.WriteLine(Environment.NewLine + "**************" + Environment.NewLine);

                    Console.Write("Digita il numero corrispondente: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                string userInput = "";
                                Console.WriteLine(Environment.NewLine + "--- Ricerca per id ---" + Environment.NewLine);

                                while (string.IsNullOrEmpty(userInput) || userInput.Length < 8)
                                {
                                    Console.Write("Digita l'id da cercare (solo alfanumerici di 8 cifre): ");
                                    userInput = Console.ReadLine();
                                }
                                Document document = myLibrary.GetDocumentByID(userInput);
                                if (document != null)
                                {
                                    Console.WriteLine(document.ToString());
                                }
                                else
                                {
                                    Console.WriteLine($"Non è stato trovato un documento con ID {userInput}.");
                                }
                                
                                break;
                            }
                        case "2":
                            {
                                string userInput = "";
                                Console.WriteLine(Environment.NewLine + "--- Ricerca per titolo ---" + Environment.NewLine);

                                while (string.IsNullOrEmpty(userInput))
                                {
                                    Console.Write("Digita il titolo da cercare: ");
                                    userInput = Console.ReadLine();
                                }
                                Document document = myLibrary.GetDocumentByTitle(userInput);
                                if (document != null)
                                {
                                    Console.WriteLine(document.ToString());
                                }
                                else
                                {
                                    Console.WriteLine($"Non è stato trovato un documento con titolo {userInput}.");
                                }
                                break;
                            }
                        case "3":
                            {
                                string userInput = "";

                                Console.WriteLine(Environment.NewLine + "--- Prestito di un documento ---" + Environment.NewLine);

                                while (string.IsNullOrEmpty(userInput))
                                {
                                    Console.Write("Digita l'id/titolo del documento che vuoi prendere in prestito: ");
                                    userInput = Console.ReadLine();
                                }
                                    myLibrary.AddLoan(loggedUser.Email, userInput, DateTime.Now);
                                break;
                            }
                        case "4":
                            {
                                string userInput = "";

                                Console.WriteLine(Environment.NewLine + "--- Stampa prestiti ---" + Environment.NewLine);

                                List<Loan> loansList = myLibrary.GetLoans(loggedUser.Email);
                                if (loansList.Count > 1)
                                {
                                    foreach (Loan loan in loansList)
                                        Console.WriteLine("----------" + loan.ToString());
                                }
                                else
                                    Console.WriteLine("Non risultano prestiti effettuati.");

                                break;
                            }
                        case "5":
                            {
                                string userInput = "";

                                Console.WriteLine(Environment.NewLine + "--- Restituisci documento ---" + Environment.NewLine);

                                while (string.IsNullOrEmpty(userInput))
                                {
                                    Console.Write("Digita l'id/titolo del documento che vuoi restituire: ");
                                    userInput = Console.ReadLine();
                                }
                                myLibrary.CloseLoan(loggedUser.Email, userInput, DateTime.Now);
                                break;
                            }
                        case "0":
                            {
                                Console.WriteLine(Environment.NewLine + $"--- Arrivederci! ---" + Environment.NewLine);
                                exitProgram = true;
                                break;
                            }
                        default:
                            Console.WriteLine("comando non riconosciuto");
                            break;
                    }
                }

            } while (!exitProgram);

        }
    }

}