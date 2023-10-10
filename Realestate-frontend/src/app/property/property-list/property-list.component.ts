import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  Properties: Array<any> = [
    {
      "Id": 1,
      "Name": "Semi-Detached",
      "Type": "House",
      "Price": 12000
    },
    {
      "Id": 2,
      "Name": "Fountainhead",
      "Type": "Appartment",
      "Price": 20000
    },
    {
      "Id": 3,
      "Name": "Marco Home",
      "Type": "House",
      "Price": 14300
    },
    {
      "Id": 4,
      "Name": "Dawson house",
      "Type": "House",
      "Price": 18000
    },
    {
      "Id": 5,
      "Name": "Park Avenue",
      "Type": "Appartment",
      "Price": 17000
    },{
      "Id": 6,
      "Name": "Wilson Avenue",
      "Type": "House",
      "Price": 2600
    },
  ]

  constructor() { }
  ngOnInit(): void {

  }
}
