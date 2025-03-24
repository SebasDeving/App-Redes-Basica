using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using POO.Models;
using POO.Utilities.Log;

namespace POO.Models
{
    class AppManager
    {
        public string AppTitle { get; set; }

        public ILog<string> Log { get; set; }

        public AppManager(ILog<string> logger)
        {
            Log = logger;
            AppTitle = "Administrador de Redes Sociales";
            SocialNetworks = new List<SocialNetwork>();
            SocialNetWorksWithGroups = new List<SocialNetWorkWhithGroups>();
            InitializeSocialNetworks();
        }

        public void InitializeSocialNetworks()
        {
            SocialNetWorksWithGroups.Add(new SocialNetWorkWhithGroups()
            {
                Name = "Facebook",
                Description = "Red social para conectar con amigos",
                DateCreated = new DateTime(2008, 1, 20),
                Groups = new List<string>() { "Programadores C#", "Amantes de la musica", "Programadores Go" },
                Users = new List<User>()
            });

            SocialNetworks.Add(new SocialNetwork()
            {
                Name = "Instagram",
                Description = "Red social para intercambio de fotos y videos",
                DateCreated = new DateTime(2010, 5, 1)
            });

            SocialNetworks.Add(new SocialNetwork()
            {
                Name = "Twitter",
                Description = "Red social para intercambio de videos y debate",
                DateCreated = new DateTime(2010, 5, 1),
                
            });

            Log.SaveLog("InitializeSocialNetworks");
        }

        public List<SocialNetWorkWhithGroups> SocialNetWorksWithGroups { get; set; }

        public List<SocialNetwork> SocialNetworks { get; set; }

        //Generics
        public string GetSocialNetworkInformation<T>(T socialNetwork)
        {
            if (socialNetwork == null)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();

            var socialNetworkItem = socialNetwork as SocialNetwork;

            if (socialNetworkItem == null)
            {
                return "";
            }

            stringBuilder.AppendLine($"Nombre: {socialNetworkItem.Name}");
            stringBuilder.AppendLine($"Descripción: {socialNetworkItem.Description}");
            stringBuilder.AppendLine($"Fecha de creación: {socialNetworkItem.DateCreated.Year}");

            if (socialNetworkItem is SocialNetWorkWhithGroups socialNetworkWhithGroupsItem)
            {
                stringBuilder.AppendLine($"Grupos: {string.Join(",", socialNetworkWhithGroupsItem.Groups)}");
            }

            Log.SaveLog("GetSocialNetworkInformation");

            return stringBuilder.ToString();
        }

        public string GetSocialNetworkStats<T>(T socialNetwork)
        {
            if (socialNetwork == null)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();

            var socialNetworkItem = socialNetwork as SocialNetwork;

            try
            {
            if (socialNetworkItem == null || socialNetworkItem.Users == null)
            {
                return "";
            }
            stringBuilder.AppendLine($" ");
            stringBuilder.AppendLine($"__________________________________________________________________________________");
            stringBuilder.AppendLine($"Cantidad de usuarios : {socialNetworkItem.Users.Count}");
            stringBuilder.AppendLine($"Promedio de edad : {socialNetworkItem.Users.Average(p => p.Age)}");
            stringBuilder.AppendLine($"El usuario de mayor edad tiene : {socialNetworkItem.Users.Max(p => p.Age)} años");
            stringBuilder.AppendLine($"El usuario de menor edad tiene : {socialNetworkItem.Users.Min(p => p.Age)} años");
           

            if (socialNetworkItem is SocialNetWorkWhithGroups socialNetworkWhithGroupsItem)
            {
                stringBuilder.AppendLine($"Cantidad de Grupos: {socialNetworkWhithGroupsItem.Groups.Count}");
            }
            stringBuilder.AppendLine($"__________________________________________________________________________________");
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.Message);
            }

            Log.SaveLog("GetSocialNetworkStats");

            return stringBuilder.ToString();
        }
    }
}
