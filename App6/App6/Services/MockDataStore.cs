using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbauto.Models;
using Rbauto.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(MockDataStore))]
namespace Rbauto.Services
{
    public class MockDataStore : IDataStore<ContactItem>
    {
        bool isInitialized;
        List<ContactItem> items;

        public async Task<bool> AddItemAsync(ContactItem contactItem)
        {
            await InitializeAsync();

            items.Add(contactItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ContactItem contactItem)
        {
            await InitializeAsync();

            var _item = items.Where((ContactItem arg) => arg.Id == contactItem.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(contactItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(ContactItem contactItem)
        {
            await InitializeAsync();

            var _item = items.Where((ContactItem arg) => arg.Id == contactItem.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<ContactItem> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ContactItem>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<ContactItem>();
            var _items = new List<ContactItem>
            {
                new ContactItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Москва Север",
                    Phones ="+7 (495) 785-72-00, +7 (495) 785-72-02",
                    Address = "423800, Москва Север, Северный административный округ, Молжаниновский р-н, ул. Комсомольская, д.3а",
                    Email = "bogdanov.v@rbauto.ru",
                    Schedule = "ПН-ПТ: 9.00 - 18.00",
                    MapUrl = "http://www.rbauto.ru/files/nodus_items/0000/0006/files/himki_scheme.png",
                    MapDescription = "Ст.м. \"Речной вокзал\", последний вагон из центра, авт. № 851 до остановки \"Черкизово\", далее по подземному переходу перейти на другую сторону дороги и двигаться по направлению в область 10 минут, далее свернуть налево, двигаться до большого здания синего цвета с вывеской Русбизнесавто."
                },
                new ContactItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Москва Варшавка",
                    Phones ="+7 (495) 784-67-61",
                    Address = "117545, Москва Варшавка, Варшавское ш., д. 129/2",
                    Email = "semkina.e@rbauto.ru",
                    Schedule = "ПН-ПТ: 9.00 - 18.00",
                    MapUrl = "http://www.rbauto.ru/files/nodus_items/0000/0008/files/varshavka_scheme.png"
                },
                new ContactItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Москва Ленинградка",
                    Phones ="+7 (495) 225-61-31, +7 (495) 232-58-05",
                    Address = "125212, Москва Ленинградка, Кронштадтский бульвар, д.9, Московский Автокомбинат №8, 3-й этаж",
                    Email = "didenko.v@rbauto.ru",
                    Schedule = "ПН-ПТ: 9.00 - 18.00",
                    MapUrl = "http://www.rbauto.ru/files/nodus_items/0000/0009/files/leningradka_scheme.png"
                },
            };

            foreach (ContactItem item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
