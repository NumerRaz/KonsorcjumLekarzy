(function () {
    "use strict";

    const module = angular.module("BlurAdmin.pages.profile");

    function controller() {
        var vm = this;

        vm.$onInit = function () {
        };
    }

    module.component("profile",
    {
        templateUrl: "Angular/pages/profile/profile.html",
        controllerAs: "vm",
        controller: controller
    });
})();