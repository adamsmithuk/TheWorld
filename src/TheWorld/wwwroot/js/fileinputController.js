(function() {
    'use strict';

    // Getting the existing module
    angular.module("app-trips")
        .controller("fileInputController", fileInputController);

    function fileInputController($http) {

        alert("File Upload");
    
    }


})();