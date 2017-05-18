(function () {
    'use strict';

    var module = angular.module('BlurAdmin.pages.doctors');

    /** @ngInject */
    function controller() {
        var vm = this;
        
    }

    module.component('emailSender', {
        templateUrl: "Angular/pages/doctors/emailSender/emailSender.html",
        bindings: {

        },
        controllerAs: "vm",
        controller: controller
    });
})();