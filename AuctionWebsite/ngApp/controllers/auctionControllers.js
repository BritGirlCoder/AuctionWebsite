var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var AuctionControllers = (function () {
            function AuctionControllers(auctionService, $location, $uibModal) {
                this.auctionService = auctionService;
                this.$location = $location;
                this.$uibModal = $uibModal;
                this.displayItems();
            }
            ;
            AuctionControllers.prototype.displayItems = function () {
                this.items = this.auctionService.listItems();
            };
            return AuctionControllers;
        })();
        Controllers.AuctionControllers = AuctionControllers;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=auctionControllers.js.map