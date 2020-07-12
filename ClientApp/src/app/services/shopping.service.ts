import { Observable } from 'rxjs/';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WebApiUrls } from './web-api-urls';
import { ReceiptAPIResult } from './models/receipt-model';
import { ItemTemplateAPIResult } from './models/item-template-model';


@Injectable()
export class ShoppingService {

  constructor(private http: HttpClient) {}

  public getReceipt(items: any): Observable<ReceiptAPIResult> {
    return this.http.post<ReceiptAPIResult>(WebApiUrls.getReceipt, items);
  }

  public getItemTemplate(): Observable<ItemTemplateAPIResult> {
    return this.http.get<ItemTemplateAPIResult>(WebApiUrls.getItemTemplate);
  }

}
