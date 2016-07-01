// Creating TopSpotsFactory to contain top spots related services

(function() {
    'use strict';

    angular
        .module('myApp')
        .factory('TopSpotsFactory', TopSpotsFactory);

    TopSpotsFactory.$inject = ['$http', '$q'];

    /* @ngInject */
    function TopSpotsFactory($http, $q) {
        var url = 'http://localhost:51057/api/topspots/';
        var service = {
            getTopSpots: getTopSpots,
            addTopSpot: addTopSpot,
            deleteTopSpot: deleteTopSpot
        };
        return service;

        ////////////////

        //Defining TopSpots related services to get, add and delete topSpots

        function getTopSpots() {

            var defer = $q.defer();

            $http({
                method: 'GET',
                url: url
            }).then(function(response) {
                    if (typeof response.data === 'object') {
                        defer.resolve(response);
                    } else {
                        defer.reject("No data found!");
                    }
                },
                function(error) {
                    defer.reject(error);
                });

            return defer.promise;

        }

        function addTopSpot(topSpots, topSpotName, topSpotDesc, topSpotLat, topSpotLong) {

            var defer = $q.defer();

            var config = {
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            }

            //Checks form to see if any fields were not input and then posts data to api

            if (topSpotName !== "" && topSpotDesc !== "" && topSpotLat !== "" && topSpotLong !== "") {

                var topSpotLocation = [topSpotLat, topSpotLong];
                var topSpot = { name: topSpotName, description: topSpotDesc, location: topSpotLocation };
                var topSpotJSON = JSON.stringify(topSpot);

                $http({
                    method: 'POST',
                    url: url,
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                    },
                    data: topSpot
                }).then(function(response) {
                        if (typeof response.data === 'object') {
                            defer.resolve(response);
                        } else {
                            defer.reject("No data found!");
                        }
                    },
                    function(error) {
                        defer.reject(error);
                    });

                return defer.promise;

                //Return error message if any fields were missing
            } else if (topSpotName === "" || topSpotDesc === "" || topSpotLat === "" || topSpotLong === "") {
                defer.reject("Please complete the form! You are missing inputed fields.");
                return defer.promise;
            }
        }

        function deleteTopSpot(index) {
            
            var defer = $q.defer();


            $http({
                method: 'DELETE',
                url: url + index
            }).then(function(response) {
                    if (typeof response.data === 'object') {
                        defer.resolve(response);
                    } else {
                        defer.reject("No data found!");
                    }
                },
                function(error) {
                    defer.reject(error);
                });

            return defer.promise;


        }
    }
})();
