
// Creating TopSpotsController under myApp module to call TopSpotsFactory methods

(function() {
    'use strict';

    angular
        .module('myApp')
        .controller('TopSpotsController', TopSpotsController);

    TopSpotsController.$inject = ['TopSpotsFactory'];

    /* @ngInject */
    function TopSpotsController(TopSpotsFactory) {
        var vm = this;
        vm.title = 'TopSpotsController';
        vm.addTopSpot = addTopSpot;
        vm.deleteTopSpot = deleteTopSpot;

        activate();

        ////////////////

        //Defining activate function to call getTopSpots function upon page load and get the top spots data from the JSON object

        function activate() {

            TopSpotsFactory.getTopSpots()
				.then(function(response) {

                vm.topspots = response.data;
                toastr.success('Top Spots Data Loaded!');


            },
            function(error){
                if(typeof error === 'object'){
                    toastr.error('There was an error: ' + error.data);  
                } else{
                    toastr.info(error);
                }     
            })
        }

        //Calling functions form TopspotsFactory to add and delete topspots

        function addTopSpot(topSpotName, topSpotDesc, topSpotLat, topSpotLong){
        	TopSpotsFactory.addTopSpot(vm.topspots, topSpotName, topSpotDesc, topSpotLat, topSpotLong);
        }

        function deleteTopSpot($index){
            TopSpotsFactory.deleteTopSpot(vm.topspots, $index);

        }
    }
})();
