import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class AppSignalRService {
  public hubConnection: signalR.HubConnection | undefined;

  public startConnection = (url:string) => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(url)
                            .configureLogging(signalR.LogLevel.Information)
                            .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }
}
