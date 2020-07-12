import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ReceiptAPIResult } from './../services/models/receipt-model';

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})
export class ReceiptComponent {

  hasError: boolean = false;

  constructor(private dialogRef: MatDialogRef<ReceiptComponent>, @Inject(MAT_DIALOG_DATA) public data: ReceiptAPIResult) {
    this.hasError = data.errorMessage && data.errorMessage.length > 0;
  }

  close(): void {
    this.dialogRef.close();
  }

}
