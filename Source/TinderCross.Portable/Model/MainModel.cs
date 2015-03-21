using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TinderCross.Portable.Model
{
    public class MainModel
    {
        public MobileServiceClient MobileService;

        public MainModel()
        {
            MobileService = new MobileServiceClient("https://SAJÁT MOBILE SERVICE URL.azure-mobile.net/", "SAJÁT ACCESS KEY");
        }

        public async Task<List<Girl>> LoadGirls()
        {
            var girlsTable = MobileService.GetTable<Girl>();

            return await girlsTable
                .Where(girl =>
                    girl.Age >= 18)
                .ToListAsync();
        }

        public async Task AddLike(Like like)
        {
            var likesTable = MobileService.GetTable<Like>();
            await likesTable.InsertAsync(like);
        }

        //private void GenerateGirls()
        //{
        //    // Generate girls to fill the table
        //    Random rnd = new Random((int)DateTime.Now.Ticks);
        //    List<string> names = new List<string>() { "Bea", "Judit", "Réka", "Zsófi", "Timi" };
        //    for (int i = 0; i < 5; i++)
        //    {
        //        await girlsTable.InsertAsync(new Girl()
        //            {
        //                Age = rnd.Next(18, 26),
        //                Id = Guid.NewGuid().ToString(),
        //                ImageUrl = string.Format("https://SAJÁT BLOB STORAGE.blob.core.windows.net/images/girl{0}.jpg", i + 1),
        //                Name = names[i]
        //            });
        //    }
        //}
    }
}