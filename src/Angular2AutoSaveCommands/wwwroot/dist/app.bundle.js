webpackJsonp([0],{

/***/ 0:
/*!*****************************!*\
  !*** ./angular2App/boot.ts ***!
  \*****************************/
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var platform_browser_dynamic_1 = __webpack_require__(/*! @angular/platform-browser-dynamic */ 1);
	var app_module_1 = __webpack_require__(/*! ./app/app.module */ 337);
	platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule);


/***/ },

/***/ 337:
/*!***************************************!*\
  !*** ./angular2App/app/app.module.ts ***!
  \***************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var common_1 = __webpack_require__(/*! @angular/common */ 205);
	var forms_1 = __webpack_require__(/*! @angular/forms */ 338);
	var platform_browser_1 = __webpack_require__(/*! @angular/platform-browser */ 203);
	var app_component_1 = __webpack_require__(/*! ./app.component */ 376);
	var app_constants_1 = __webpack_require__(/*! ./app.constants */ 441);
	var app_routes_1 = __webpack_require__(/*! ./app.routes */ 442);
	var http_1 = __webpack_require__(/*! @angular/http */ 445);
	var home_component_1 = __webpack_require__(/*! ./home/home.component */ 443);
	var about_component_1 = __webpack_require__(/*! ./about/about.component */ 468);
	var testDataService_1 = __webpack_require__(/*! ./services/testDataService */ 444);
	var AppModule = (function () {
	    function AppModule() {
	    }
	    AppModule = __decorate([
	        core_1.NgModule({
	            imports: [
	                platform_browser_1.BrowserModule,
	                common_1.CommonModule,
	                forms_1.FormsModule,
	                app_routes_1.routing,
	                http_1.HttpModule,
	                http_1.JsonpModule
	            ],
	            declarations: [
	                app_component_1.AppComponent,
	                about_component_1.AboutComponent,
	                home_component_1.HomeComponent
	            ],
	            providers: [
	                testDataService_1.TestDataService,
	                app_constants_1.Configuration
	            ],
	            bootstrap: [app_component_1.AppComponent],
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AppModule);
	    return AppModule;
	}());
	exports.AppModule = AppModule;


/***/ },

/***/ 376:
/*!******************************************!*\
  !*** ./angular2App/app/app.component.ts ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var router_1 = __webpack_require__(/*! @angular/router */ 377);
	var AppComponent = (function () {
	    function AppComponent(router) {
	        this.router = router;
	    }
	    AppComponent = __decorate([
	        core_1.Component({
	            selector: 'my-app',
	            template: __webpack_require__(/*! ./app.component.html */ 438),
	            styles: [__webpack_require__(/*! ./app.component.scss */ 439), __webpack_require__(/*! ../style/app.scss */ 440)],
	            directives: [router_1.ROUTER_DIRECTIVES]
	        }), 
	        __metadata('design:paramtypes', [router_1.Router])
	    ], AppComponent);
	    return AppComponent;
	}());
	exports.AppComponent = AppComponent;


/***/ },

/***/ 438:
/*!********************************************!*\
  !*** ./angular2App/app/app.component.html ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"container\" style=\"margin-top: 15px;\">\r\n\r\n    <nav class=\"navbar navbar-inverse\">\r\n        <div class=\"container-fluid\">\r\n            <div class=\"navbar-header\">\r\n                <a class=\"navbar-brand\" [routerLink]=\"['/about']\">ASP.NET Command</a>\r\n            </div>\r\n            <ul class=\"nav navbar-nav\">\r\n                <li><a [routerLink]=\"['/home']\">Home</a></li>\r\n                <li><a [routerLink]=\"['/about']\">About</a></li>\r\n            </ul>\r\n            <ul class=\"nav navbar-nav navbar-right\">\r\n                <li><a href=\"https://twitter.com/damien_bod\"><img src=\"assets/damienbod.jpg\" height=\"40\" style=\"margin-top: -10px;\" /></a></li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n\r\n\r\n\r\n    <router-outlet></router-outlet>\r\n\r\n\r\n    <footer>\r\n        <p>\r\n            <a href=\"https://twitter.com/damien_bod\">DamienBod</a>&nbsp;Blog: <a href=\"https://damienbod.com/\">Software Engineering</a>\r\n            &copy; 2016\r\n        </p>\r\n    </footer>\r\n</div>"

/***/ },

/***/ 439:
/*!********************************************!*\
  !*** ./angular2App/app/app.component.scss ***!
  \********************************************/
/***/ function(module, exports) {

	module.exports = "// style-loader: Adds some css to the DOM by adding a <style> tag\n\n// load the styles\nvar content = require(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.component.scss\");\nif(typeof content === 'string') content = [[module.id, content, '']];\n// add the styles to the DOM\nvar update = require(\"!./../../node_modules/style-loader/addStyles.js\")(content, {});\nif(content.locals) module.exports = content.locals;\n// Hot Module Replacement\nif(module.hot) {\n\t// When the styles change, update the <style> tags\n\tif(!content.locals) {\n\t\tmodule.hot.accept(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.component.scss\", function() {\n\t\t\tvar newContent = require(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.component.scss\");\n\t\t\tif(typeof newContent === 'string') newContent = [[module.id, newContent, '']];\n\t\t\tupdate(newContent);\n\t\t});\n\t}\n\t// When the module is disposed, remove the <style> tags\n\tmodule.hot.dispose(function() { update(); });\n}"

/***/ },

/***/ 440:
/*!************************************!*\
  !*** ./angular2App/style/app.scss ***!
  \************************************/
/***/ function(module, exports) {

	module.exports = "// style-loader: Adds some css to the DOM by adding a <style> tag\n\n// load the styles\nvar content = require(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.scss\");\nif(typeof content === 'string') content = [[module.id, content, '']];\n// add the styles to the DOM\nvar update = require(\"!./../../node_modules/style-loader/addStyles.js\")(content, {});\nif(content.locals) module.exports = content.locals;\n// Hot Module Replacement\nif(module.hot) {\n\t// When the styles change, update the <style> tags\n\tif(!content.locals) {\n\t\tmodule.hot.accept(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.scss\", function() {\n\t\t\tvar newContent = require(\"!!./../../node_modules/css-loader/index.js!./../../node_modules/sass-loader/index.js!./app.scss\");\n\t\t\tif(typeof newContent === 'string') newContent = [[module.id, newContent, '']];\n\t\t\tupdate(newContent);\n\t\t});\n\t}\n\t// When the module is disposed, remove the <style> tags\n\tmodule.hot.dispose(function() { update(); });\n}"

/***/ },

/***/ 441:
/*!******************************************!*\
  !*** ./angular2App/app/app.constants.ts ***!
  \******************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var Configuration = (function () {
	    function Configuration() {
	        this.Server = "http://localhost:5000/";
	    }
	    Configuration = __decorate([
	        core_1.Injectable(), 
	        __metadata('design:paramtypes', [])
	    ], Configuration);
	    return Configuration;
	}());
	exports.Configuration = Configuration;


/***/ },

/***/ 442:
/*!***************************************!*\
  !*** ./angular2App/app/app.routes.ts ***!
  \***************************************/
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var router_1 = __webpack_require__(/*! @angular/router */ 377);
	var home_component_1 = __webpack_require__(/*! ./home/home.component */ 443);
	var about_component_1 = __webpack_require__(/*! ./about/about.component */ 468);
	var appRoutes = [
	    { path: '', component: home_component_1.HomeComponent },
	    { path: 'home', component: home_component_1.HomeComponent },
	    { path: 'about', component: about_component_1.AboutComponent }
	];
	exports.routing = router_1.RouterModule.forRoot(appRoutes);


/***/ },

/***/ 443:
/*!************************************************!*\
  !*** ./angular2App/app/home/home.component.ts ***!
  \************************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var common_1 = __webpack_require__(/*! @angular/common */ 205);
	var testDataService_1 = __webpack_require__(/*! ../services/testDataService */ 444);
	var HomeComponent = (function () {
	    function HomeComponent(_dataService) {
	        this._dataService = _dataService;
	        this.message = "Hello from HomeComponent constructor";
	    }
	    HomeComponent.prototype.ngOnInit = function () {
	        var _this = this;
	        this._dataService
	            .GetAll()
	            .subscribe(function (data) { return _this.values = data; }, function (error) { return console.log(error); }, function () { return console.log('Get all complete'); });
	    };
	    HomeComponent = __decorate([
	        core_1.Component({
	            selector: 'homecomponent',
	            template: __webpack_require__(/*! ./home.component.html */ 467),
	            directives: [common_1.CORE_DIRECTIVES],
	            providers: [testDataService_1.TestDataService]
	        }), 
	        __metadata('design:paramtypes', [testDataService_1.TestDataService])
	    ], HomeComponent);
	    return HomeComponent;
	}());
	exports.HomeComponent = HomeComponent;


/***/ },

/***/ 444:
/*!*****************************************************!*\
  !*** ./angular2App/app/services/testDataService.ts ***!
  \*****************************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var http_1 = __webpack_require__(/*! @angular/http */ 445);
	__webpack_require__(/*! rxjs/add/operator/map */ 380);
	var app_constants_1 = __webpack_require__(/*! ../app.constants */ 441);
	var TestDataService = (function () {
	    function TestDataService(_http, _configuration) {
	        var _this = this;
	        this._http = _http;
	        this._configuration = _configuration;
	        this.GetAll = function () {
	            return _this._http.get(_this.actionUrl).map(function (response) { return response.json(); });
	        };
	        this.GetSingle = function (id) {
	            return _this._http.get(_this.actionUrl + id).map(function (res) { return res.json(); });
	        };
	        this.Add = function (itemName) {
	            var toAdd = JSON.stringify({ ItemName: itemName });
	            return _this._http.post(_this.actionUrl, toAdd, { headers: _this.headers }).map(function (res) { return res.json(); });
	        };
	        this.Update = function (id, itemToUpdate) {
	            return _this._http
	                .put(_this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: _this.headers })
	                .map(function (res) { return res.json(); });
	        };
	        this.Delete = function (id) {
	            return _this._http.delete(_this.actionUrl + id);
	        };
	        this.actionUrl = _configuration.Server + 'api/values/';
	        this.headers = new http_1.Headers();
	        this.headers.append('Content-Type', 'application/json');
	        this.headers.append('Accept', 'application/json');
	    }
	    TestDataService = __decorate([
	        core_1.Injectable(), 
	        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
	    ], TestDataService);
	    return TestDataService;
	}());
	exports.TestDataService = TestDataService;


/***/ },

/***/ 467:
/*!**************************************************!*\
  !*** ./angular2App/app/home/home.component.html ***!
  \**************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"panel-group\">\r\n\r\n    <p>hello {{message}}</p>\r\n\r\n    <ul>\r\n        <li *ngFor=\"let value of values\">\r\n            <span>{{value}} </span>\r\n        </li>\r\n    </ul>\r\n</div>"

/***/ },

/***/ 468:
/*!**************************************************!*\
  !*** ./angular2App/app/about/about.component.ts ***!
  \**************************************************/
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(/*! @angular/core */ 11);
	var common_1 = __webpack_require__(/*! @angular/common */ 205);
	var AboutComponent = (function () {
	    function AboutComponent() {
	        this.message = "Hello from About";
	    }
	    AboutComponent.prototype.ngOnInit = function () {
	    };
	    AboutComponent = __decorate([
	        core_1.Component({
	            selector: 'about',
	            template: __webpack_require__(/*! ./about.component.html */ 469),
	            directives: [common_1.CORE_DIRECTIVES]
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AboutComponent);
	    return AboutComponent;
	}());
	exports.AboutComponent = AboutComponent;


/***/ },

/***/ 469:
/*!****************************************************!*\
  !*** ./angular2App/app/about/about.component.html ***!
  \****************************************************/
/***/ function(module, exports) {

	module.exports = "<div class=\"panel-group\">\n\n    <p>{{message}}</p>\n\n    <textarea style=\"height: 600px;\" class=\"col-lg-12\" readonly>\r\n        http://localhost:5000/api/command/execute\r\n        User-Agent: Fiddler\r\n        Host: localhost:5000\r\n        Content-Type: application/json\r\n\r\n        {\r\n        \"commandType\":\"ADD\",\r\n        \"payloadType\":\"ABOUT\",\r\n        \"payload\":\r\n        {\r\n        \"Id\":0,\r\n        \"Description\":\"something from the about form\",\r\n        \"Deleted\":false\r\n        },\r\n        \"actualClientRoute\":\"http://damienbod.com\"\r\n        }\r\n\r\n        ------------------------------------------------------\r\n\r\n        http://localhost:5000/api/command/undo\r\n        http://localhost:5000/api/command/redo\r\n\r\n        ------------------------------------------------------\r\n\r\n        http://localhost:5000/api/command/execute\r\n        User-Agent: Fiddler\r\n        Host: localhost:5000\r\n        Content-Type: application/json\r\n\r\n        {\r\n        \"commandType\":\"ADD\",\r\n        \"payloadType\":\"HOME\",\r\n        \"payload\":\r\n        {\r\n        \"Id\":0,\r\n        \"Description\":\"A lovely home object\",\r\n        \"Deleted\":false\r\n        },\r\n        \"actualClientRoute\":\"http://damienbod.com\"\r\n        }\r\n\r\n        ------------------------------------------------------\r\n\r\n        http://localhost:5000/api/command/execute\r\n        User-Agent: Fiddler\r\n        Host: localhost:5000\r\n        Content-Type: application/json\r\n\r\n        {\r\n        \"commandType\":\"DELETE\",\r\n        \"payloadType\":\"ABOUT\",\r\n        \"payload\":\r\n        {\r\n        \"Id\":1,\r\n        \"Description\":\"something from the about form\",\r\n        \"Deleted\":false\r\n        },\r\n        \"actualClientRoute\":\"http://damienbod.com\"\r\n        }\r\n\r\n        ------------------------------------------------------\r\n\r\n    </textarea>\n</div>"

/***/ }

});
//# sourceMappingURL=app.bundle.js.map