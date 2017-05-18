(function(){
    'use strict';

    var module = angular.module('BlurAdmin.pages.doctors');
    
    /** @ngInject */
    function controller() {
        var vm = this;
        vm.open = open;
        vm.opened = false;
        vm.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        vm.format = vm.formats[0];
        vm.options = {
            showWeeks: false
        };

        function open() {
            vm.opened = true;
        }
    }

    module.component('datePickerPopup', {
        templateUrl: "Angular/pages/doctors/datePickers/datePickersPopup.html",
        bindings: {
            dt: '='
        },
        controllerAs: "vm",
        controller: controller
    });
})();