!function(){"use strict";function r(r){var t=this;t.trips=[],t.newTrip={},t.errorMessage="",t.isBusy=!0,r.get("/api/trips").then(function(r){angular.copy(r.data,t.trips)},function(){t.errorMessage="Failed to load data: "+error}).finally(function(){t.isBusy=!1}),t.addTrip=function(){t.isBusy=!0,t.errorMessage="",r.post("/api/trips",t.newTrip).then(function(r){t.trips.push(r.data),t.newTrip={}},function(){t.errorMessage="Failed to Save data: "+error}).finally(function(){t.isBusy=!1})}}r.$inject=["$http"],angular.module("app-trips").controller("tripsController",r)}();