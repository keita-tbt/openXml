import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from '../../main';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public ipadr: ipadr;
  private url: string;
  private ht: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;

    console.log(baseUrl);
    this.ipadr = {
      forwardedFor: "",
      forwardedHost: "",
      forwardedProto: "",
      remoteIp: "",
      requestStatus: "未実施"

    }
    /*
    http.get<ipadr>(baseUrl + 'ipadr').subscribe(res => {
      this.ipadr = res;
    }, error => console.error(error));
    */
    
    
    this.ht = http;
   
  }

public getIpadr(): void {
    this.ht.get<ipadr>(this.url + 'ipadr').subscribe(res => {
      this.ipadr = res;
    }, error => console.error(error))
  }

  public test(): void {
    console.log(getBaseUrl());
  }
}

interface ipadr {
  forwardedFor: string
  forwardedHost: string
  forwardedProto: string
  remoteIp: string
  requestStatus: string
}

/*
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
*/
