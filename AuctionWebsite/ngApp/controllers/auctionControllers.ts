namespace MyApp.Controllers {

    export class AuctionControllers {

        //contains a list of items
        public items;
        //contains a bid
        public bid;

        constructor(private auctionService: MyApp.Services.AuctionService, private $location: ng.ILocationService, private $uibModal: angular.ui.bootstrap.IModalService)
        {
            this.displayItems();
        };

        displayItems() {
            this.items = this.auctionService.listItems();
        }

    }

}