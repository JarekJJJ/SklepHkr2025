 using Microsoft.AspNetCore.SignalR;

    public class ProgressHub : Hub
    {
    // Możesz dodać metody, jeśli potrzebujesz
    public string GetConnectionId()
    {
        return Context.ConnectionId;
    }
}