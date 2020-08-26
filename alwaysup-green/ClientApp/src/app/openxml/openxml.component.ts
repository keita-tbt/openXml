import { Component, OnInit } from '@angular/core';
import { getBaseUrl } from '../../main';
import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { async } from 'rxjs/internal/scheduler/async';
import { ASTWithSource } from '@angular/compiler';

@Component({
  selector: 'app-openxml',
  templateUrl: './openxml.component.html',
  styleUrls: ['./openxml.component.css']
})
export class OpenxmlComponent implements OnInit {
  private baseUrl: string;
  private ht: HttpClient;
  constructor(http: HttpClient) {
    this.baseUrl = getBaseUrl();
    this.ht = http;
  }

  public addText() {
    this.ht.get(this.baseUrl + 'api/AddText').subscribe(res => {
      console.log("api response: " + res);
    }, error => console.error(error))
  }

  public addTable() {
    this.ht.get(this.baseUrl + 'api/AddTable').subscribe(res => {
      console.log("api response: " + res);
    }, error => console.error(error))
  }

  public replaceText() {
    this.ht.get(this.baseUrl + 'api/ReplaceText').subscribe(res => {
      console.log("api response: " + res);
    }, error => console.error(error))
  }

  public replaceTextInTable() {
    this.ht.get(this.baseUrl + 'api/ReplaceTextInTable').subscribe(res => {
      console.log("api response: " + res);
    }, error => console.error(error))
  }

  public downloadFile() {
    this.ht.get(this.baseUrl + 'api/DownloadFile', { responseType: 'blob' }).subscribe(res => {
      console.log("api response: " + res);
      var newBlob = new Blob([res], { type: "application/octet-stream" });
      // IE doesn't allow using a blob object directly as link href
      // instead it is necessary to use msSaveOrOpenBlob
      if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(newBlob);
        return;
      }
      // For other browsers: 
      // Create a link pointing to the ObjectURL containing the blob.
      const data = window.URL.createObjectURL(newBlob);

      var link = document.createElement('a');
      const formatDate = new Date().toLocaleTimeString();
      link.href = data;
      link.download = "sample.docx";
      // this is necessary as link.click() does not work on the latest firefox
      link.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window }));

      setTimeout(function () {
        // For Firefox it is necessary to delay revoking the ObjectURL
        window.URL.revokeObjectURL(data);
        link.remove();
      }, 100);
    }, error => console.error(error))
  }

  ngOnInit() {
  }

}
