import { ItemType } from './../../../app/shopping-item/item-type-interface';

export class ItemTemplateAPIResult {
  id: number;
  name: string;
  price: number;
  quantity: number;
  hasSalesTax: boolean;
  isImported: boolean;
  itemType: string;
  itemTypes: ItemType[]
}
