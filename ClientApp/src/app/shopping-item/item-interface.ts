import { ItemType } from './item-type-interface';

export interface Item {
  id: number;
  name: string;
  price: number;
  quantity: number;
  isImported: boolean;
  hasSalesTax: boolean;
  itemType: string;
  itemTypes: ItemType[];
}
