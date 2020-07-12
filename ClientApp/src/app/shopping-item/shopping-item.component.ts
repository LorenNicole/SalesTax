import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Item } from './item-interface';

@Component({
  selector: 'app-shopping-item',
  templateUrl: './shopping-item.component.html',
  styleUrls: ['./shopping-item.component.css']
})
export class ShoppingItemComponent {

  selectedItemType: string = '';
  newItemInvalid: boolean = false;

  constructor(private dialogRef: MatDialogRef<ShoppingItemComponent>, @Inject(MAT_DIALOG_DATA) public data: Item) {
    this.selectedItemType = data.itemType;
  }

  closeDialog(event, close): void {
    if (close) {
      this.dialogRef.close();
    } else {
      this.data.itemType = this.selectedItemType;
      if (!this.newItemIsValid(this.data)) {
        this.newItemInvalid = true;
      } else {
        this.dialogRef.close(this.data);
      }
    }
  }

  newItemIsValid(newItem: Item): boolean {
    return (newItem.name !== undefined && newItem.name.trim() !== '' &&
      newItem.itemType !== undefined && newItem.itemType !== null &&
      newItem.quantity > 0 &&
      newItem.price > 0);
  }

}
