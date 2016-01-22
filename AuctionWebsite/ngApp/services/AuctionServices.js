var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var AuctionService = (function () {
            function AuctionService($resource) {
                this.AuctionResource = $resource("api/item/:id");
            }
            ;
            AuctionService.prototype.listItems = function () {
                return this.AuctionResource.query();
            };
            ;
            return AuctionService;
        })();
        Services.AuctionService = AuctionService;
        angular.module("MyApp").service("auctionService", AuctionService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=AuctionServices.js.map