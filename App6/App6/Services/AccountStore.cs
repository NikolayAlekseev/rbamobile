using System;
using Newtonsoft.Json;
using Rbauto.Models;
using Xamarin.Forms;

namespace Rbauto.Services
{
    class AccountStore
    {
        const string AccountDataFileName = "account_data.json";

        public static void SaveAccount(AccountEntity account)
        {
            var json = JsonConvert.SerializeObject(account);
            var fs = DependencyService.Get<IFileSystem>();
            fs.WriteTextAsync(AccountDataFileName, json);
        }

        public static AccountEntity LoadAccount()
        {
            var fs = DependencyService.Get<IFileSystem>();
            var json = fs.ReadTextAsync(AccountDataFileName);
            try
            {
                return JsonConvert.DeserializeObject<AccountEntity>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ClearAccount()
        {
            var fs = DependencyService.Get<IFileSystem>();
            fs.WriteTextAsync(AccountDataFileName, null);
        }
    }
}
