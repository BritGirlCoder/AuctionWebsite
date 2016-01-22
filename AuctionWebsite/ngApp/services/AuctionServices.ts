namespace MyApp.Services {

    export class AuctionService {

        private AuctionResource;

        //contains a list of items
        public items;
        //contains a bid
        public bid;

        constructor($resource: angular.resource.IResourceService) {
            this.AuctionResource = $resource("api/item/:id");
        };

        public listItems() {
            return this.AuctionResource.query();
        };
    }

    angular.module("MyApp").service("auctionService", AuctionService);

}