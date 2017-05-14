/**
 * @author p.maslava
 * created on 28.11.2016
 */
(function() {
    "use strict";

    const model = angular.module("BlurAdmin.pages.doctors");

    /** @ngInject */
    function controller() {

        var vm = this;

        var parseData = function() {
            vm.doctors = global_InitData.Doctors;
            for (let doctor = 0; doctor < vm.doctors.length; doctor++) {
                vm.standardSelectItems.push({
                    label: vm.doctors[doctor].FirstName + " " + vm.doctors[doctor].LastName,
                    value: vm.doctors[doctor].DoctorId
                });
                console.log(vm.standardSelectItems);
            }
        };

        vm.$onInit = function () {
            vm.doctors = [];
            vm.disabled = undefined;
            vm.standardItem = {};
            vm.standardSelectItems = [];
            parseData();
        };
    }

    model.component("selectPickerPanel",
    {
        templateUrl: "Angular/pages/doctors/selectPanel/select.html",
        controllerAs: "vm",
        bindings: {
            selectDoctors: "&"
        },
        controller: controller
    });

})();