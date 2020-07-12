import { NgModule } from '@angular/core';

import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';


@NgModule({
  imports: [
    MatDialogModule,
    MatInputModule,
    MatCheckboxModule,
    MatListModule,
    MatSelectModule
  ],
  exports: [
    MatDialogModule,
    MatInputModule,
    MatCheckboxModule,
    MatListModule,
    MatSelectModule
  ],
  providers: [
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false} }
  ],
})
export class MaterialModule {}
