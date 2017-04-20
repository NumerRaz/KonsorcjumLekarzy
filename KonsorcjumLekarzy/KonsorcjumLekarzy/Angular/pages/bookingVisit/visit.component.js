(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit");

    function controller() {
        var vm = this;

        vm.$onInit = function() {
            vm.dupa = "test";
        }
    }

    module.component("bookingvisit",
    {
        template: "tset",
        controllerAs: "vm",
        controller: controller
    });


})(); 