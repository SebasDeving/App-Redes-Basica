using System;
using POO.Models;
using System.Linq;
using POO.Utilities.Log;



namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppManager(new LogJson());
            

            while (true)
            {


                Console.WriteLine($"Bienvenido al {app.AppTitle}");

                Console.WriteLine("Redes sociales disponibles");
                /*************************************USO DE CONCAT***************************************************************/
                // USANDO LINQ LIBRERIA
                foreach (var item in app.SocialNetworks.Concat(app.SocialNetWorksWithGroups))
                {
                    Console.WriteLine($"{item.Name}");
                }
                /**************************************************************************************************************/

                /********************************************USO DE FirstOrDefault***********************************************/

                Console.WriteLine("Escriba el nombre de la red social a la que desea ingresar");

                string socialNetworkName = Console.ReadLine();


                var SocialNetworkSelected = app.SocialNetworks.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName);
                Console.WriteLine(app.GetSocialNetworkInformation(SocialNetworkSelected));

                var SocialNetWorkWithGroupsSelected = app.SocialNetWorksWithGroups.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName);
                Console.WriteLine(app.GetSocialNetworkInformation(SocialNetWorkWithGroupsSelected));


                /***************************************************************************************************/
                Console.WriteLine("");
                Console.WriteLine("1. Agregar nuevo usuario");
                Console.WriteLine("2. Para ver las estadisticas");

                var OptionSelected = int.Parse(Console.ReadLine());

                switch (OptionSelected)
                {
                    case 1:
                        {
                            Console.WriteLine($"Ingrese su nombre: ");
                            string name = Console.ReadLine();
                            Console.WriteLine($"Ingrese su email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine($"Ingrese su edad: ");
                            short age = short.Parse(Console.ReadLine());
                            Console.WriteLine($"Ingrese su telefono : ");
                            string telephone = Console.ReadLine();

                            var user = new User();
                            user.Name = name;
                            user.Email = email;
                            user.Age = age;
                            user.Telephone = telephone;

                            if (user.IsValid())
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("_____________________________________________________________");
                                Console.WriteLine("Sus datos son:");
                                Console.WriteLine($"Bienvenido {user.Name}");
                                Console.WriteLine($"Nombre: {user.Name}");
                                Console.WriteLine($"Edad: {user.Age}");
                                Console.WriteLine($"Telefono: {user.Telephone}");
                                Console.WriteLine($"Email: {user.Email}");
                                Console.WriteLine($"Estado activo: {user.IsActive}");
                                Console.WriteLine($"Fecha de creación: {user.DateCreated}");
                                Console.WriteLine("_____________________________________________________________");
                            }
                            else
                            {
                                Console.WriteLine("Los datos del usuario no son validos");
                            }

                            if (SocialNetworkSelected != null)
                            {
                                int indexElement = app.SocialNetworks.IndexOf(SocialNetworkSelected);
                                app.SocialNetworks[indexElement].Users.Add(user);
                            }
                            if (SocialNetWorkWithGroupsSelected != null)
                            {
                                int indexElement = app.SocialNetWorksWithGroups.IndexOf(SocialNetWorkWithGroupsSelected);
                                app.SocialNetWorksWithGroups[indexElement].Users.Add(user);
                            }
                        }
                            break;
                    case 2:
                        {
                            if (SocialNetworkSelected != null)
                                Console.WriteLine(app.GetSocialNetworkStats(SocialNetworkSelected));

                            if (SocialNetWorkWithGroupsSelected != null)
                                Console.WriteLine(app.GetSocialNetworkStats(SocialNetWorkWithGroupsSelected));
                                break;
                        }
                 
                }

            }
        }
    }
}
