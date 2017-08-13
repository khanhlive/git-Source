import {Component} from '@angular/core'

@Component({
    selector: 'my-acc',
    templateUrl: 'app/accounts/accounts.component.html',
    styleUrls:['app/accounts/accounts.component.css']
})
export class AccountComponent {
    header: string = 'My Account';
    firstName: string = 'Nguyễn Đình';
    lastName: string = 'Khánh';
    a: number = 11;
    b: number = 22;
    imageURL = '../../images/demo-image.jpg';
    GetName():string {
        return this.firstName + ' ' + this.lastName;
    }
}