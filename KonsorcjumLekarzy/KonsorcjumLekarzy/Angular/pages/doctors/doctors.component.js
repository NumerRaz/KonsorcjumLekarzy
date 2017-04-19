(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.doctors");

    function controller() {
        var vm = this;

        vm.doctorsList = [
            {
                name: "House 1",
                description: "Exampe description",
                specjalization: "Example 1"
            },
            {
                name: "House 2",
                description: "Exampe description",
                specjalization: "Example 2"
            },
            {
                name: "House 3",
                description: "Exampe description",
                specjalization: "Example 3"
            }
        ];

        vm.$onInit = function() {
            vm.selectDoctors = "Example data";
        }
    }

    module.component("doctors",
    {
        templateUrl: 'Angular/pages/doctors/doctors.html',
        controllerAs: "vm",
        controller: controller
    }); 

})();