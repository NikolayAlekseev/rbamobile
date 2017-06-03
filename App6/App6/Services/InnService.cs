using System;

namespace Rbauto.Services
{
    static class InnService
    {
        //Функция вычисления контрольной суммы
        private static int KontrSumINN(int n, string inn)
        {
            var s = 0;

            var checksum = new[] { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };

            for (var i = 1; i < n; i++)
                s += (Convert.ToInt32(inn.Substring(i - 1, 1)) * checksum[11 - n + i]);

            return (s % 11) % 10;
        }

        //Функция проверки ИНН, если ИНН правильный возвращает TRUE
        public static bool CheckINN(string inn)
        {
            if (string.IsNullOrEmpty(inn)) return false;

            var len = inn.Length;

            if (len == 10)
                return (Convert.ToInt32(inn.Substring(9, 1)) == KontrSumINN(10, inn));

            if (len == 11)
                return (Convert.ToInt32(inn.Substring(10, 1)) == KontrSumINN(11, inn));

            if (len == 12)
                return (Convert.ToInt32(inn.Substring(11, 1)) == KontrSumINN(12, inn));

            return false;
        }
    }
}
