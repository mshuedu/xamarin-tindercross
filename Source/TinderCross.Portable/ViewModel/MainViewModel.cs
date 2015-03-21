using System;
using System.Collections.Generic;
using TinderCross.Portable.Model;
using System.Threading.Tasks;

namespace TinderCross.Portable.ViewModel
{
    public class MainViewModel
    {
        private List<Girl> girls = new List<Girl>();
        private int currentGirlIndex = 0;

        private string userName;

        public MainViewModel(string userName = "Balint Farkas")
        {
            this.userName = userName;
        }

        public async Task Initialize()
        {
            girls = await Globals.MainModel.LoadGirls();
            currentGirlIndex = 0;
        }

        public Girl GetCurrentGirl()
        {
            if (girls.Count > currentGirlIndex)
                return girls[currentGirlIndex];
            else
                return null;
        }

        public void MoveToNextGirl()
        {
            // We stop when we run out of girls. We allow the index to go one above the maximum permissible value so that all
            // later GetCurrentGirl() calls will return null and the app will know that we ran out of profiles to display.
            if (girls.Count >= currentGirlIndex)
                currentGirlIndex++;
        }

        public async Task AddLike(bool value)
        {
            if (GetCurrentGirl() != null)
            {
                await Globals.MainModel.AddLike(
                    new Like()
                    {
                        GirlId = GetCurrentGirl().Id,
                        Id = Guid.NewGuid().ToString(),
                        UserId = userName,
                        Value = value ? 1 : 0
                    });
            }
        }
    }
}