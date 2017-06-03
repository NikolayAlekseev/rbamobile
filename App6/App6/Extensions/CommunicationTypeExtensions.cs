using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbauto.Extensions
{
    static class CommunicationTypeExtensions
    {
        public static string GetCommunicationTypeName(this string code)
        {
            switch (code)
            {
                case "MOBILE":
                    return "Мобильный телефон";
                case "PHONE":
                    return "Телефон";
                case "FAX":
                    return "Факс";
                case "EMAIL":
                    return "Электронная почта";
                case "WEB":
                    return "Сайт";
                case "INNER_RBA":
                    return "Внутренний номер";
                default:
                    return string.Empty;
            }
        }
    }
}
