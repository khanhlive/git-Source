//import { Component } from '@angular/core';

//@Component({
//    selector: 'my-app',
//    templateUrl: 'app.component.html',
//    styleUrls: [ 'app.component.css'],
//    moduleId: module.id
//})
//export class AppComponent { name1 = 'Nguyen Dinh Khanh 23'; }
import { Component } from '@angular/core'
@Component({
    selector: 'my-demo',
    templateUrl: 'app.component.html',
    styleUrls:['app.component.css'],
    moduleId: module.id
})
export 
    class AppComponent {
    pageHeader: string = "Account Details";
    name: string = "Khánh";
    ClickMe() {
        console.log(this.name);
    }
}

