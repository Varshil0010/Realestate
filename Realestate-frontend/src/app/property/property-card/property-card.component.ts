import { Component, Input } from "@angular/core";
import { IProperty } from "../IProperty.interface";

@Component({
    selector: 'app-property-card',
    //template: `<h1>I am a card</h1>`,
    templateUrl: 'property-card.components.html',
    // styles: ['h1{font-weight: normal;}']
    styleUrls: ['property-card.components.css']
}
)
export class PropertyCardComponent {
    @Input() property: IProperty;

}