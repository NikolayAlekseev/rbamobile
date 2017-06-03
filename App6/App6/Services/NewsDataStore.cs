using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbauto.Models;
using Rbauto.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(NewsDataStore))]
namespace Rbauto.Services
{
    public class NewsDataStore : IDataStore<NewsItem>
    {
        bool isInitialized;
        List<NewsItem> items;

        public async Task<bool> AddItemAsync(NewsItem contactItem)
        {
            await InitializeAsync();

            items.Add(contactItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(NewsItem contactItem)
        {
            await InitializeAsync();

            var _item = items.Where((NewsItem arg) => arg.Id == contactItem.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(contactItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(NewsItem contactItem)
        {
            await InitializeAsync();

            var _item = items.Where((NewsItem arg) => arg.Id == contactItem.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<NewsItem> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<NewsItem>> GetItemsAsync(bool forceRefresh = false)
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

            items = new List<NewsItem>();
            var _items = new List<NewsItem>
            {
                new NewsItem
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsDate = "31 марта 2017",
                    Name = "Конкурсы профессионального мастерства «TOP DRIVER SDLG» возвращаются в Россию",
                    ImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4117/_cache/crop100x100-image-4117-1490959022.png",
                    MainImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4117/_cache/crop570x200-image_full-4117-1490959132.png",
                    MainImageHeight = 120,
                    Rows = new []
                    {
                        "В 2017 году компания Русбизнесавто - эксклюзивный дистрибьютор дорожно-строительной техники мирового бренда SDLG на территории России - проводит конкурс профессионального мастерства операторов фронтальных погрузчиков «TOP DRIVER SDLG». Операторам предстоит пройти испытания на скорость передвижения и точность манипуляций при помощи навесного оборудования фронтального погрузчика.",
                        "В этом году конкурсы пройдут в следующих городах:",
                        " - Ростов-на-Дону",
                        " - Симферополь",
                        " - Красноярск",
                        " - Санкт-Петербург",
                        "В рамках мероприятий будут проведены презентации всей линейки дорожно-строительной техники SDLG и предложены специальные условия по приобретению техники.",
                        "Все гости конкурсов получат памятные подарки, а победителю и представителю его компании будет передан сертификат на поездку в VIP-тур в Китай.",
                        "Конкурсы профессионального мастерства «TOP DRIVER SDLG» проводятся в России второй год и уже прошли в Иркутске, Екатеринбурге и Москве. В прошлом году за право называться лучшим оператором фронтальных погрузчиков боролись более 70 специалистов.",
                        "«TOP DRIVER SDLG» - докажите, что вы лучшие в своей профессии!"
                    }
                },
                new NewsItem
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsDate = "21 марта 2017",
                    Name = "Презентация коммунальной техники производства «Ряжского АРЗ» в Ростове-на-Дону",
                    ImageUrl = "http://www.rbauto.ru/image/news-default-image.jpg",
                    Rows = new []
                    {
                        "2 марта 2017 года в Ростове-на-Дону на территории автокомплекса Русбизнесавто прошла презентация коммунальной техники производства «Ряжского АРЗ». Организатором мероприятия выступила компания Русбизнесавто - ведущий оператор на рынке продаж спецтехники, грузовой автотехники и автобусов. В мероприятии приняли участие ведущие организации, участвующие в процессе благоустройства Ростова-на-Дону и близлежащих городов. Гости смогли детально ознакомиться с техническими характеристиками и оснащением компактных моделей с высоким коэффициентом прессования на базе ГАЗон NEXT, среднеразмерных мусоровозов на базе КАМАЗ 43253 с боковой и задней загрузкой, крупных единиц коммунальной техники на базе КАМАЗ с объемом кузова до 27 м3.",
                        "Наибольший интерес представители муниципальных организаций оказали машинам с задней загрузкой, системой дезинфекции и функцией сбора жидкой фракции, в частности, к компактным моделям на базе ГАЗон NEXT, которые благодаря своей мобильности подходят для эксплуатации в условиях узких улиц городов Ростовской области.",
                        "Высокотехнологичная и неприхотливая техника производства «Ряжского АРЗ», давно зарекомендовавшая себя, пользуется большим спросом на российском рынке. Это подтверждает тот факт, что по результатам мероприятия несколько единиц мусоровозов готовятся к отгрузке.",
                        "Стоит отметить, что компания Русбизнесавто проводит целый ряд презентаций коммунальной техники производства «Ряжского АРЗ», которые уже прошли в Краснодаре и Екатеринбурге, а в апреле, в свою очередь, мероприятие пройдет в Симферополе."
                    },
                    AdditionalImagesUrl = new []
                    {
                        "http://www.rbauto.ru/files/nodus_items/0008/4111/_cache/gallery/crop180x119/20170301_160803.jpg-1490102793.jpg",
                        "http://www.rbauto.ru/files/nodus_items/0008/4111/_cache/gallery/crop180x119/20170302_112414.jpg-1490102793.jpg",
                        "http://www.rbauto.ru/files/nodus_items/0008/4111/_cache/gallery/crop180x119/20170302_115003.jpg-1490102793.jpg",
                        "http://www.rbauto.ru/files/nodus_items/0008/4111/_cache/gallery/crop180x119/20170302_123423.jpg-1490102793.jpg"
                    }
                },
                new NewsItem
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsDate = "9 марта 2017",
                    Name = "Русбизнесавто – один из лучших дилеров Heli в мире",
                    ImageUrl = "http://www.rbauto.ru/image/news-default-image.jpg",
                    Rows = new []
                    {
                        "По итогам 2016 года компания Русбизнесавто вошла в топ 10 лучших дилеров техники производства китайского завода Heli в мире. Данный результат является по-настоящему впечатляющим, особенно учитывая тот факт, что сотрудничество с данным заводом ведется на протяжении менее двух лет.",
                        "Совместно с Heli компания Русбизнесавто вывела на российский рынок складское оборудование под брендом BULL, учитывающее все клиентские потребности. За столь небольшой период, техника смогла хорошо зарекомендовать себя и набрала большое количество положительных отзывов.",
                        "Модельная линейка складской техники BULL включает в себя: дизельные, бензиновые и электрические погрузчики с грузоподъемностью от 1 до 46, от 1 до 7 и от 1 до 10 тонн соответственно. Широкая линейка складской техники также включает в себя электрические и гидравлические штабелеры, транспортировщики паллет, ричтраки.",
                        "Компания Русбизнесавто не намерена останавливаться на достигнутом результате и в 2017 году с брендом BULL планирует войти в топ 5 среди дилеров по техники производства Heli в мире."
                    },
                    AdditionalImagesUrl = new []
                    {
                        "http://www.rbauto.ru/files/nodus_items/0008/4087/attaches/heli.jpg"
                    }
                },
                new NewsItem
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsDate = "7 марта 2017",
                    Name = "С 8 Марта!",
                    ImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4086/_cache/crop100x100-image-4086-1488870752.png",
                    MainImageHeight = 300,
                    MainImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4086/attaches/0308.png"
                },
                new NewsItem
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsDate = "22 февраля 2017",
                    Name = "С Днем защитника Отечества!",
                    ImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4078/_cache/crop100x100-image-4078-1487768083.png",
                    MainImageHeight = 300,
                    MainImageUrl = "http://www.rbauto.ru/files/nodus_items/0008/4078/attaches/web.png"
                },
            };

            foreach (NewsItem item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
