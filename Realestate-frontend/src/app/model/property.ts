import { IPropertyBase } from "./ipropertybase";
import { Photo } from "./photo";

export class Property implements IPropertyBase{
  id: number;
  sellRent: number;
  name: string;
  propertyTypeId: number;
  propertyType: string;
  bhk: number;
  furnishingTypeId: number;
  furnishingType: string;
  price: number;
  builtArea: number;
  carpetArea?: number;
  address: string;
  cityId: number;
  city: string;
  floorNo?: string;
  totalFloor?: string;
  readyToMove: boolean;
  age?: string;
  security?: number;
  maintenance?: number;
  estPossessionOn: Date;
  photo?: string;
  description?: string;
  photos?: Photo[];
}
