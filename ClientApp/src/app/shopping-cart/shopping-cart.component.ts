import { Component, OnInit} from '@angular/core';
import { Item } from '../shopping-item/item-interface';
import { MatDialog } from '@angular/material/dialog';
import { ShoppingItemComponent } from '../shopping-item/shopping-item.component';
import { ReceiptComponent } from './../receipt/receipt.component';
import { ShoppingService } from './../services/shopping.service';
import { ReceiptAPIResult } from './../services/models/receipt-model';
import { ItemTemplateAPIResult } from './../services/models/item-template-model';
import * as _ from 'lodash';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  items: ItemTemplateAPIResult[] = [];
  newId: number = 0;
  private itemTemplate: ItemTemplateAPIResult;

  constructor(public dialog: MatDialog, private shoppingService: ShoppingService) { }

  ngOnInit(): void {
    this.shoppingService.getItemTemplate().subscribe((response: ItemTemplateAPIResult) => {
      this.itemTemplate = response;
    });
  }

  addItem() {
      const dialogRef = this.dialog.open(ShoppingItemComponent, {
      width: '350px',
      hasBackdrop: true,
      data: _.clone(this.itemTemplate)
    });

    dialogRef.afterClosed().subscribe(result => {
      this.updateItems(result);
    });
  }

  removeItems(){
    this.items = [];
  }

  removeItem(item: ItemTemplateAPIResult) {
    _.pull(this.items, item);
  }

  updateItems(item: Item) {
    if (item) {
      this.newId++;
      item.id = this.newId;
      this.items.push(item);
    } 
  }

  getReceipt() {
    this.shoppingService.getReceipt(this.items).subscribe((response: ReceiptAPIResult) => {
        const dialogRef = this.dialog.open(ReceiptComponent, {
          width: '30%',
          hasBackdrop: true,
          data: response
        });

        dialogRef.afterClosed().subscribe(result => {
          this.updateItems(result);
        });
    });
  }

}
