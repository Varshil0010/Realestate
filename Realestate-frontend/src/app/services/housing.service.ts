import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { IPropertyBase } from '../model/ipropertybase';
import { Property } from '../model/property';
import { environment } from 'src/environments/environment';
import { Ikeyvaluepair } from '../model/ikeyvaluepair';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseurl = environment.baseurl

  constructor(private http: HttpClient) { }

  getAllCities(): Observable<string[]> {
    return this.http.get<string[]>(this.baseurl + '/city/cities');
  }

  getPropertyTypes(): Observable<Ikeyvaluepair[]> {
    return this.http.get<Ikeyvaluepair[]>(this.baseurl + '/propertytype/list');
  }

  getFurnishingTypes(): Observable<Ikeyvaluepair[]> {
    return this.http.get<Ikeyvaluepair[]>(this.baseurl + '/furnishingtype/list');
  }

  getProperty(id: number) {
    return this.http.get<Property>(this.baseurl + '/property/detail/' + id?.toString());
  }

  getAllPRoperties(SellRent?: number): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseurl + '/property/list/' + SellRent?.toString());
  }

  addProperty(property: Property) {
    let newProp = [property];

    //Avoid overwriting property
    //Add new property in array if newProp already exists in local storage
    if (localStorage.getItem('newProp')) {
      newProp = [property,
        ...JSON.parse(localStorage.getItem('newProp')!)];
    }
    localStorage.setItem('newProp', JSON.stringify(newProp));
  }

  newPropID() {
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(+localStorage.getItem('PID')! + 1));
      return +localStorage.getItem('PID')!;
    }
    else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }

  getPropertyAge(dateofEstablishment: Date): string {
    const today = new Date();
    const estDate = new Date(dateofEstablishment);
    let age = today.getFullYear() - estDate.getFullYear();
    const m = today.getMonth() - estDate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
      age --;
    }

    if (today < estDate) {
      return '0';
    }

    if (age === 0) {
      return 'Less than a year';
    }

    return age.toString();
  }
}
