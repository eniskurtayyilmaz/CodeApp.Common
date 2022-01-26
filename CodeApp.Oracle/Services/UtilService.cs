using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeApp.Oracle.Helpers;
using CodeApp.Oracle.Models;
using log4net;
using log4net.Repository.Hierarchy;

namespace CodeApp.Oracle.Services
{
    public interface IUtilService
    {
        User GetExistUser(string username, string password);
        string GetConnectionString();
        string GetJsonString();
        UserConfig GetUserConfig();
        string GetUserName();
    }

    public class UtilService : IUtilService
    {
        private readonly IJsonHelpers<UserConfig> _jsonHelpers;
        private ILog _logger = LogManager.GetLogger(typeof(UtilService));
        private string _userName = String.Empty;
        public UtilService(IJsonHelpers<UserConfig> jsonHelpers)
        {
            _jsonHelpers = jsonHelpers;
        }

        public User GetExistUser(string username, string password)
        {
            var userConfig = this.GetUserConfig();

            var existUser = userConfig.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (existUser == null)
            {
                string message = $"Kullanıcı bulunamadı, UserName == {username}, Password == {password}";
                _logger.Error(message);
                throw new Exception(message);
            }

            _userName = existUser.UserName;

            return existUser;
        }

        public string GetConnectionString()
        {
            var userConfig = this.GetUserConfig();
            if (string.IsNullOrEmpty(userConfig.ConnectionString) || string.IsNullOrWhiteSpace(userConfig.ConnectionString))
            {
                string message = $"ConnectionString bulunamadı";
                _logger.Error(message);
                throw new Exception(message);
            }

            return userConfig.ConnectionString;
        }


        public string GetJsonString()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            if (File.Exists(path) == false)
            {
                _logger.ErrorFormat("Path={0}", path);
                throw new Exception($"users.json dosyası bulunamadı");
            }
            var jsonString = File.ReadAllText(path);
            return jsonString;
        }

        public UserConfig GetUserConfig()
        {
            var existUserConfig = _jsonHelpers.GetJsonObject(this.GetJsonString());
            if (existUserConfig == null)
            {
                string message = $"UserConfig dosyasında bir hata meydana geldi";
                _logger.Error(message);
                _logger.ErrorFormat("JsonString={0}", this.GetJsonString());
                throw new Exception(message);
            }

            return existUserConfig;
        }

        public string GetUserName()
        {
            return _userName;
        }
    }
}
