import * as signalR from '@microsoft/signalr'

const connection = new signalR.HubConnectionBuilder()
  .withUrl('https://localhost:7132/silrith-hub', {
    withCredentials: true,
  })
  .configureLogging(signalR.LogLevel.Information)
  .build()

export default connection
