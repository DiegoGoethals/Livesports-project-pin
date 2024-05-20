using Microsoft.AspNetCore.SignalR;
using Pin.LiveSports.Core.Entities;

namespace Pin.LiveSports.Blazor.Hubs
{
	public class GamesHub : Hub
	{
		public async Task AddGame(Game game)
		{
			await Clients.All.SendAsync("UpdateGamesList", game);
		}
	}
}
