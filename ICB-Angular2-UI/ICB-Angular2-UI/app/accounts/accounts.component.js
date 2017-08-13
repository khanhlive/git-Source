"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var AccountComponent = (function () {
    function AccountComponent() {
        this.header = 'My Account';
        this.firstName = 'Nguyễn Đình';
        this.lastName = 'Khánh';
        this.a = 11;
        this.b = 22;
        this.imageURL = '../../images/demo-image.jpg';
    }
    AccountComponent.prototype.GetName = function () {
        return this.firstName + ' ' + this.lastName;
    };
    AccountComponent = __decorate([
        core_1.Component({
            selector: 'my-acc',
            templateUrl: 'app/accounts/accounts.component.html',
            styleUrls: ['app/accounts/accounts.component.css']
        }), 
        __metadata('design:paramtypes', [])
    ], AccountComponent);
    return AccountComponent;
}());
exports.AccountComponent = AccountComponent;
//# sourceMappingURL=accounts.component.js.map