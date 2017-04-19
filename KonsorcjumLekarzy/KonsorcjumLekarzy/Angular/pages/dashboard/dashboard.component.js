(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.dashboard");

    function controller() {
        var vm = this;

    }

    module.component("dashboard",
    {
        templateUrl : "Angular/pages/dashboard/dashboard.html", 
        controllerAs: "vm",
        controller: controller
    });


})();