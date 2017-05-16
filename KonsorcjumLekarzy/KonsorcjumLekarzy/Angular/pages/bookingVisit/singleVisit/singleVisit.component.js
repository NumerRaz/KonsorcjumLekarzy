(function () {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit");

    function controller() {
        var vm = this;
        
        vm.$onInit = function () {
            console.log(vm.visit);
        }
    }

    module.component("singleVisit",
    {
        templateUrl: "Angular/pages/bookingVisit/singleVisit/singleVisit.html",
        bindings: {
            visit: "<"
        },
        controllerAs: "vm",
        controller: controller
    });
})();