(function(){
    'use strict';

    var module = angular.module('BlurAdmin.pages.doctors');

    /** @ngInject */
    function controller() {
        var vm = this;
        vm.dt = new Date();
        vm.options = {
            showWeeks: false
        };
    }

    module.component('datePicker', {
        templateUrl: "Angular/pages/doctors/datePickers/datePickers.html",
        bindings: {
            doctor: '<',
            patient: '<'
        },
        controllerAs: "vm",
        controller: controller
    });
})();