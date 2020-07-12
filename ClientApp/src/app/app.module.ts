import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module';
import { MatCurrencyFormatModule } from 'mat-currency-format';

import { AppComponent } from './app.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ShoppingItemComponent } from './shopping-item/shopping-item.component';

import { ShoppingService } from './services/shopping.service';
import { ReceiptComponent } from './receipt/receipt.component';

@NgModule({
  declarations: [
    AppComponent,
    ShoppingCartComponent,
    ShoppingItemComponent,
    ReceiptComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    MatCurrencyFormatModule,
    RouterModule.forRoot([
      { path: '', component: ShoppingCartComponent, pathMatch: 'full' }
    ]),
    NoopAnimationsModule
  ],
  entryComponents: [
    ShoppingItemComponent,
    ReceiptComponent
  ],
  providers: [ShoppingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
