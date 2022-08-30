using System;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.ChannelPoints.GetCustomReward;
namespace TwitchApp
{
    internal class TwitchApi
    {
        public TwitchAPI? api;
        public TwitchApi()
        {
            this.api = new TwitchAPI();
            this.api.Settings.ClientId = Properties.Settings.Default.CLIENTID;
            this.api.Settings.AccessToken = Globals.TwichToken;
        }

        public async void ChangeGameAndTitle(string title, string game)
        {
            await api.V5.Channels.UpdateChannelAsync(channelId: api.Settings.ClientId, status: title, game: game);
        }

        public async ValueTask<GetCustomRewardsResponse> GetRewardImage(List<string> reward)
        {
            return await api.Helix.ChannelPoints.GetCustomReward(broadcasterId: api.Settings.ClientId, rewardIds: reward);
        }

        public async void GetUserFollows()
        {
            var response = await api.Helix.Users.GetUsersFollowsAsync(fromId: Globals.TwichChannelId);
            System.Console.WriteLine(response.Follows.Length);
        }

    }
}
