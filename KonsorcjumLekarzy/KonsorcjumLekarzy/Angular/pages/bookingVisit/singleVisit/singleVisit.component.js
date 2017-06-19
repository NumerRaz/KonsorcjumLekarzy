(function () {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit");

    controller.$inject = ["$http"];

    function controller($http) {
        var vm = this;

        var saveChanges = function() {
            var data = {
                id: vm.visit.visitId
            }
            $http.post('/Home/ConfirmeVisit/', data)
            .success(function (data, status, headers, config) {
                    vm.visit.confirmation = true;
                    console.log(data);
                })
            .error(function (data, status, headers, config) {
                    vm.visit.confirmation = false;
                    console.log(data);
                });
        };

        vm.showPrescription = function (event) {
            console.log(event);
        }

        vm.confirmVisit = function () {
            saveChanges();
        };

        vm.$onInit = function() {
        };
    }

    module.component("singleVisit",
    {
        templateUrl: "Angular/pages/bookingVisit/singleVisit/singleVisit.html",
        bindings: {
            visit: "="
        },
        controllerAs: "vm",
        controller: controller
    });
})();