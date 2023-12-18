import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { IPropertyBase } from '../model/ipropertybase';
import { Property } from '../model/property';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseurl = environment.baseurl

  constructor(private http: HttpClient) { }

  getAllCities(): Observable<string[]>{
    return this.http.get<string[]>(this.baseurl + '/city/cities');
  }

  getProperty(id: number) {
    return this.getAllPRoperties(1).pipe(
      map(propertiesArray => {
        // throw new Error('Some error.');
        return propertiesArray.find(p => p.id === id) as Property;
      })
    );
  }

  getAllPRoperties(SellRent?: number): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseurl + '/property/list/'+SellRent?.toString());
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
}
